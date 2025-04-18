import { getDB } from './db';

let sizesCache: any[] = [];

export async function loadSizes() {
	const db = getDB();
	sizesCache = await db.select(`SELECT * FROM sizes WHERE deleted_at IS NULL`);
}

export function getSizes() {
	return sizesCache;
}

export async function getSizeById(id: number) {
	const db = getDB();
	const result = await db.select(`SELECT * FROM sizes WHERE id = ?`, [id]);
	return result[0];
}

export async function saveSize(item: any) {
	const db = getDB();
	const existing = await db.select(`SELECT id FROM sizes WHERE id = ?`, [item.id]);
	if (existing.length > 0) {
		await db.execute(`UPDATE sizes SET name = ? WHERE id = ?`, [item.name, item.id]);
	} else {
		await db.execute(`INSERT INTO sizes (name) VALUES (?)`, [item.name]);
	}
	await loadSizes();
}

export async function deleteSize(id: number) {
	const db = getDB();
	await db.execute(`UPDATE sizes SET deleted_at = datetime('now') WHERE id = ?`, [id]);
	await loadSizes();
}

export async function syncSizes(apiData: any[]) {
	const db = getDB();
	for (const item of apiData) {
		const existing = await db.select(`SELECT id FROM sizes WHERE id = ?`, [item.id]);
		if (existing.length > 0) {
			await db.execute(`UPDATE sizes SET name = ? WHERE id = ?`, [item.name, item.id]);
		} else {
			await db.execute(`INSERT INTO sizes (id, name) VALUES (?, ?)`, [item.id, item.name]);
		}
	}
	await loadSizes();
}
