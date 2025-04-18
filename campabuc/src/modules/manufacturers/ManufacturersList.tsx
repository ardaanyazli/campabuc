import { useEffect, useState } from 'react';
import { getManufacturers, loadManufacturers } from '../../services/manufacturers';
import { Link } from 'react-router-dom';

export default function ManufacturersList() {
	const [manufacturers, setManufacturers] = useState<any[]>([]);

	useEffect(() => {
		loadManufacturers().then(() => setManufacturers(getManufacturers()));
	}, []);

	return (
		<div>
			<h1>Manufacturers</h1>
			<Link to="/manufacturers/new">+ New Manufacturer</Link>
			<ul>
				{manufacturers.map((manufacturer) => (
					<li key={manufacturer.id}>
						<Link to={`/manufacturers/${manufacturer.id}`}>{manufacturer.name}</Link>
					</li>
				))}
			</ul>
		</div>
	);
}
