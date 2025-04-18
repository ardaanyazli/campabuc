import { getDB } from './db';

let manufacturersCache: any[] = [];

export async function loadManufacturers() {
	const db = getDB();
	manufacturersCache = await db.select(`SELECT * FROM manufacturers WHERE deleted_at IS NULL`);
}

export function getManufacturers() {
	return manufacturersCache;
}

export async function getManufacturerById(id: number) {
	const db = getDB();
	const result = await db.select(`SELECT * FROM manufacturers WHERE id = ?`, [id]);
	return result[0];
}

export async function saveManufacturer(item: any) {
	const db = getDB();
	const existing = await db.select(`SELECT id FROM manufacturers WHERE id = ?`, [item.id]);
	if (existing.length > 0) {
		await db.execute(
			`UPDATE manufacturers SET name = ?, address = ?, phone = ?, contact_name = ? WHERE id = ?`,
			[item.name, item.address, item.phone, item.contact_name, item.id]
		);
	} else {
		await db.execute(
			`INSERT INTO manufacturers (name, address, phone, contact_name) VALUES (?, ?, ?, ?)`,
			[item.name, item.address, item.phone, item.contact_name]
		);
	}
	await loadManufacturers();
}

export async function deleteManufacturer(id: number) {
	const db = getDB();
	await db.execute(`UPDATE manufacturers SET deleted_at = datetime('now') WHERE id = ?`, [id]);
	await loadManufacturers();
}

export async function syncManufacturers(apiData: any[]) {
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
