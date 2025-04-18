import { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getColorById, saveColor } from '../../services/colors';

export default function ColorsForm() {
	const navigate = useNavigate();
	const { id } = useParams();
	const [form, setForm] = useState<any>({ name: '' });

	useEffect(() => {
		if (id) getColorById(Number(id)).then(setForm);
	}, [id]);

	function handleChange(e: any) {
		setForm({ ...form, [e.target.name]: e.target.value });
	}

	async function handleSubmit(e: any) {
		e.preventDefault();
		const finalData = { ...form, id: id ? Number(id) : undefined };
		await saveColor(finalData);
		navigate('/colors');
	}

	return (
		<form onSubmit={handleSubmit}>
			<h1>{id ? 'Edit Color' : 'New Color'}</h1>
			<input name="name" placeholder="Name" value={form.name} onChange={handleChange} />
			<button type="submit">Save</button>
		</form>
	);
}
