import { Routes, Route } from 'react-router-dom';
import ManufacturersList from './ManufacturersList';
import ManufacturersForm from './ManufacturersForm';

export default function ManufacturersModule() {
	return (
		<Routes>
			<Route path="" element={<ManufacturersList />} />
			<Route path=":id" element={<ManufacturersForm />} />
			<Route path="new" element={<ManufacturersForm />} />
		</Routes>
	);
}
