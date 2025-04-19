import initSqlJs from 'sql.js';

let dbInstance: any = null;

export async function initDB() {
	const SQL = await initSqlJs({ locateFile: (file) => `https://sql.js.org/dist/${file}` });
	dbInstance = new SQL.Database();

	dbInstance.run(`
    CREATE TABLE IF NOT EXISTS manufacturers (
      id INTEGER PRIMARY KEY AUTOINCREMENT,
      name TEXT,
      address TEXT,
      phone TEXT,
      contact_name TEXT,
      created_at TEXT DEFAULT CURRENT_TIMESTAMP,
      deleted_at TEXT
    );

    CREATE TABLE IF NOT EXISTS colors (
      id INTEGER PRIMARY KEY AUTOINCREMENT,
      name TEXT,
      created_at TEXT DEFAULT CURRENT_TIMESTAMP,
      deleted_at TEXT
    );

    CREATE TABLE IF NOT EXISTS sizes (
      id INTEGER PRIMARY KEY AUTOINCREMENT,
      name TEXT,
      created_at TEXT DEFAULT CURRENT_TIMESTAMP,
      deleted_at TEXT
    );

    CREATE TABLE IF NOT EXISTS materials (
      id INTEGER PRIMARY KEY AUTOINCREMENT,
      name TEXT,
      created_at TEXT DEFAULT CURRENT_TIMESTAMP,
      deleted_at TEXT
    );

    CREATE TABLE IF NOT EXISTS shoes (
      id INTEGER PRIMARY KEY AUTOINCREMENT,
      color INTEGER,
      size INTEGER,
      material INTEGER,
      price REAL,
      inventory INTEGER,
      barcode TEXT,
      created_at TEXT DEFAULT CURRENT_TIMESTAMP,
      deleted_at TEXT,
      FOREIGN KEY(color) REFERENCES colors(id),
      FOREIGN KEY(size) REFERENCES sizes(id),
      FOREIGN KEY(material) REFERENCES materials(id)
    );

    CREATE TABLE IF NOT EXISTS orders (
      id TEXT PRIMARY KEY,
      status TEXT,
      created_at TEXT DEFAULT CURRENT_TIMESTAMP,
      deleted_at TEXT
    );

    CREATE TABLE IF NOT EXISTS order_items (
      id TEXT PRIMARY KEY,
      order_id TEXT,
      shoe_id INTEGER,
      quantity INTEGER,
      discount REAL,
      status TEXT,
      created_at TEXT DEFAULT CURRENT_TIMESTAMP,
      deleted_at TEXT,
      FOREIGN KEY(order_id) REFERENCES orders(id),
      FOREIGN KEY(shoe_id) REFERENCES shoes(id)
    );
  `);
}

export function getDB() {
	if (!dbInstance) {
		throw new Error('Database not initialized. Call initDB() first.');
	}
	return {
		select: async (sql: string, params: any[] = []) => {
			const stmt = dbInstance.prepare(sql);
			stmt.bind(params);
			const results = [];
			while (stmt.step()) {
				results.push(stmt.getAsObject());
			}
			stmt.free();
			return results;
		},
		execute: async (sql: string, params: any[] = []) => {
			const stmt = dbInstance.prepare(sql);
			stmt.bind(params);
			stmt.step();
			stmt.free();
		},
	};
}

