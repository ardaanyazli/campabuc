CREATE TABLE manufacturers(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	"name" VARCHAR(50) NOT NULL,
	address VARCHAR(200) NULL,
	phone VARCHAR(20) NULL,
	contact_name VARCHAR(50) NULL,
	created_at TIMESTAMP NOT NULL DEFAULT(NOW()),
	updated_at TIMESTAMP  NULL ,
	deleted_at TIMESTAMP NULL
);

CREATE INDEX ix_manufacturers_not_deleted
	ON manufacturers(name)
	WHERE deleted_at IS NULL;

CREATE INDEX ix_manufacturers_deleted
	ON manufacturers(deleted_at)
	WHERE deleted_at IS NOT NULL;
