import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getMaterialById, saveMaterial } from '../../services/materials';

export default function MaterialsForm() {
	const navigate = useNavigate();
	const { id } = useParams();
	const [form, setForm] = useState<any>({ name: '' });

	useEffect(() => {
		if (id) getMaterialById(Number(id)).then(setForm);
	}, [id]);

	function handleChange(e: any) {
		setForm({ ...form, [e.target.name]: e.target.value });
	}

	async function handleSubmit(e: any) {
		e.preventDefault();
		const finalData = { ...form, id: id ? Number(id) : undefined };
		await saveMaterial(finalData);
		navigate('/materials');
	}

	return (
		<form onSubmit={handleSubmit}>
			<h1>{id ? 'Edit Material' : 'New Material'}</h1>
			<input name="name" placeholder="Name" value={form.name} onChange={handleChange} />
			<button type="submit">Save</button>
		</form>
	);
}
