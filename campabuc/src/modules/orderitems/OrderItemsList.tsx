import { useEffect, useState } from 'react';
import { getOrderItems, loadOrderItems } from '../../services/orderItems';
import { Link } from 'react-router-dom';

export default function OrderItemsList() {
	const [orderItems, setOrderItems] = useState<any[]>([]);

	useEffect(() => {
		loadOrderItems().then(() => setOrderItems(getOrderItems()));
	}, []);

	return (
		<div>
			<h1>Order Items</h1>
			<Link to="/orderItems/new">+ New Order Item</Link>
			<ul>
				{orderItems.map((item) => (
					<li key={item.id}>
						<Link to={`/orderItems/${item.id}`}>{`#${item.id} | Order #${item.order} | Shoe #${item.shoe} | Quantity: ${item.quantity}`}</Link>
					</li>
				))}
			</ul>
		</div>
	);
}

