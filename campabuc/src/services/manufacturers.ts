import { getDB } from './db';

let manufacturersCache: any[] = [];

const loadManufacturers = async () => {
	const db = getDB();
	manufacturersCache = await db.select(`SELECT * FROM manufacturers WHERE deleted_at IS NULL`);
}

const getManufacturers = async () => {

	if (manufacturersCache.length === 0) {
		await loadManufacturers();
	}

	return manufacturersCache;
}

const getManufacturerById = async (id: number) => {
	const db = getDB();
	const result = await db.select(`SELECT * FROM manufacturers WHERE id = ?`, [id]);
	return result[0];
}

const saveManufacturer = async (item: any) => {
	const db = getDB();
	if (item.id) {
		const existing = await db.select(`SELECT id FROM manufacturers WHERE id = ?`, [item.id]);
		if (existing.length > 0) {
			db.execute(
				`UPDATE manufacturers SET name = ?, address = ?, phone = ?, contact_name = ? WHERE id = ?`,
				[item.name, item.address, item.phone, item.contact_name, item.id]
			);
		} else {
			await db.execute(
				`INSERT INTO manufacturers (name, address, phone, contact_name) VALUES (?, ?, ?, ?)`,
				[item.name, item.address, item.phone, item.contact_name]
			);
		}
	} else {
		await db.execute(
			`INSERT INTO manufacturers (name, address, phone, contact_name) VALUES (?, ?, ?, ?)`,
			[item.name, item.address, item.phone, item.contact_name]
		);
	}
	await loadManufacturers();
}

const deleteManufacturer = async (id: number) => {
	const db = getDB();
	await db.execute(`UPDATE manufacturers SET deleted_at = datetime('now') WHERE id = ?`, [id]);
	await loadManufacturers();
}

const syncManufacturers = async (apiData: any[]) => {
	const db = getDB();
	for (const item of apiData) {
		const existing = await db.select(`SELECT id FROM manufacturers WHERE id = ?`, [item.id]);
		if (existing.length > 0) {
			await db.execute(
				`UPDATE manufacturers SET name = ?, address = ?, phone = ?, contact_name = ? WHERE id = ?`,
				[item.name, item.address, item.phone, item.contact_name, item.id]
			);
		} else {
			await db.execute(
				`INSERT INTO manufacturers (id, name, address, phone, contact_name) VALUES (?, ?, ?, ?, ?)`,
				[item.id, item.name, item.address, item.phone, item.contact_name]
			);
		}
	}
	await loadManufacturers();
}

export { getManufacturers, getManufacturerById, saveManufacturer, deleteManufacturer, syncManufacturers }
