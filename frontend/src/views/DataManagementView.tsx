import React, { useState } from 'react';
import { api } from '../api/client';

export const DataManagementView: React.FC = () => {
  const [exportPath, setExportPath] = useState('');
  const [importPath, setImportPath] = useState('');
  const [status, setStatus] = useState<string | null>(null);
  const [isLoading, setIsLoading] = useState(false);

  const handleExport = async () => {
    setIsLoading(true);
    try {
      await api.dataManagement.exportDb(exportPath);
      setStatus('Database exported successfully!');
    } catch (e) {
      setStatus('Export failed. Please check the path.');
    } finally {
      setIsLoading(false);
    }
  };

  const handleImport = async () => {
    setIsLoading(true);
    try {
      await api.dataManagement.importDb(importPath);
      setStatus('Database imported successfully!');
    } catch (e) {
      setStatus('Import failed. Please check the file path.');
    } finally {
      setIsLoading(false);
    }
  };

  const handleBackup = async () => {
    setIsLoading(true);
    try {
      await api.dataManagement.backupCloud();
      setStatus('Cloud backup triggered successfully!');
    } catch (e) {
      setStatus('Cloud backup failed.');
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="max-w-2xl mx-auto space-y-8">
      <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-200">
        <h2 className="text-xl font-bold mb-4 text-slate-800">Local Data Portability</h2>
        <p className="text-sm text-gray-500 mb-6">Export your entire database to a portable JSON file or restore from a backup.</p>
        
        <div className="space-y-4">
          <div>
            <label className="block text-sm font-medium text-gray-700 mb-1">Export Path</label>
            <div className="flex gap-2">
              <input 
                type="text" 
                className="flex-1 px-3 py-2 border rounded-md focus:ring-2 focus:ring-blue-500 outline-none" 
                placeholder="C:\backups\export.json"
                value={exportPath}
                onChange={(e) => setExportPath(e.target.value)}
              />
              <button 
                onClick={handleExport} 
                disabled={isLoading}
                className="px-4 py-2 bg-blue-600 text-white rounded-md hover:bg-blue-700 disabled:bg-blue-300 transition"
              >
                Export
              </button>
            </div>
          </div>

          <div>
            <label className="block text-sm font-medium text-gray-700 mb-1">Import Path</label>
            <div className="flex gap-2">
              <input 
                type="text" 
                className="flex-1 px-3 py-2 border rounded-md focus:ring-2 focus:ring-blue-500 outline-none" 
                placeholder="C:\backups\restore.json"
                value={importPath}
                onChange={(e) => setImportPath(e.target.value)}
              />
              <button 
                onClick={handleImport} 
                disabled={isLoading}
                className="px-4 py-2 bg-slate-600 text-white rounded-md hover:bg-slate-700 disabled:bg-slate-300 transition"
              >
                Import
              </button>
            </div>
          </div>
        </div>
      </div>

      <div className="bg-white p-6 rounded-lg shadow-sm border border-gray-200">
        <h2 className="text-xl font-bold mb-4 text-slate-800">Cloud Reliability</h2>
        <p className="text-sm text-gray-500 mb-6">Trigger a manual sync to ensure your data is backed up to the cloud provider.</p>
        <button 
          onClick={handleBackup} 
          disabled={isLoading}
          className="w-full py-3 bg-indigo-600 text-white rounded-md hover:bg-indigo-700 disabled:bg-indigo-300 transition font-medium"
        >
          🚀 Trigger Cloud Backup
        </button>
      </div>

      {status && (
        <div className={`p-4 rounded-md text-center font-medium ${status.includes('failed') ? 'bg-red-100 text-red-700' : 'bg-green-100 text-green-700'}`}>
          {status}
        </div>
      )}
    </div>
  );
};
