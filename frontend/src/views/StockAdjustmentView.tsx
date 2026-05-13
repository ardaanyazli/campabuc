import React, { useState, useEffect } from 'react';
import { api } from '../api/client';

export const StockAdjustmentView: React.FC = () => {
  const [variants, setVariants] = useState<any[]>([]);
  const [selectedVariant, setSelectedVariant] = useState(0);
  const [quantity, setQuantity] = useState(1);
  const [type, setType] = useState<number>(1); // 1=Return 2=Exchange 3=Damage
  const [reason, setReason] = useState('');
  const [status, setStatus] = useState<string | null>(null);

  useEffect(() => {
    api.shoeVariants.getAll().then(r => setVariants(r.data));
  }, []);

  const submitAdjustment = async () => {
    if (!selectedVariant) return;
    try {
      await api.inventory.adjustStock({ variantId: selectedVariant, quantity, type, reason });
      setStatus(`Adjustment recorded (${type === 1 ? 'Return' : type === 2 ? 'Exchange' : 'Damage'})`);
      setQuantity(1);
      setReason('');
    } catch (e) {
      setStatus('Adjustment failed');
    }
  };

  return (
    <div className="grid grid-cols-2 gap-8 h-full">
      <div className="bg-white p-6 rounded-lg shadow-sm border">
        <h2 className="text-xl font-bold mb-6">Stock Adjustment</h2>
        <div className="space-y-4">
          <div>
            <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Variant</label>
            <select className="w-full px-3 py-2 border rounded-md" value={selectedVariant} onChange={e => setSelectedVariant(Number(e.target.value))}>
              <option value={0}>Select Variant</option>
              {variants.map(v => <option key={v.id} value={v.id}>{v.skuCode} — {v.color}/{v.size} (Stock: {v.stockQuantity})</option>)}
            </select>
          </div>
          <div className="grid grid-cols-2 gap-4">
            <div>
              <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Type</label>
              <select className="w-full px-3 py-2 border rounded-md" value={type} onChange={e => setType(Number(e.target.value))}>
                <option value={1}>Return</option>
                <option value={2}>Exchange</option>
                <option value={3}>Damage</option>
              </select>
            </div>
            <div>
              <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Quantity</label>
              <input type="number" className="w-full px-3 py-2 border rounded-md" min={1} value={quantity} onChange={e => setQuantity(Number(e.target.value))} />
            </div>
          </div>
          <div>
            <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Reason</label>
            <textarea className="w-full px-3 py-2 border rounded-md" rows={3} value={reason} onChange={e => setReason(e.target.value)} placeholder="Describe the reason for this adjustment..." />
          </div>
          <button onClick={submitAdjustment} className="w-full py-3 bg-amber-600 text-white rounded-lg font-bold hover:bg-amber-700">Apply Adjustment</button>
          {status && <p className={`text-center text-sm font-medium ${status.includes('failed') ? 'text-red-600' : 'text-green-600'}`}>{status}</p>}
        </div>
      </div>

      <div className="bg-white p-6 rounded-lg shadow-sm border overflow-auto">
        <h2 className="text-xl font-bold mb-4">Adjustment Types Reference</h2>
        <div className="space-y-6">
          <div className="p-4 bg-green-50 rounded-lg border border-green-200">
            <h3 className="font-bold text-green-800">Return</h3>
            <p className="text-sm text-green-700 mt-1">Return stock back to inventory. Increases sellable quantity. Use when a customer brings back a product.</p>
          </div>
          <div className="p-4 bg-blue-50 rounded-lg border border-blue-200">
            <h3 className="font-bold text-blue-800">Exchange</h3>
            <p className="text-sm text-blue-700 mt-1">Swap one SKU for another. The returned item goes back to stock, and a new item is issued. Maintains balanced inventory.</p>
          </div>
          <div className="p-4 bg-red-50 rounded-lg border border-red-200">
            <h3 className="font-bold text-red-800">Damage</h3>
            <p className="text-sm text-red-700 mt-1">Removes items from sellable stock permanently. Use for defective, damaged, or lost inventory. Tracks business loss for reporting.</p>
          </div>
        </div>
      </div>
    </div>
  );
};
