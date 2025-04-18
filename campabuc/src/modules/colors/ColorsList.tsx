import { useEffect, useState } from 'react';
import { getColors, loadColors } from '../../services/colors';
import { Link } from 'react-router-dom';

export default function ColorsList() {
	const [colors, setColors] = useState<any[]>([]);

	useEffect(() => {
		loadColors().then(() => setColors(getColors()));
	}, []);

	return (
		<div>
			<h1>Colors</h1>
			<Link to="/colors/new">+ New Color</Link>
			<ul>
				{colors.map((color) => (
					<li key={color.id}>
						<Link to={`/colors/${color.id}`}>{color.name}</Link>
					</li>
				))}
			</ul>
		</div>
	);
}
