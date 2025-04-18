import React from 'react';
import { Button } from '@/components/ui/button';
import { Link } from 'react-router-dom';

type ListPageProps<T> = {
	title: string;
	data: T[];
	columns: { key: keyof T; label: string }[];
	basePath: string;
};

export function ListPage<T>({ title, data, columns, basePath }: ListPageProps<T>) {
	return (
		<div className="p-4">
			<h1 className="text-xl font-bold mb-4">{title}</h1>
			<Link to={`${basePath}/new`}><Button>Create New</Button></Link>
			<table className="w-full mt-4">
				<thead>
					<tr>
						{columns.map((col) => (
							<th key={String(col.key)}>{col.label}</th>
						))}
						<th>Actions</th>
					</tr>
				</thead>
				<tbody>
					{data.map((item: any) => (
						<tr key={item.id}>
							{columns.map((col) => (
								<td key={String(col.key)}>{item[col.key]}</td>
							))}
							<td>
								<Link to={`${basePath}/edit/${item.id}`}><Button>Edit</Button></Link>
							</td>
						</tr>
					))}
				</tbody>
			</table>
		</div>
	);
}
