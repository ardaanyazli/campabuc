import React, { useState, useEffect } from 'react';
import { api } from '../api/client';
import { ShoeVariant } from '../types';

export const ReportsView: React.FC = () => {
  const [variants, setVariants] = useState<ShoeVariant[]>([]);
  const [selectedVariant, setSelectedVariant] = useState<number | null>(null);
  const [margin, setMargin] = useState<number | null>(null);
  const [agingData, setAgingData] = useState<any[]>([]);
  const [salesTotal, setSalesTotal] = useState<number | null>(null);
  const [dateRange, setDateRange] = useState({ start: '', end: '' });
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    loadInitialData();
  }, []);

  const loadInitialData = async () => {
    try {
      const [varRes, ageRes] = await Promise.all([
        api.shoeVariants.getAll(),
        api.reports.getAgingReport()
      ]);
      setVariants(varRes.data);
      setAgingData(ageRes.data);
    } catch (e) {
      console.error("Error loading reports data", e);
    }
  };

  const checkMargin = async (id: number) => {
    setSelectedVariant(id);
    try {
      const res = await api.reports.getProfitMargin(id);
      setMargin(res.data);
    } catch (e) {
        console.error("Margin fetch error", e);
    }
  };

  const fetchSalesSummary = async () => {
    if (!dateRange.start || !dateRange.end) return;
    setIsLoading(true);
    try {
      const res = await api.reports.getSalesSummary(dateRange.start, dateRange.end);
      setSalesTotal(res.data);
    } catch (e) {
      console.error("Sales summary error", e);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="space-y-8">
      {/* Profit Margin Analysis */}
      <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-200">
        <h2 className="text-xl font-bold mb-4 text-slate-800">Profit Margin Analysis</h2>
        <div className="flex gap-4 items-end">
          <div className="flex-1">
            <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Select Variant</label>
            <select 
              className="w-full px-3 py-2 border rounded-md outline-none focus:ring-2 focus:ring-blue-500"
              onChange={(e) => checkMargin(Number(e.target.value))}
              value={selectedVariant || ''}
            >
              <option value="">-- Select a Variant --</option>
              {variants.map(v => <option key={v.id} value={v.id}>{v.skuCode} ({v.color} - {v.size})</option>)}
            </select>
          </div>
          <div className="w-48 text-right">
            <div className="text-sm text-gray-500">Actual Margin</div>
            <div className="text-3xl font-black text-green-600">${margin?.toFixed(2) || '0.00'}</div>
          </div>
        </div>
      </div>

      {/* Inventory Aging */}
      <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-200">
        <h2 className="text-xl font-bold mb-4 text-slate-800">Inventory Aging Report</h2>
        <div className="overflow-auto max-h-80">
          <table className="w-full text-left border-collapse">
            <thead>
              <tr className="text-gray-400 text-sm border-b">
                <th className="py-2">SKU</th>
                <th className="py-2">Stock Level</th>
                <th className="py-2">Received Date</th>
                <th className="py-2">Status</th>
              </tr>
            </thead>
            <tbody>
              {agingData.map((item, idx) => (
                <tr key={idx} className="border-b hover:bg-gray-50">
                  <td className="py-3 font-mono text-sm">{item.Label}</td>
                  <td className="py-3">{item.Value}</td>
                  <td className="py-3 text-sm text-gray-500">{item.Date}</td>
                  <td className="py-3">
                    <span className={`px-2 py-1 rounded-full text-xs ${item.Value < 5 ? 'bg-red-100 text-red-700' : 'bg-green-100 text-green-700'}`}>
                      {item.Value < 5 ? 'Slow Moving' : 'Healthy'}
                    </span>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      {/* On-Demand Sales Summary */}
      <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-200">
        <h2 className="text-xl font-bold mb-4 text-slate-800">Sales Performance Summary</h2>
        <div className="flex flex-wrap gap-4 items-end">
          <div className="flex-1 min-w-[200px]">
            <label className="block text-xs font-bold text-gray-400 uppercase mb-1">Start Date</label>
            <input 
              type="date" 
              className="w-full px-3 py-2 border rounded-md outline-none focus:ring-2 focus:ring-blue-500" 
              value={dateRange.start}
              onChange={(e) => setDateRange(prev => ({ ...prev, start: e.target.value }))}
            />
          </div>
          <div className="flex-1 min-w-[200px]">
            <label className="block text-xs font-bold text-gray-400 uppercase mb-1">End Date</label>
            <input 
              type="date" 
              className="w-full px-3 py-2 border rounded-md outline-none focus:ring-2 focus:ring-blue-500" 
              value={dateRange.end}
              onChange={(e) => setDateRange(prev => ({ ...prev, end: e.target.value }))}
            />
          </div>
          <button 
            onClick={fetchSalesSummary}
            disabled={isLoading}
            className="px-6 py-2 bg-indigo-600 text-white rounded-md hover:bg-indigo-700 disabled:bg-indigo-300 transition"
          >
            {isLoading ? 'Calculating...' : 'Generate Report'}
          </button>
          <div className="flex-1 text-right">
            <div className="text-sm text-gray-500">Total Sales</div>
            <div className="text-3xl font-black text-indigo-600">${salesTotal?.toFixed(2) || '0.00'}</div>
          </div>
        </div>
      </div>
    </div>
  );
};
