import React from 'react';
import { ShoeVariant } from '../types';

interface Props {
  variant: ShoeVariant | null;
  onSave: (data: Partial<ShoeVariant>) => void;
  onCancel: () => void;
}

export const VariantForm: React.FC<Props> = ({ variant, onSave, onCancel }) => {
  const [skuCode, setSkuCode] = React.useState(variant?.skuCode || '');
  const [size, setSize] = React.useState(variant?.size || '');
  const [color, setColor] = React.useState(variant?.color || '');
  const [costPrice, setCostPrice] = React.useState(variant?.costPrice || 0);
  const [retailPrice, setRetailPrice] = React.useState(variant?.retailPrice || 0);
  const [stockQuantity, setStockQuantity] = React.useState(variant?.stockQuantity || 0);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    onSave({ skuCode, size, color, costPrice, retailPrice, stockQuantity });
  };

  return (
    <div className="fixed inset-0 bg-black/40 flex items-center justify-center z-50">
      <form onSubmit={handleSubmit} className="bg-white p-6 rounded-lg shadow-xl w-full max-w-md space-y-4">
        <h2 className="text-xl font-bold">{variant ? 'Edit' : 'New'} Variant</h2>
        <div>
          <label className="block text-xs font-bold text-gray-400 uppercase mb-1">SKU Code</label>
          <input className="w-full px-3 py-2 border rounded-md outline-none focus:ring-2 focus:ring-blue-500" value={skuCode} onChange={e => setSkuCode(e.target.value)} required />
        </div>
        <div className="grid grid-cols-2 gap-4">
          <div>
            <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Size</label>
            <input className="w-full px-3 py-2 border rounded-md outline-none focus:ring-2 focus:ring-blue-500" value={size} onChange={e => setSize(e.target.value)} required />
          </div>
          <div>
            <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Color</label>
            <input className="w-full px-3 py-2 border rounded-md outline-none focus:ring-2 focus:ring-blue-500" value={color} onChange={e => setColor(e.target.value)} required />
          </div>
        </div>
        <div className="grid grid-cols-2 gap-4">
          <div>
            <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Cost Price</label>
            <input type="number" step="0.01" className="w-full px-3 py-2 border rounded-md outline-none focus:ring-2 focus:ring-blue-500" value={costPrice} onChange={e => setCostPrice(Number(e.target.value))} required />
          </div>
          <div>
            <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Retail Price</label>
            <input type="number" step="0.01" className="w-full px-3 py-2 border rounded-md outline-none focus:ring-2 focus:ring-blue-500" value={retailPrice} onChange={e => setRetailPrice(Number(e.target.value))} required />
          </div>
        </div>
        <div>
          <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Initial Stock</label>
          <input type="number" className="w-full px-3 py-2 border rounded-md outline-none focus:ring-2 focus:ring-blue-500" value={stockQuantity} onChange={e => setStockQuantity(Number(e.target.value))} required />
        </div>
        <div className="flex justify-end gap-3 pt-2">
          <button type="button" onClick={onCancel} className="px-4 py-2 bg-gray-200 rounded hover:bg-gray-300">Cancel</button>
          <button type="submit" className="px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700">{variant ? 'Update' : 'Create'}</button>
        </div>
      </form>
    </div>
  );
};
