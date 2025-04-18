import { useEffect, useState } from 'react';
import { getOrders, loadOrders } from '../../services/orders';
import { Link } from 'react-router-dom';

export default function OrdersList() {
	const [orders, setOrders] = useState<any[]>([]);

	useEffect(() => {
		loadOrders().then(() => setOrders(getOrders()));
	}, []);

	return (
		<div>
			<h1>Orders</h1>
			<Link to="/orders/new">+ New Order</Link>
			<ul>
				{orders.map((order) => (
					<li key={order.id}>
						<Link to={`/orders/${order.id}`}>{`#${order.id} | ${order.status}`}</Link>
					</li>
				))}
			</ul>
		</div>
	);
}

