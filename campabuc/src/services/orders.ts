import { getDB } from './db';

let ordersCache: any[] = [];

export async function loadOrders() {
	const db = getDB();
	ordersCache = await db.select(`SELECT * FROM orders WHERE deleted_at IS NULL`);
}

export function getOrders() {
	return ordersCache;
}

export async function getOrderById(id: string) {
	const db = getDB();
	const result = await db.select(`SELECT * FROM orders WHERE id = ?`, [id]);
	return result[0];
}

export async function saveOrder(item: any) {
	const db = getDB();
	const existing = await db.select(`SELECT id FROM orders WHERE id = ?`, [item.id]);
	if (existing.length > 0) {
		await db.execute(`UPDATE orders SET status = ? WHERE id = ?`, [item.status, item.id]);
	} else {
		await db.execute(`INSERT INTO orders (id, status) VALUES (?, ?)`, [item.id, item.status]);
	}
	await loadOrders();
}

export async function deleteOrder(id: string) {
	const db = getDB();
	await db.execute(`UPDATE orders SET deleted_at = datetime('now') WHERE id = ?`, [id]);
	await loadOrders();
}

export async function syncOrders(apiData: any[]) {
	const db = getDB();
	for (const item of apiData) {
		const existing = await db.select(`SELECT id FROM orders WHERE id = ?`, [item.id]);
		if (existing.length > 0) {
			await db.execute(`UPDATE orders SET status = ? WHERE id = ?`, [item.status, item.id]);
		} else {
			await db.execute(`INSERT INTO orders (id, status) VALUES (?, ?)`, [item.id, item.status]);
		}
	}
	await loadOrders();
}




