import { getDB } from './db';

let colorsCache: any[] = [];

export async function loadColors() {
	const db = getDB();
	colorsCache = await db.select(`SELECT * FROM colors WHERE deleted_at IS NULL`);
}

export function getColors() {
	return colorsCache;
}

export async function getColorById(id: number) {
	const db = getDB();
	const result = await db.select(`SELECT * FROM colors WHERE id = ?`, [id]);
	return result[0];
}

export async function saveColor(item: any) {
	const db = getDB();
	const existing = await db.select(`SELECT id FROM colors WHERE id = ?`, [item.id]);
	if (existing.length > 0) {
		await db.execute(`UPDATE colors SET name = ? WHERE id = ?`, [item.name, item.id]);
	} else {
		await db.execute(`INSERT INTO colors (name) VALUES (?)`, [item.name]);
	}
	await loadColors();
}

export async function deleteColor(id: number) {
	const db = getDB();
	await db.execute(`UPDATE colors SET deleted_at = datetime('now') WHERE id = ?`, [id]);
	await loadColors();
}

export async function syncColors(apiData: any[]) {
	const db = getDB();
	for (const item of apiData) {
		const existing = await db.select(`SELECT id FROM colors WHERE id = ?`, [item.id]);
		if (existing.length > 0) {
			await db.execute(`UPDATE colors SET name = ? WHERE id = ?`, [item.name, item.id]);
		} else {
			await db.execute(`INSERT INTO colors (id, name) VALUES (?, ?)`, [item.id, item.name]);
		}
	}
	await loadColors();
}
