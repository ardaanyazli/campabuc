import React from 'react';

interface LayoutProps {
  children: React.ReactNode;
  title: string;
  activeTab: string;
  setActiveTab: (tab: string) => void;
}

export const Layout: React.FC<LayoutProps> = ({ children, title, activeTab, setActiveTab }) => {
  const tabs = [
    { id: 'inventory', label: '📦 Inventory', desc: 'Models & Variants' },
    { id: 'checkout', label: '🛒 Checkout', desc: 'Sales & Pricing' },
    { id: 'reports', label: '📊 Reports', desc: 'Analytics & BI' },
    { id: 'purchase-orders', label: '📋 POrders', desc: 'Purchasing' },
    { id: 'adjustments', label: '🔧 Adjust', desc: 'Claims & Loss' },
    { id: 'history', label: '🧾 History', desc: 'Transactions' },
    { id: 'data', label: '💾 Data', desc: 'Backup & Portability' },
  ];

  return (
    <div className="flex h-screen bg-gray-100 text-gray-900 font-sans">
      <aside className="w-64 bg-slate-900 text-white flex flex-col">
        <div className="p-6 text-2xl font-bold border-b border-slate-700">CamPabuc v2</div>
        <nav className="flex-1 p-4 space-y-1">
          {tabs.map(tab => (
            <button
              key={tab.id}
              onClick={() => setActiveTab(tab.id)}
              className={`w-full text-left px-4 py-2 rounded transition flex justify-between items-center ${activeTab === tab.id ? 'bg-blue-600 text-white' : 'text-gray-300 hover:bg-slate-800 hover:text-white'}`}
            >
              <span>{tab.label}</span>
              <span className="text-[10px] opacity-60">{tab.desc}</span>
            </button>
          ))}
        </nav>
      </aside>

      <main className="flex-1 flex flex-col overflow-hidden">
        <header className="h-14 bg-white shadow-sm flex items-center px-8 border-b">
          <h1 className="text-lg font-semibold text-slate-700">{title}</h1>
        </header>
        <div className="p-6 overflow-auto h-full">{children}</div>
      </main>
    </div>
  );
};
