import { Link, Outlet } from 'react-router-dom';

export default function MainLayout() {
	return (
		<div className="flex h-screen">
			<nav className="w-60 bg-gray-100 p-4">
				<h2 className="text-lg font-bold mb-4">Menu</h2>
				<ul className="space-y-2">
					<li><Link to="/manufacturers">Manufacturers</Link></li>
					<li><Link to="/colors">Colors</Link></li>
					<li><Link to="/sizes">Sizes</Link></li>
					<li><Link to="/materials">Materials</Link></li>
					<li><Link to="/shoes">Shoes</Link></li>
					<li><Link to="/orders">Orders</Link></li>
				</ul>
			</nav>
			<main className="flex-1 p-6 overflow-auto">
				<Outlet />
			</main>
		</div>
	);
}
