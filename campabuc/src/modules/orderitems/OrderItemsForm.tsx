import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getOrderItemById, saveOrderItem } from '../../services/orderItems';
import { v4 as uuidv4 } from 'uuid';

export default function OrderItemsForm() {
	const navigate = useNavigate();
	const { id } = useParams();
	const [form, setForm] = useState<any>({ order: '', shoe: '', quantity: '', discount: '', status: 'pending' });

	useEffect(() => {
		if (id) getOrderItemById(id).then(setForm);
	}, [id]);

	function handleChange(e: any) {
		setForm({ ...form, [e.target.name]: e.target.value });
	}

	async function handleSubmit(e: any) {
		e.preventDefault();
		const finalData = { ...form, id: id || uuidv4() };
		await saveOrderItem(finalData);
		navigate('/orderItems');
	}

	return (
		<form onSubmit={handleSubmit}>
			<h1>{id ? 'Edit Order Item' : 'New Order Item'}</h1>
			<input name="order" placeholder="Order ID" value={form.order} onChange={handleChange} />
			<input name="shoe" placeholder="Shoe ID" value={form.shoe} onChange={handleChange} />
			<input name="quantity" placeholder="Quantity" value={form.quantity} onChange={handleChange} />
			<input name="discount" placeholder="Discount" value={form.discount} onChange={handleChange} />
			<input name="status" placeholder="Status" value={form.status} onChange={handleChange} />
			<button type="submit">Save</button>
		</form>
	);
}

