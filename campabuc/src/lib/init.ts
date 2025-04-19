import { initDB } from '../services/db';

export async function initializeApp() {
	await initDB();
}
