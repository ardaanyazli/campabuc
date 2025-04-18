import { Routes, Route } from 'react-router-dom';
import ColorsList from './ColorsList';
import ColorsForm from './ColorsForm';

export default function ColorsModule() {
	return (
		<Routes>
			<Route path="" element={<ColorsList />} />
			<Route path=":id" element={<ColorsForm />} />
			<Route path="new" element={<ColorsForm />} />
		</Routes>
	);
}
