import React, { useState, useEffect } from 'react';
import { ShoeModel } from '../types';
import { api } from '../api/client';

interface Props {
  model: ShoeModel | null;
  onSave: (data: Partial<ShoeModel>) => void;
  onCancel: () => void;
}

export const ModelForm: React.FC<Props> = ({ model, onSave, onCancel }) => {
  const [name, setName] = useState(model?.name || '');
  const [brand, setBrand] = useState(model?.brand || '');
  const [baseMaterial, setBaseMaterial] = useState(model?.baseMaterial || '');
  const [description, setDescription] = useState(model?.description || '');
  const [manufacturerId, setManufacturerId] = useState(model?.manufacturerId || 0);
  const [shoeCategoryId, setShoeCategoryId] = useState(model?.shoeCategoryId || 0);
  const [manufacturers, setManufacturers] = useState<any[]>([]);
  const [categories, setCategories] = useState<any[]>([]);

  useEffect(() => {
    api.manufacturers.getAll().then(r => setManufacturers(r.data));
    api.shoeCategories.getAll().then(r => setCategories(r.data));
  }, []);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!manufacturerId || !shoeCategoryId) return;
    onSave({ name, brand, baseMaterial, description, manufacturerId, shoeCategoryId });
  };

  return (
    <div className="fixed inset-0 bg-black/40 flex items-center justify-center z-50">
      <form onSubmit={handleSubmit} className="bg-white p-6 rounded-lg shadow-xl w-full max-w-md space-y-4">
        <h2 className="text-xl font-bold">{model ? 'Edit' : 'New'} Shoe Model</h2>
        <div>
          <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Name</label>
          <input className="w-full px-3 py-2 border rounded-md" value={name} onChange={e => setName(e.target.value)} required />
        </div>
        <div>
          <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Brand</label>
          <input className="w-full px-3 py-2 border rounded-md" value={brand} onChange={e => setBrand(e.target.value)} required />
        </div>
        <div>
          <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Base Material</label>
          <input className="w-full px-3 py-2 border rounded-md" value={baseMaterial} onChange={e => setBaseMaterial(e.target.value)} required />
        </div>
        <div>
          <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Manufacturer</label>
          <select className="w-full px-3 py-2 border rounded-md" value={manufacturerId} onChange={e => setManufacturerId(Number(e.target.value))} required>
            <option value={0}>Select Manufacturer</option>
            {manufacturers.map(m => <option key={m.id} value={m.id}>{m.name}</option>)}
          </select>
        </div>
        <div>
          <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Category</label>
          <select className="w-full px-3 py-2 border rounded-md" value={shoeCategoryId} onChange={e => setShoeCategoryId(Number(e.target.value))} required>
            <option value={0}>Select Category</option>
            {categories.map(c => <option key={c.id} value={c.id}>{c.name}</option>)}
          </select>
        </div>
        <div>
          <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Description</label>
          <textarea className="w-full px-3 py-2 border rounded-md" value={description} onChange={e => setDescription(e.target.value)} rows={3} />
        </div>
        <div className="flex justify-end gap-3 pt-2">
          <button type="button" onClick={onCancel} className="px-4 py-2 bg-gray-200 rounded hover:bg-gray-300">Cancel</button>
          <button type="submit" className="px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700">{model ? 'Update' : 'Create'}</button>
        </div>
      </form>
    </div>
  );
};
