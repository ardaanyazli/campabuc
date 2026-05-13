import React, { useState, useEffect } from 'react';
import { api } from '../api/client';
import { ShoeVariant } from '../types';

interface CartItem extends ShoeVariant {
  quantity: number;
}

export const CheckoutView: React.FC = () => {
  const [cart, setCart] = useState<CartItem[]>([]);
  const [discountPercent, setDiscountPercent] = useState(0);
  const [discountFixed, setDiscountFixed] = useState(0);
  const [taxRate, setTaxRate] = useState(0.15); // Default 15%
  const [totals, setTotals] = useState({ subtotal: 0, discount: 0, total: 0 });
  const [isProcessing, setIsProcessing] = useState(false);
  const [status, setStatus] = useState<string | null>(null);

  useEffect(() => {
    calculateTotals();
  }, [cart, discountPercent, discountFixed, taxRate]);

  const calculateTotals = async () => {
    if (cart.length === 0) {
      setTotals({ subtotal: 0, discount: 0, total: 0 });
      return;
    }

    const saleItems = cart.map(item => ({
        shoeVariantId: item.id,
        quantity: item.quantity,
        priceAtSale: item.retailPrice
    }));

    try {
      const res = await api.checkout.calculate({
        items: saleItems,
        discountPercent,
        fixedDiscount: discountFixed,
        taxRate
      });
      setTotals(res.data);
    } catch (e) {
      console.error("Calculation error", e);
    }
  };

  const updateQuantity = (id: number, delta: number) => {
    setCart(prev => prev.map(i => i.id === id ? { ...i, quantity: Math.max(1, i.quantity + delta) } : i));
  };

  const removeItem = (id: number) => setCart(prev => prev.filter(i => i.id !== id));

  const handleFinalize = async () => {
    setIsProcessing(true);
    try {
      const sale = {
        transactionDate: new Date().toISOString(),
        totalAmount: totals.total,
        discountApplied: totals.discount,
        paymentMethod: 'Cash', // Simplified
        items: cart.map(i => ({
          shoeVariantId: i.id,
          quantity: i.quantity,
          priceAtSale: i.retailPrice
        }))
      };
      await api.checkout.finalize(sale);
      setStatus('Sale completed successfully!');
      setCart([]);
    } catch (e) {
      setStatus('Sale failed. Please try again.');
    } finally {
      setIsProcessing(false);
    }
  };

  return (
    <div className="grid grid-cols-3 gap-8 h-full">
      <div className="col-span-2 bg-white p-6 rounded-lg shadow-sm border border-gray-200">
        <h2 className="text-xl font-bold mb-6 text-slate-800">Current Transaction</h2>
        <div className="space-y-4">
          {cart.length === 0 ? (
            <div className="text-center py-20 text-gray-400 italic">Cart is empty. Add items to begin.</div>
          ) : (
            <table className="w-full text-left border-collapse">
              <thead>
                <tr className="text-gray-400 text-sm border-b">
                  <th className="py-2">Item (SKU)</th>
                  <th className="py-2">Price</th>
                  <th className="py-2">Qty</th>
                  <th className="py-2">Subtotal</th>
                  <th className="py-2">Action</th>
                </tr>
              </thead>
              <tbody>
                {cart.map(item => (
                  <tr key={item.id} className="border-b hover:bg-gray-50">
                    <td className="py-3 font-medium">{item.skuCode}</td>
                    <td className="py-3">${item.retailPrice}</td>
                    <td className="py-3">
                      <div className="flex items-center gap-2">
                        <button onClick={() => updateQuantity(item.id, -1)} className="px-2 py-1 bg-gray-200 rounded">-</button>
                        <span>{item.quantity}</span>
                        <button onClick={() => updateQuantity(item.id, 1)} className="px-2 py-1 bg-gray-200 rounded">+</button>
                      </div>
                    </td>
                    <td className="py-3">${(item.retailPrice * item.quantity).toFixed(2)}</td>
                    <td className="py-3">
                      <button onClick={() => removeItem(item.id)} className="text-red-500 hover:text-red-700">Remove</button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>
      </div>

      <div className="col-span-1 bg-slate-50 p-6 rounded-lg shadow-inner border border-gray-200 flex flex-col justify-between">
        <div>
          <h2 className="text-xl font-bold mb-6 text-slate-800">Payment Summary</h2>
          <div className="space-y-4">
            <div className="flex justify-between text-gray-600">
              <span>Subtotal</span>
              <span className="font-medium">${totals.subtotal.toFixed(2)}</span>
            </div>
            <div className="flex flex-col gap-2">
              <label className="text-xs font-bold text-gray-400 uppercase">Discount %</label>
              <input 
                type="number" 
                className="px-3 py-2 border rounded-md" 
                value={discountPercent} 
                onChange={(e) => setDiscountPercent(Number(e.target.value))} 
              />
            </div>
            <div className="flex flex-col gap-2">
              <label className="text-xs font-bold text-gray-400 uppercase">Fixed Discount ($)</label>
              <input 
                type="number" 
                className="px-3 py-2 border rounded-md" 
                value={discountFixed} 
                onChange={(e) => setDiscountFixed(Number(e.target.value))} 
              />
            </div>
            <div className="flex flex-col gap-2">
              <label className="text-xs font-bold text-gray-400 uppercase">Tax Rate (%)</label>
              <input 
                type="number" 
                className="px-3 py-2 border rounded-md" 
                value={taxRate * 100} 
                onChange={(e) => setTaxRate(Number(e.target.value) / 100)} 
              />
            </div>
            <div className="pt-4 border-t flex justify-between items-center">
              <span className="text-lg font-bold">Total</span>
              <span className="text-2xl font-black text-blue-600">${totals.total.toFixed(2)}</span>
            </div>
          </div>
        </div>

        <div className="mt-8 space-y-3">
          <button 
            onClick={handleFinalize} 
            disabled={cart.length === 0 || isProcessing}
            className="w-full py-4 bg-blue-600 text-white rounded-xl font-bold text-lg hover:bg-blue-700 disabled:bg-gray-300 transition-all"
          >
            {isProcessing ? 'Processing...' : 'Complete Sale'}
          </button>
          {status && <p className={`text-center text-sm font-medium ${status.includes('failed') ? 'text-red-600' : 'text-green-600'}`}>{status}</p>}
        </div>
      </div>
    </div>
  );
};
