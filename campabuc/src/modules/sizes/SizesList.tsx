import { useEffect, useState } from 'react';
import { getSizes, loadSizes } from '../../services/sizes';
import { Link } from 'react-router-dom';

export default function SizesList() {
	const [sizes, setSizes] = useState<any[]>([]);

	useEffect(() => {
		loadSizes().then(() => setSizes(getSizes()));
	}, []);

	return (
		<div>
			<h1>Sizes</h1>
			<Link to="/sizes/new">+ New Size</Link>
			<ul>
				{sizes.map((size) => (
					<li key={size.id}>
						<Link to={`/sizes/${size.id}`}>{size.name}</Link>
					</li>
				))}
			</ul>
		</div>
	);
}
