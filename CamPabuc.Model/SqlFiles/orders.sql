CREATE TABLE IF NOT EXISTS orders(
	id UUID NOT NULL PRIMARY KEY,
	created_at TIMESTAMP NOT NULL DEFAULT(NOW()),
	deleted_at TIMESTAMP NULL,
	status INT NULL
);
CREATE INDEX ix_orders_not_deleted_created
ON orders(created_at)
WHERE deleted_at IS NULL;
CREATE INDEX ix_orders_not_deleted_status
ON orders(status)
WHERE deleted_at IS NULL;
CREATE INDEX ix_orders_deleted
ON orders(deleted_at)
WHERE deleted_at IS NOT NULL;
