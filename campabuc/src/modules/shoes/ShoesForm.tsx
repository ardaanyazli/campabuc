import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getShoeById, saveShoe } from '../../services/shoes';

export default function ShoesForm() {
	const navigate = useNavigate();
	const { id } = useParams();
	const [form, setForm] = useState<any>({ color: '', size: '', material: '', price: '', inventory: '', barcode: '' });

	useEffect(() => {
		if (id) getShoeById(id).then(setForm);
	}, [id]);

	function handleChange(e: any) {
		setForm({ ...form, [e.target.name]: e.target.value });
	}

	async function handleSubmit(e: any) {
		e.preventDefault();
		await saveShoe({ ...form, id });
		navigate('/shoes');
	}

	return (
		<form onSubmit={handleSubmit}>
			<h1>{id ? 'Edit Shoe' : 'New Shoe'}</h1>
			<input name="color" placeholder="Color ID" value={form.color} onChange={handleChange} />
			<input name="size" placeholder="Size ID" value={form.size} onChange={handleChange} />
			<input name="material" placeholder="Material ID" value={form.material} onChange={handleChange} />
			<input name="price" placeholder="Price" value={form.price} onChange={handleChange} />
			<input name="inventory" placeholder="Inventory" value={form.inventory} onChange={handleChange} />
			<input name="barcode" placeholder="Barcode" value={form.barcode} onChange={handleChange} />
			<button type="submit">Save</button>
		</form>
	);
}

