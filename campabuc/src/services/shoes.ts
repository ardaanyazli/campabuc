import { getDB } from './db';

let shoesCache: any[] = [];

export async function loadShoes() {
	const db = getDB();
	shoesCache = await db.select(`SELECT * FROM shoes WHERE deleted_at IS NULL`);
}

export function getShoes() {
	return shoesCache;
}

export async function getShoeById(id: number) {
	const db = getDB();
	const result = await db.select(`SELECT * FROM shoes WHERE id = ?`, [id]);
	return result[0];
}

export async function saveShoe(item: any) {
	const db = getDB();
	if (item.id) {
		await db.execute(
			`UPDATE shoes SET color = ?, size = ?, material = ?, price = ?, inventory = ?, barcode = ? WHERE id = ?`,
			[item.color, item.size, item.material, item.price, item.inventory, item.barcode, item.id]
		);
	} else {
		await db.execute(
			`INSERT INTO shoes (color, size, material, price, inventory, barcode) VALUES (?, ?, ?, ?, ?, ?)`,
			[item.color, item.size, item.material, item.price, item.inventory, item.barcode]
		);
	}
	await loadShoes();
}

export async function deleteShoe(id: number) {
	const db = getDB();
	await db.execute(`UPDATE shoes SET deleted_at = datetime('now') WHERE id = ?`, [id]);
	await loadShoes();
}

export async function syncShoes(apiData: any[]) {
	const db = getDB();
	for (const item of apiData) {
		const existing = await db.select(`SELECT id FROM shoes WHERE id = ?`, [item.id]);
		if (existing.length > 0) {
			await db.execute(
				`UPDATE shoes SET color = ?, size = ?, material = ?, price = ?, inventory = ?, barcode = ? WHERE id = ?`,
				[item.color, item.size, item.material, item.price, item.inventory, item.barcode, item.id]
			);
		} else {
			await db.execute(
				`INSERT INTO shoes (id, color, size, material, price, inventory, barcode) VALUES (?, ?, ?, ?, ?, ?, ?)`,
				[item.id, item.color, item.size, item.material, item.price, item.inventory, item.barcode]
			);
		}
	}
	await loadShoes();
}




