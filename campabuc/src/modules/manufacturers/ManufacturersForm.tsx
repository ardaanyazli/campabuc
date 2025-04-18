import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getManufacturerById, saveManufacturer } from '../../services/manufacturers';

export default function ManufacturersForm() {
	const navigate = useNavigate();
	const { id } = useParams();
	const [form, setForm] = useState<any>({
		name: '',
		address: '',
		phone: '',
		contact_name: '',
	});

	useEffect(() => {
		if (id) getManufacturerById(Number(id)).then(setForm);
	}, [id]);

	function handleChange(e: any) {
		setForm({ ...form, [e.target.name]: e.target.value });
	}

	async function handleSubmit(e: any) {
		e.preventDefault();
		const finalData = { ...form, id: id ? Number(id) : undefined };
		await saveManufacturer(finalData);
		navigate('/manufacturers');
	}

	return (
		<form onSubmit={handleSubmit}>
			<h1>{id ? 'Edit Manufacturer' : 'New Manufacturer'}</h1>
			<input name="name" placeholder="Name" value={form.name} onChange={handleChange} />
			<input name="address" placeholder="Address" value={form.address} onChange={handleChange} />
			<input name="phone" placeholder="Phone" value={form.phone} onChange={handleChange} />
			<input name="contact_name" placeholder="Contact Name" value={form.contact_name} onChange={handleChange} />
			<button type="submit">Save</button>
		</form>
	);
}
