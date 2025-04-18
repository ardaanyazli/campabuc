import React from 'react';
import { invoke } from "@tauri-apps/api/core";
import ReactDOM from 'react-dom/client';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import MainLayout from './layout/MainLayout';

// Module routes
import ManufacturersModule from './modules/manufacturers/ManufacturersModule';
import ColorsModule from './modules/colors/ColorsModule';
import SizesModule from './modules/sizes/SizesModule';
import MaterialsModule from './modules/materials/MaterialsModule';
import ShoesModule from './modules/shoes/ShoesModule';
import OrdersModule from './modules/orders/OrdersModule';

export default function App() {
	return (
		<Router>
			<Routes>
				<Route path="/" element={<MainLayout />}>
					<Route path="manufacturers/*" element={<ManufacturersModule />} />
					<Route path="colors/*" element={<ColorsModule />} />
					<Route path="sizes/*" element={<SizesModule />} />
					<Route path="materials/*" element={<MaterialsModule />} />
					<Route path="shoes/*" element={<ShoesModule />} />
					<Route path="orders/*" element={<OrdersModule />} />
				</Route>
			</Routes>
		</Router>
	);
}
