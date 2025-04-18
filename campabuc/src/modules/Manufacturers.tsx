import React, { useEffect, useState } from 'react';
import { ListPage } from '@/components/ListPage';
import { FormPage } from '@/components/FormPage';
import { Routes, Route } from 'react-router-dom';
import { getManufacturerById, getManufacturers, loadManufacturers, saveManufacturer } from '@/services/manufacturers';

const ManufacturersModule = () => {
	const [data, setData] = useState<any[]>([]);

	useEffect(() => {
		(async () => {
			await loadManufacturers();
			setData(getManufacturers());
		})();
	}, []);

	return (
		<Routes>
			<Route
				path=""
				element={<ListPage
					title="Manufacturers"
					data={data}
					basePath="/manufacturers"
					columns={[
						{ key: 'name', label: 'Name' },
						{ key: 'address', label: 'Address' },
						{ key: 'phone', label: 'Phone' },
						{ key: 'contact_name', label: 'Contact' },
					]} />} />
			<Route
				path=":id"
				element={<FormPage
					title="Manufacturer Form"
					basePath="/manufacturers"
					fields={[
						{ key: 'name', label: 'Name' },
						{ key: 'address', label: 'Address' },
						{ key: 'phone', label: 'Phone' },
						{ key: 'contact_name', label: 'Contact' },
					]}
					loadItem={getManufacturerById}
					saveItem={saveManufacturer} />} />
		</Routes>
	);
};

export default ManufacturersModule;
