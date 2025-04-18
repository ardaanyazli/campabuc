import { useEffect, useState } from 'react';
import { getShoes, loadShoes } from '../../services/shoes';
import { Link } from 'react-router-dom';

export default function ShoesList() {
	const [shoes, setShoes] = useState<any[]>([]);

	useEffect(() => {
		loadShoes().then(() => setShoes(getShoes()));
	}, []);

	return (
		<div>
			<h1>Shoes</h1>
			<Link to="/shoes/new">+ New Shoe</Link>
			<ul>
				{shoes.map((shoe) => (
					<li key={shoe.id}>
						<Link to={`/shoes/${shoe.id}`}>{`#${shoe.id} | ${shoe.barcode} | ${shoe.price} | Stock: ${shoe.inventory}`}</Link>
					</li>
				))}
			</ul>
		</div>
	);
}

