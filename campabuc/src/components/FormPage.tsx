import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Button } from '@/components/ui/button';

type FormField<T> = {
	key: keyof T;
	label: string;
	type?: 'text' | 'number' | 'select';
	options?: { label: string; value: any }[];
};

type FormPageProps<T> = {
	title: string;
	fields: FormField<T>[];
	basePath: string;
	loadItem: (id: string) => Promise<T>;
	saveItem: (item: Partial<T>) => Promise<void>;
};

export function FormPage<T>({ title, fields, basePath, loadItem, saveItem }: FormPageProps<T>) {
	const { id } = useParams();
	const navigate = useNavigate();
	const [item, setItem] = useState<Partial<T>>({});

	useEffect(() => {
		if (id !== 'new') {
			loadItem(id!).then(setItem);
		}
	}, [id]);

	const handleChange = (key: keyof T, value: any) => {
		setItem((prev) => ({ ...prev, [key]: value }));
	};

	const handleSubmit = async () => {
		await saveItem(item);
		navigate(basePath);
	};

	return (
		<div className="p-4">
			<h1 className="text-xl font-bold mb-4">{title}</h1>
			<div className="grid gap-4">
				{fields.map((field) => (
					<div key={String(field.key)}>
						<label className="block mb-1 font-medium">{field.label}</label>
						{field.type === 'select' ? (
							<select
								value={item[field.key] as any}
								onChange={(e) => handleChange(field.key, e.target.value)}
								className="border p-2 w-full"
							>
								{field.options?.map((opt) => (
									<option key={opt.value} value={opt.value}>{opt.label}</option>
								))}
							</select>
						) : (
							<input
								type={field.type || 'text'}
								value={item[field.key] as any || ''}
								onChange={(e) => handleChange(field.key, e.target.value)}
								className="border p-2 w-full"
							/>
						)}
					</div>
				))}
				<Button onClick={handleSubmit}>Save</Button>
			</div>
		</div>
	);
}
