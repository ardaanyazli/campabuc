import { getDB } from './db';

let materialsCache: any[] = [];

export async function loadMaterials() {
	const db = getDB();
	materialsCache = await db.select(`SELECT * FROM materials WHERE deleted_at IS NULL`);
}

export function getMaterials() {
	return materialsCache;
}

export async function getMaterialById(id: number) {
	const db = getDB();
	const result = await db.select(`SELECT * FROM materials WHERE id = ?`, [id]);
	return result[0];
}

export async function saveMaterial(item: any) {
	const db = getDB();
	const existing = await db.select(`SELECT id FROM materials WHERE id = ?`, [item.id]);
	if (existing.length > 0) {
		await db.execute(`UPDATE materials SET name = ? WHERE id = ?`, [item.name, item.id]);
	} else {
		await db.execute(`INSERT INTO materials (name) VALUES (?)`, [item.name]);
	}
	await loadMaterials();
}

export async function deleteMaterial(id: number) {
	const db = getDB();
	await db.execute(`UPDATE materials SET deleted_at = datetime('now') WHERE id = ?`, [id]);
	await loadMaterials();
}

export async function syncMaterials(apiData: any[]) {
	const db = getDB();
	for (const item of apiData) {
		const existing = await db.select(`SELECT id FROM materials WHERE id = ?`, [item.id]);
		if (existing.length > 0) {
			await db.execute(`UPDATE materials SET name = ? WHERE id = ?`, [item.name, item.id]);
		} else {
			await db.execute(`INSERT INTO materials (id, name) VALUES (?, ?)`, [item.id, item.name]);
		}
	}
	await loadMaterials();
}
