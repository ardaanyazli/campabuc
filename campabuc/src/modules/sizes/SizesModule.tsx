import { Routes, Route } from 'react-router-dom';
import SizesList from './SizesList';
import SizesForm from './SizesForm';

export default function SizesModule() {
	return (
		<Routes>
			<Route path="" element={<SizesList />} />
			<Route path=":id" element={<SizesForm />} />
			<Route path="new" element={<SizesForm />} />
		</Routes>
	);
}
