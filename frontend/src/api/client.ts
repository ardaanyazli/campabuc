import axios from 'axios';

const API_BASE_URL = 'http://localhost:5109/api';

const apiClient = axios.create({
  baseURL: API_BASE_URL,
  headers: { 'Content-Type': 'application/json' },
});

export const api = {
  shoeModels: {
    getAll: () => apiClient.get('/ShoeModels'),
    getOne: (id: number) => apiClient.get(`/ShoeModels/${id}`),
    create: (data: any) => apiClient.post('/ShoeModels', data),
    update: (model: any) => apiClient.put('/ShoeModels', model),
    delete: (id: number) => apiClient.delete(`/ShoeModels/${id}`),
  },
  shoeVariants: {
    getAll: () => apiClient.get('/ShoeVariants'),
    getByModel: (modelId: number) => apiClient.get(`/ShoeVariants/model/${modelId}`),
    create: (data: any) => apiClient.post('/ShoeVariants', data),
    update: (variant: any) => apiClient.put('/ShoeVariants', variant),
    delete: (id: number) => apiClient.delete(`/ShoeVariants/${id}`),
  },
  manufacturers: {
    getAll: () => apiClient.get('/Manufacturers'),
    getOne: (id: number) => apiClient.get(`/Manufacturers/${id}`),
  },
  shoeCategories: {
    getAll: () => apiClient.get('/ShoeCategories'),
  },
  purchaseOrders: {
    getAll: () => apiClient.get('/PurchaseOrders'),
    getOne: (id: number) => apiClient.get(`/PurchaseOrders/${id}`),
    create: (data: any) => apiClient.post('/PurchaseOrders', data),
    update: (po: any) => apiClient.put('/PurchaseOrders', po),
    delete: (id: number) => apiClient.delete(`/PurchaseOrders/${id}`),
  },
  sales: {
    getAll: () => apiClient.get('/Sales'),
    getOne: (id: number) => apiClient.get(`/Sales/${id}`),
  },
  inventory: {
    processPO: (poId: number) => apiClient.post(`/Inventory/process-po/${poId}`),
    processSale: (saleId: number) => apiClient.post(`/Inventory/process-sale/${saleId}`),
    adjustStock: (data: any) => apiClient.post('/Inventory/adjust', data),
  },
  checkout: {
    calculate: (data: any) => apiClient.post('/Checkout/calculate', data),
    finalize: (sale: any) => apiClient.post('/Checkout/finalize', sale),
  },
  reports: {
    getProfitMargin: (variantId: number) => apiClient.get(`/Reports/profit-margin/${variantId}`),
    getAgingReport: () => apiClient.get('/Reports/inventory-aging'),
    getSalesSummary: (start: string, end: string) => apiClient.get(`/Reports/sales-summary?start=${start}&end=${end}`),
  },
  dataManagement: {
    exportDb: (filePath: string) => apiClient.post('/DataManagement/export', { filePath }),
    importDb: (filePath: string) => apiClient.post('/DataManagement/import', { filePath }),
    backupCloud: () => apiClient.post('/DataManagement/backup'),
  }
};
