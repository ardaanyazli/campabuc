import React from 'react';
import { Link } from 'react-router-dom';

const Menu = () => (
	<nav className="p-4 shadow-md bg-white dark:bg-gray-800">
		<ul className="flex gap-4">
			<li><Link to="/manufacturers">Manufacturers</Link></li>
			<li><Link to="/colors">Colors</Link></li>
			<li><Link to="/sizes">Sizes</Link></li>
			<li><Link to="/materials">Materials</Link></li>
			<li><Link to="/shoes">Shoes</Link></li>
			<li><Link to="/orders">Orders</Link></li>
		</ul>
	</nav>
)

export default Menu
