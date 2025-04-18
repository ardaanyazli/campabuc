import { getDB } from './db';

let orderItemsCache: any[] = [];

export async function loadOrderItems() {
	const db = getDB();
	orderItemsCache = await db.select(`SELECT * FROM order_items WHERE deleted_at IS NULL`);
}

export function getOrderItems() {
	return orderItemsCache;
}

export async function getOrderItemById(id: string) {
	const db = getDB();
	const result = await db.select(`SELECT * FROM order_items WHERE id = ?`, [id]);
	return result[0];
}

export async function saveOrderItem(item: any) {
	const db = getDB();
	const existing = await db.select(`SELECT id FROM order_items WHERE id = ?`, [item.id]);
	if (existing.length > 0) {
		await db.execute(
			`UPDATE order_items SET order = ?, shoe = ?, quantity = ?, discount = ?, status = ? WHERE id = ?`,
			[item.order, item.shoe, item.quantity, item.discount, item.status, item.id]
		);
	} else {
		await db.execute(
			`INSERT INTO order_items (id, order, shoe, quantity, discount, status) VALUES (?, ?, ?, ?, ?, ?)`,
			[item.id, item.order, item.shoe, item.quantity, item.discount, item.status]
		);
	}
	await loadOrderItems();
}

export async function deleteOrderItem(id: string) {
	const db = getDB();
	await db.execute(`UPDATE order_items SET deleted_at = datetime('now') WHERE id = ?`, [id]);
	await loadOrderItems();
}

export async function syncOrderItems(apiData: any[]) {
	const db = getDB();
	for (const item of apiData) {
		const existing = await db.select(`SELECT id FROM order_items WHERE id = ?`, [item.id]);
		if (existing.length > 0) {
			await db.execute(
				`UPDATE order_items SET order = ?, shoe = ?, quantity = ?, discount = ?, status = ? WHERE id = ?`,
				[item.order, item.shoe, item.quantity, item.discount, item.status, item.id]
			);
		} else {
			await db.execute(
				`INSERT INTO order_items (id, order, shoe, quantity, discount, status) VALUES (?, ?, ?, ?, ?, ?)`,
				[item.id, item.order, item.shoe, item.quantity, item.discount, item.status]
			);
		}
	}
	await loadOrderItems();
}



