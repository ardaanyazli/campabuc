import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getOrderById, saveOrder } from '../../services/orders';
import { v4 as uuidv4 } from 'uuid';

export default function OrdersForm() {
	const navigate = useNavigate();
	const { id } = useParams();
	const [form, setForm] = useState<any>({ status: 'pending' });

	useEffect(() => {
		if (id) getOrderById(id).then(setForm);
	}, [id]);

	function handleChange(e: any) {
		setForm({ ...form, [e.target.name]: e.target.value });
	}

	async function handleSubmit(e: any) {
		e.preventDefault();
		const finalData = { ...form, id: id || uuidv4() };
		await saveOrder(finalData);
		navigate('/orders');
	}

	return (
		<form onSubmit={handleSubmit}>
			<h1>{id ? 'Edit Order' : 'New Order'}</h1>
			<input name="status" placeholder="Status" value={form.status} onChange={handleChange} />
			<button type="submit">Save</button>
		</form>
	);
}

