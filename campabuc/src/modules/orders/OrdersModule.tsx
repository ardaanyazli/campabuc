import { Routes, Route } from 'react-router-dom';
import OrdersList from './OrdersList';
import OrdersForm from './OrdersForm';

export default function OrdersModule() {
	return (
		<Routes>
			<Route path="" element={<OrdersList />} />
			<Route path=":id" element={<OrdersForm />} />
			<Route path="new" element={<OrdersForm />} />
		</Routes>
	);
}

