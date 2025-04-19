import { useEffect, useState } from 'react';
import { getColors, loadColors } from '../../services/colors';
import { Link } from 'react-router-dom';
import { Card } from '@/components/ui/card';

export default function ColorsList() {
	const [colors, setColors] = useState<any[]>([]);

	useEffect(() => {
		loadColors().then(() => setColors(getColors()));
	}, []);

	return (
		<div>
			<Card className="p-1 items-center m-4">Colors</Card>
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
