import { Routes, Route } from 'react-router-dom';
import ShoesList from './ShoesList';
import ShoesForm from './ShoesForm';

export default function ShoesModule() {
	return (
		<Routes>
			<Route path="" element={<ShoesList />} />
			<Route path=":id" element={<ShoesForm />} />
			<Route path="new" element={<ShoesForm />} />
		</Routes>
	);
}

