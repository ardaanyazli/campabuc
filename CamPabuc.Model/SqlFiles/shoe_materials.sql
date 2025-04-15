CREATE TABLE shoe_materials(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	"name" VARCHAR(20) NOT NULL
	created_at TIMESTAMP NOT NULL DEFAULT(NOW()),
	deleted_at TIMESTAMP NULL,
);
CREATE INDEX ix_shoe_materials_not_deleted
	ON manufacturers(name)
	WHERE deleted_at IS  NULL;
CREATE INDEX ix_shoe_materials_deleted
	ON manufacturers(deleted_at)
	WHERE deleted_at IS NOT NULL;

