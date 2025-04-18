import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getSizeById, saveSize } from '../../services/sizes';

export default function SizesForm() {
	const navigate = useNavigate();
	const { id } = useParams();
	const [form, setForm] = useState<any>({ name: '' });

	useEffect(() => {
		if (id) getSizeById(Number(id)).then(setForm);
	}, [id]);

	function handleChange(e: any) {
		setForm({ ...form, [e.target.name]: e.target.value });
	}

	async function handleSubmit(e: any) {
		e.preventDefault();
		const finalData = { ...form, id: id ? Number(id) : undefined };
		await saveSize(finalData);
		navigate('/sizes');
	}

	return (
		<form onSubmit={handleSubmit}>
			<h1>{id ? 'Edit Size' : 'New Size'}</h1>
			<input name="name" placeholder="Name" value={form.name} onChange={handleChange} />
			<button type="submit">Save</button>
		</form>
	);
}
