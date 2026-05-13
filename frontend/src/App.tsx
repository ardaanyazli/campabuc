import { useState } from 'react';
import { Layout } from './components/Layout';
import { DataManagementView } from './views/DataManagementView';
import { CheckoutView } from './views/CheckoutView';
import { ReportsView } from './views/ReportsView';
import { InventoryView } from './views/InventoryView';
import { PurchaseOrderView } from './views/PurchaseOrderView';
import { StockAdjustmentView } from './views/StockAdjustmentView';
import { TransactionHistoryView } from './views/TransactionHistoryView';

const titles: Record<string, string> = {
  inventory: 'Inventory Management',
  checkout: 'Checkout System',
  reports: 'Business Intelligence',
  'purchase-orders': 'Purchase Orders',
  adjustments: 'Stock Adjustments',
  history: 'Transaction History',
  data: 'Data Management',
};

function App() {
  const [activeTab, setActiveTab] = useState('inventory');

  return (
    <Layout title={titles[activeTab] || 'CamPabuc Store'} activeTab={activeTab} setActiveTab={setActiveTab}>
      {activeTab === 'inventory' && <InventoryView />}
      {activeTab === 'checkout' && <CheckoutView />}
      {activeTab === 'reports' && <ReportsView />}
      {activeTab === 'purchase-orders' && <PurchaseOrderView />}
      {activeTab === 'adjustments' && <StockAdjustmentView />}
      {activeTab === 'history' && <TransactionHistoryView />}
      {activeTab === 'data' && <DataManagementView />}
    </Layout>
  );
}

export default App;
