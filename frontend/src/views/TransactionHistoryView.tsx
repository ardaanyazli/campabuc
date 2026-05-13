import React, { useState, useEffect } from 'react';
import { api } from '../api/client';

interface Sale {
  id: number;
  transactionDate: string;
  totalAmount: number;
  discountApplied: number;
  paymentMethod: string;
  items?: SaleItem[];
}

interface SaleItem {
  shoeVariantId: number;
  quantity: number;
  priceAtSale: number;
}

export const TransactionHistoryView: React.FC = () => {
  const [sales, setSales] = useState<Sale[]>([]);
  const [selectedSale, setSelectedSale] = useState<Sale | null>(null);

  useEffect(() => {
    api.sales.getAll().then(r => setSales(r.data));
  }, []);

  const viewSale = async (id: number) => {
    const res = await api.sales.getOne(id);
    setSelectedSale(res.data);
  };

  return (
    <div className="grid grid-cols-3 gap-6 h-full">
      <div className="col-span-1 bg-white p-4 rounded-lg shadow overflow-auto">
        <h2 className="text-lg font-bold mb-4">Transactions</h2>
        {sales.map(s => (
          <div key={s.id} onClick={() => viewSale(s.id)} className={`p-3 rounded cursor-pointer mb-2 ${selectedSale?.id === s.id ? 'bg-blue-100 border-l-4 border-blue-600' : 'hover:bg-gray-100'}`}>
            <div className="font-medium">Sale #{s.id}</div>
            <div className="text-xs text-gray-500">{new Date(s.transactionDate).toLocaleString()} — ${s.totalAmount.toFixed(2)}</div>
          </div>
        ))}
      </div>

      <div className="col-span-2 bg-white p-4 rounded-lg shadow overflow-auto">
        {selectedSale ? (
          <div>
            <div className="flex justify-between items-start mb-6">
              <div>
                <h2 className="text-2xl font-bold">Sale #{selectedSale.id}</h2>
                <p className="text-sm text-gray-500">{new Date(selectedSale.transactionDate).toLocaleString()}</p>
              </div>
              <div className="text-right">
                <div className="text-sm text-gray-500">Payment</div>
                <div className="font-bold">{selectedSale.paymentMethod}</div>
              </div>
            </div>

            <div className="border rounded-lg overflow-hidden mb-6">
              <table className="w-full text-left border-collapse">
                <thead className="bg-gray-50 text-gray-400 text-sm">
                  <tr>
                    <th className="py-2 px-3">Variant ID</th>
                    <th className="py-2 px-3">Qty</th>
                    <th className="py-2 px-3">Unit Price</th>
                    <th className="py-2 px-3">Total</th>
                  </tr>
                </thead>
                <tbody>
                  {(selectedSale.items || []).map((item, idx) => (
                    <tr key={idx} className="border-t hover:bg-gray-50">
                      <td className="py-3 px-3">{item.shoeVariantId}</td>
                      <td className="py-3 px-3">{item.quantity}</td>
                      <td className="py-3 px-3">${item.priceAtSale.toFixed(2)}</td>
                      <td className="py-3 px-3">${(item.quantity * item.priceAtSale).toFixed(2)}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>

            <div className="flex justify-end">
              <div className="w-64 space-y-2">
                <div className="flex justify-between text-gray-600"><span>Discount</span><span>-${selectedSale.discountApplied.toFixed(2)}</span></div>
                <div className="flex justify-between text-xl font-bold border-t pt-2"><span>Total</span><span>${selectedSale.totalAmount.toFixed(2)}</span></div>
              </div>
            </div>
          </div>
        ) : (
          <div className="flex items-center justify-center h-full text-gray-400">Select a transaction to view details</div>
        )}
      </div>
    </div>
  );
};
