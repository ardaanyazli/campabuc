import React, { useState, useEffect } from 'react';
import { api } from '../api/client';
import { ShoeModel, ShoeVariant } from '../types';
import { ModelForm } from '../components/ModelForm';
import { VariantForm } from '../components/VariantForm';

export const InventoryView: React.FC = () => {
  const [models, setModels] = useState<ShoeModel[]>([]);
  const [selectedModel, setSelectedModel] = useState<ShoeModel | null>(null);
  const [variants, setVariants] = useState<ShoeVariant[]>([]);
  const [showModelModal, setShowModelModal] = useState(false);
  const [editingModel, setEditingModel] = useState<ShoeModel | null>(null);
  const [showVariantModal, setShowVariantModal] = useState(false);
  const [editingVariant, setEditingVariant] = useState<ShoeVariant | null>(null);

  // Filters
  const [search, setSearch] = useState('');
  const [sizeFilter, setSizeFilter] = useState('');
  const [colorFilter, setColorFilter] = useState('');
  const [minPrice, setMinPrice] = useState(0);
  const [maxPrice, setMaxPrice] = useState(999999);

  useEffect(() => {
    loadModels();
  }, []);

  const loadModels = async () => {
    const res = await api.shoeModels.getAll();
    setModels(res.data);
  };

  const selectModel = async (model: ShoeModel) => {
    setSelectedModel(model);
    const res = await api.shoeVariants.getByModel(model.id);
    setVariants(res.data);
  };

  const handleModelSave = async (model: Partial<ShoeModel>) => {
    if (editingModel) {
      await api.shoeModels.update({ ...editingModel, ...model });
    } else {
      await api.shoeModels.create(model);
    }
    setShowModelModal(false);
    setEditingModel(null);
    await loadModels();
  };

  const handleModelDelete = async (id: number) => {
    await api.shoeModels.delete(id);
    if (selectedModel?.id === id) {
      setSelectedModel(null);
      setVariants([]);
    }
    await loadModels();
  };

  const handleVariantSave = async (variant: Partial<ShoeVariant>) => {
    if (editingVariant) {
      await api.shoeVariants.update({ ...editingVariant, ...variant });
    } else {
      await api.shoeVariants.create({ ...variant, shoeModelId: selectedModel!.id });
    }
    setShowVariantModal(false);
    setEditingVariant(null);
    selectModel(selectedModel!);
  };

  const handleVariantDelete = async (id: number) => {
    await api.shoeVariants.delete(id);
    selectModel(selectedModel!);
  };

  const filteredModels = models.filter(m =>
    !search || m.name.toLowerCase().includes(search.toLowerCase()) ||
    m.brand.toLowerCase().includes(search.toLowerCase()) ||
    m.baseMaterial.toLowerCase().includes(search.toLowerCase())
  );

  const filteredVariants = variants.filter(v =>
    (!sizeFilter || v.size === sizeFilter) &&
    (!colorFilter || v.color.toLowerCase().includes(colorFilter.toLowerCase())) &&
    (v.retailPrice >= minPrice) &&
    (v.retailPrice <= maxPrice)
  );

  const uniqueSizes = [...new Set(variants.map(v => v.size))];

  return (
    <div className="grid grid-cols-3 gap-6 h-full">
      <div className="col-span-1 bg-white p-4 rounded-lg shadow overflow-auto">
        <div className="flex justify-between items-center mb-4">
          <h2 className="text-lg font-bold">Shoe Models</h2>
          <button onClick={() => { setEditingModel(null); setShowModelModal(true); }} className="px-3 py-1 bg-blue-600 text-white rounded text-sm hover:bg-blue-700">Add</button>
        </div>
        <input
          type="text" placeholder="Search name, brand, material..."
          className="w-full px-3 py-2 border rounded-md text-sm mb-3"
          value={search} onChange={e => setSearch(e.target.value)}
        />
        <div className="space-y-2">
          {filteredModels.map(m => (
            <div key={m.id} onClick={() => selectModel(m)} className={`p-3 rounded cursor-pointer transition flex justify-between items-center ${selectedModel?.id === m.id ? 'bg-blue-100 border-l-4 border-blue-600' : 'hover:bg-gray-100'}`}>
              <div>
                <div className="font-medium">{m.name}</div>
                <div className="text-sm text-gray-500">{m.brand}</div>
              </div>
              <div className="flex gap-1">
                <button onClick={(e) => { e.stopPropagation(); setEditingModel(m); setShowModelModal(true); }} className="text-xs text-blue-500 hover:underline">Edit</button>
                <button onClick={(e) => { e.stopPropagation(); handleModelDelete(m.id); }} className="text-xs text-red-500 hover:underline">Del</button>
              </div>
            </div>
          ))}
        </div>
      </div>

      <div className="col-span-2 bg-white p-4 rounded-lg shadow overflow-auto">
        {selectedModel ? (
          <>
            <div className="flex justify-between items-center mb-4">
              <div>
                <h2 className="text-2xl font-bold">{selectedModel.name}</h2>
                <p className="text-sm text-gray-500">{selectedModel.brand} — {selectedModel.baseMaterial}</p>
              </div>
              <button onClick={() => { setEditingVariant(null); setShowVariantModal(true); }} className="px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700">+ Variant</button>
            </div>

            {/* Filters */}
            <div className="flex flex-wrap gap-3 mb-4 pb-4 border-b">
              <div>
                <label className="block text-xs text-gray-400">Size</label>
                <select className="px-2 py-1 border rounded text-sm" value={sizeFilter} onChange={e => setSizeFilter(e.target.value)}>
                  <option value="">All</option>
                  {uniqueSizes.map(s => <option key={s} value={s}>{s}</option>)}
                </select>
              </div>
              <div>
                <label className="block text-xs text-gray-400">Color</label>
                <input type="text" placeholder="Filter color" className="px-2 py-1 border rounded text-sm w-24" value={colorFilter} onChange={e => setColorFilter(e.target.value)} />
              </div>
              <div>
                <label className="block text-xs text-gray-400">Price From</label>
                <input type="number" className="px-2 py-1 border rounded text-sm w-20" value={minPrice} onChange={e => setMinPrice(Number(e.target.value))} />
              </div>
              <div>
                <label className="block text-xs text-gray-400">To</label>
                <input type="number" className="px-2 py-1 border rounded text-sm w-20" value={maxPrice === 999999 ? '' : maxPrice} onChange={e => setMaxPrice(Number(e.target.value) || 999999)} />
              </div>
              <button onClick={() => { setSizeFilter(''); setColorFilter(''); setMinPrice(0); setMaxPrice(999999); }} className="self-end px-2 py-1 text-xs text-blue-500">Clear</button>
            </div>

            <table className="w-full text-left border-collapse">
              <thead className="text-gray-400 text-sm border-b">
                <tr>
                  <th className="py-2">Barcode</th>
                  <th className="py-2">SKU</th>
                  <th className="py-2">Size</th>
                  <th className="py-2">Color</th>
                  <th className="py-2">Cost</th>
                  <th className="py-2">Retail</th>
                  <th className="py-2">Stock</th>
                  <th className="py-2">Actions</th>
                </tr>
              </thead>
              <tbody>
                {filteredVariants.map(v => (
                  <tr key={v.id} className="border-b hover:bg-gray-50">
                    <td className="py-3">
                      <div className="font-mono text-[10px] tracking-widest text-gray-400 bg-gray-100 px-2 py-1 rounded inline-block">
                        {v.skuCode}
                      </div>
                    </td>
                    <td className="py-3 font-mono text-sm">{v.skuCode}</td>
                    <td className="py-3">{v.size}</td>
                    <td className="py-3">{v.color}</td>
                    <td className="py-3">${v.costPrice?.toFixed(2)}</td>
                    <td className="py-3">${v.retailPrice?.toFixed(2)}</td>
                    <td className="py-3">{v.stockQuantity}</td>
                    <td className="py-3 flex gap-2">
                      <button onClick={() => { setEditingVariant(v); setShowVariantModal(true); }} className="text-xs text-blue-500 hover:underline">Edit</button>
                      <button onClick={() => handleVariantDelete(v.id)} className="text-xs text-red-500 hover:underline">Del</button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
            {filteredVariants.length === 0 && <p className="text-center text-gray-400 py-8">No variants match the selected filters</p>}
          </>
        ) : (
          <div className="flex items-center justify-center h-full text-gray-400">Select a model to view variants</div>
        )}
      </div>

      {showModelModal && (
        <ModelForm model={editingModel} onSave={handleModelSave} onCancel={() => { setShowModelModal(false); setEditingModel(null); }} />
      )}
      {showVariantModal && (
        <VariantForm variant={editingVariant} onSave={handleVariantSave} onCancel={() => { setShowVariantModal(false); setEditingVariant(null); }} />
      )}
    </div>
  );
};
