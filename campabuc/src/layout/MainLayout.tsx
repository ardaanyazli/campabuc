import { Link, Outlet, useLocation } from 'react-router-dom';
import { Card } from '@/components/ui/card';
import { Button } from '@/components/ui/button';
import {
	Factory,
	Palette,
	Ruler,
	ShoppingCart,
	Boxes,
	Archive,
} from 'lucide-react';
import ThemeToggle from '@/theme/ThemeToggle';

const navItems = [
	{ path: '/manufacturers', label: 'Manufacturers', icon: Factory },
	{ path: '/colors', label: 'Colors', icon: Palette },
	{ path: '/sizes', label: 'Sizes', icon: Ruler },
	{ path: '/materials', label: 'Materials', icon: Archive },
	{ path: '/shoes', label: 'Shoes', icon: Boxes },
	{ path: '/orders', label: 'Orders', icon: ShoppingCart },
];

export default function MainLayout() {
	const location = useLocation();

	return (
		<div className="flex h-screen">
			<Card className="w-50 p-4 flex gap-2 flex-col border-r shadow-md">
				<ThemeToggle />
				<h1 className="text-2xl font-bold mb-6">CamPabuc</h1>
				<nav className="flex flex-col gap-2">
					{navItems.map(({ path, label, icon: Icon }) => (
						<Button
							key={path}
							variant={location.pathname.startsWith(path) ? 'default' : 'ghost'}
							className="justify-start gap-2"
							asChild
						>
							<Link to={path}>
								<Icon size={18} className="shrink-0" />
								{label}
							</Link>
						</Button>
					))}
				</nav>
			</Card>
			<main className="flex-1 p-6 overflow-auto border-r">
				<Outlet />
			</main>
		</div>
	);
}
