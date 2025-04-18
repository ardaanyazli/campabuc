import { Routes, Route } from 'react-router-dom';
import MaterialsList from './MaterialsList';
import MaterialsForm from './MaterialsForm';

export default function MaterialsModule() {
	return (
		<Routes>
			<Route path="" element={<MaterialsList />} />
			<Route path=":id" element={<MaterialsForm />} />
			<Route path="new" element={<MaterialsForm />} />
		</Routes>
	);
}
