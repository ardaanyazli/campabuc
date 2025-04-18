import { useEffect, useState } from 'react';
import { getMaterials, loadMaterials } from '../../services/materials';
import { Link } from 'react-router-dom';

export default function MaterialsList() {
	const [materials, setMaterials] = useState<any[]>([]);

	useEffect(() => {
		loadMaterials().then(() => setMaterials(getMaterials()));
	}, []);

	return (
		<div>
			<h1>Materials</h1>
			<Link to="/materials/new">+ New Material</Link>
			<ul>
				{materials.map((material) => (
					<li key={material.id}>
						<Link to={`/materials/${material.id}`}>{material.name}</Link>
					</li>
				))}
			</ul>
		</div>
	);
}
