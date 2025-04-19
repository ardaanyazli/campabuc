import { useEffect, useState } from 'react';
import { getManufacturers, deleteManufacturer } from '../../services/manufacturers';
import { Link } from 'react-router-dom';
import { CircleUser, LucideTrash2, Phone } from 'lucide-react';
import { Button } from '@/components/ui/button';
import { Card } from '@/components/ui/card';

export default function ManufacturersList() {
	const [manufacturers, setManufacturers] = useState<any[]>([]);

	useEffect(() => {
		getManufacturers().then(data =>
			setManufacturers(data));
	}, []);

	const handleDelete = async function handleDelete(id: number) {
		if (confirm("Are you sure?")) {
			await deleteManufacturer(id);
			setManufacturers(await getManufacturers())
		}
	}

	return (
		<div>
			<Card className="p-1 items-center m-4">Manufacturers</Card>
			<Button><Link to="/manufacturers/new">+ New Manufacturer</Link></Button>
			<ul className="space-y-2 mt-4">
				{manufacturers.map((manufacturer) => (
					<li key={manufacturer.id} className="flex items-center justify-between border p-2 rounded shadow-sm">
						<Link to={`/manufacturers/${manufacturer.id}`} className="flex-1 text-blue-900">
							<>
								{manufacturer.name}
								{manufacturer.phone && <> <Phone size={15} className="shrink-0 inline-block" />-{manufacturer.phone}</>}
								{manufacturer.contact_name && <> <CircleUser size={15} className="shrink-0 inline-block" />-{manufacturer.contact_name}</>}
							</>
						</Link>
						<button
							onClick={() => handleDelete(manufacturer.id)}
							className="ml-4 text-red-500 hover:text-red-700"
						>
							<LucideTrash2 size={18} className="shrink-0" />

						</button>
					</li>
				))}
			</ul>
		</div>
	);
}
