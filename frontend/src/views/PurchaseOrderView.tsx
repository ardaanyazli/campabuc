import React, { useState, useEffect } from 'react';
import { api } from '../api/client';

interface PO {
  id: number;
  manufacturerId: number;
  orderDate: string;
  expectedDate: string;
  status: string;
  items?: POItem[];
}

interface POItem {
  shoeVariantId: number;
  quantityOrdered: number;
  quantityReceived: number;
}

export const PurchaseOrderView: React.FC = () => {
  const [orders, setOrders] = useState<PO[]>([]);
  const [manufacturers, setManufacturers] = useState<any[]>([]);
  const [variants, setVariants] = useState<any[]>([]);
  const [selectedPO, setSelectedPO] = useState<PO | null>(null);
  const [showForm, setShowForm] = useState(false);
  const [form, setForm] = useState({ manufacturerId: 0, orderDate: '', expectedDate: '', items: [{ shoeVariantId: 0, quantityOrdered: 0, quantityReceived: 0 }] });

  useEffect(() => {
    Promise.all([
      api.purchaseOrders.getAll().then(r => setOrders(r.data)),
      api.manufacturers.getAll().then(r => setManufacturers(r.data)),
      api.shoeVariants.getAll().then(r => setVariants(r.data)),
    ]);
  }, []);

  const refresh = async () => {
    const res = await api.purchaseOrders.getAll();
    setOrders(res.data);
  };

  const createPO = async () => {
    await api.purchaseOrders.create(form);
    setShowForm(false);
    setForm({ manufacturerId: 0, orderDate: '', expectedDate: '', items: [{ shoeVariantId: 0, quantityOrdered: 0, quantityReceived: 0 }] });
    refresh();
  };

  const processPO = async (id: number) => {
    await api.inventory.processPO(id);
    refresh();
  };

  const addItem = () => setForm(prev => ({ ...prev, items: [...prev.items, { shoeVariantId: 0, quantityOrdered: 0, quantityReceived: 0 }] }));
  const updateItem = (idx: number, field: string, value: any) => {
    const items = [...form.items];
    items[idx] = { ...items[idx], [field]: value };
    setForm(prev => ({ ...prev, items }));
  };

  return (
    <div className="grid grid-cols-3 gap-6 h-full">
      <div className="col-span-1 bg-white p-4 rounded-lg shadow overflow-auto">
        <div className="flex justify-between items-center mb-4">
          <h2 className="text-lg font-bold">Purchase Orders</h2>
          <button onClick={() => setShowForm(!showForm)} className="px-3 py-1 bg-blue-600 text-white rounded text-sm">+ New PO</button>
        </div>
        {orders.map(po => (
          <div key={po.id} onClick={() => setSelectedPO(po)} className={`p-3 rounded cursor-pointer mb-2 ${selectedPO?.id === po.id ? 'bg-blue-100 border-l-4 border-blue-600' : 'hover:bg-gray-100'}`}>
            <div className="font-medium">PO #{po.id}</div>
            <div className="text-xs text-gray-500">Status: {po.status} — {po.orderDate}</div>
          </div>
        ))}
      </div>

      <div className="col-span-2 bg-white p-4 rounded-lg shadow overflow-auto">
        {showForm ? (
          <div className="space-y-4">
            <h3 className="text-xl font-bold">New Purchase Order</h3>
            <div className="grid grid-cols-3 gap-4">
              <div>
                <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Manufacturer</label>
                <select className="w-full px-3 py-2 border rounded-md" value={form.manufacturerId} onChange={e => setForm(prev => ({ ...prev, manufacturerId: Number(e.target.value) }))}>
                  <option value={0}>Select</option>
                  {manufacturers.map(m => <option key={m.id} value={m.id}>{m.name}</option>)}
                </select>
              </div>
              <div>
                <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Order Date</label>
                <input type="date" className="w-full px-3 py-2 border rounded-md" value={form.orderDate} onChange={e => setForm(prev => ({ ...prev, orderDate: e.target.value }))} />
              </div>
              <div>
                <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Expected Date</label>
                <input type="date" className="w-full px-3 py-2 border rounded-md" value={form.expectedDate} onChange={e => setForm(prev => ({ ...prev, expectedDate: e.target.value }))} />
              </div>
            </div>

            <div className="border-t pt-4">
              <div className="flex justify-between items-center mb-2">
                <h4 className="font-bold text-sm uppercase text-gray-500">Items</h4>
                <button onClick={addItem} className="text-xs text-blue-600">+ Add Item</button>
              </div>
              {form.items.map((item, idx) => (
                <div key={idx} className="grid grid-cols-3 gap-4 mb-2 bg-gray-50 p-3 rounded">
                  <select className="px-3 py-2 border rounded-md text-sm" value={item.shoeVariantId} onChange={e => updateItem(idx, 'shoeVariantId', Number(e.target.value))}>
                    <option value={0}>Select Variant</option>
                    {variants.map(v => <option key={v.id} value={v.id}>{v.skuCode}</option>)}
                  </select>
                  <input type="number" placeholder="Qty Ordered" className="px-3 py-2 border rounded-md text-sm" value={item.quantityOrdered || ''} onChange={e => updateItem(idx, 'quantityOrdered', Number(e.target.value))} />
                  <input type="number" placeholder="Qty Received" className="px-3 py-2 border rounded-md text-sm" value={item.quantityReceived || ''} onChange={e => updateItem(idx, 'quantityReceived', Number(e.target.value))} />
                </div>
              ))}
            </div>

            <button onClick={createPO} className="px-4 py-2 bg-blue-600 text-white rounded hover:bg-blue-700">Save Purchase Order</button>
          </div>
        ) : selectedPO ? (
          <div>
            <div className="flex justify-between items-center mb-6">
              <div>
                <h2 className="text-2xl font-bold">PO #{selectedPO.id}</h2>
                <p className="text-sm text-gray-500">Status: <span className="font-medium">{selectedPO.status}</span> — Ordered: {selectedPO.orderDate} — Expected: {selectedPO.expectedDate}</p>
              </div>
              {selectedPO.status !== 'Received' && (
                <button onClick={() => processPO(selectedPO.id)} className="px-4 py-2 bg-green-600 text-white rounded hover:bg-green-700">Receive Stock</button>
              )}
            </div>
            <table className="w-full text-left border-collapse">
              <thead className="text-gray-400 text-sm border-b">
                <tr>
                  <th className="py-2">Variant ID</th>
                  <th className="py-2">Ordered</th>
                  <th className="py-2">Received</th>
                  <th className="py-2">Discrepancy</th>
                </tr>
              </thead>
              <tbody>
                {(selectedPO.items || []).map((i, idx) => (
                  <tr key={idx} className="border-b hover:bg-gray-50">
                    <td className="py-3">{i.shoeVariantId}</td>
                    <td className="py-3">{i.quantityOrdered}</td>
                    <td className="py-3">{i.quantityReceived}</td>
                    <td className="py-3">
                      <span className={i.quantityOrdered !== i.quantityReceived ? 'text-red-600 font-medium' : 'text-green-600'}>
                        {i.quantityOrdered - i.quantityReceived}
                      </span>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        ) : (
          <div className="flex items-center justify-center h-full text-gray-400">Select an order to view details</div>
        )}
      </div>
    </div>
  );
};
