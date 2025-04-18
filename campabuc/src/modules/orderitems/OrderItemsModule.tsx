import { Routes, Route } from 'react-router-dom';
import OrderItemsList from './OrderItemsList';
import OrderItemsForm from './OrderItemsForm';

export default function OrderItemsModule() {
	return (
		<Routes>
			<Route path="" element={<OrderItemsList />} />
			<Route path=":id" element={<OrderItemsForm />} />
			<Route path="new" element={<OrderItemsForm />} />
		</Routes>
	);
}

