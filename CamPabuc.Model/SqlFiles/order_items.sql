CREATE TABLE order_items(
	id UUID PRIMARY KEY,
	order_id UUID NOT NULL REFERENCES ORDERS(ID),
	item_id UUID NOT NULL REFERENCES SHOES(ID),
	quantity BIGINT NOT NULL DEFAULT(0),
	created_at TIMESTAMP NOT NULL DEFAULT(NOW()),
	deleted_at TIMESTAMP NULL,
	status INT NULL
);
CREATE INDEX ix_shoe_order_items_not_deleted
	ON order_items(order_id)
	WHERE deleted_at IS  NULL;
CREATE INDEX ix_order_items_status
ON order_items(status)
WHERE deleted_at IS NULL;
CREATE INDEX ix_shoe_order_items_deleted
	ON order_items(deleted_at)
	WHERE deleted_at IS NOT NULL;
