CREATE TABLE shoes(
	id UUID PRIMARY KEY,
	category INT NOT NULL,
	material INT NULL REFERENCES shoe_materials(id) ON DELETE SET NULL,
	color INT NULL REFERENCES shoe_colors(id) ON DELETE SET NULL,
	size INT NULL REFERENCES shoe_sizes(id) ON DELETE SET NULL,
	manufacturer INT NOT NULL REFERENCES manufacturers(id) ON DELETE SET NULL,
	price DECIMAL(10,5) NOT NULL DEFAULT(0),
	inventory INT NOT NULL DEFAULT(0),
	created_at TIMESTAMP NOT NULL DEFAULT(NOW()),
	updated_at TIMESTAMP  NULL ,
	deleted_at TIMESTAMP  NULL ,
	barcode VARCHAR(20) NULL,
	img_url VARCHAR(255) NULL
);
CREATE INDEX ix_shoes_not_deleted_color
	ON shoes(color)
	WHERE deleted_at IS NULL;
CREATE INDEX ix_shoes_not_deleted_material
	ON shoes(material)
	WHERE deleted_at IS NULL;
CREATE INDEX ix_shoes_not_deleted_size
	ON shoes(size)
	WHERE deleted_at IS NULL;
CREATE INDEX ix_shoes_not_deleted_manufacturer
	ON shoes(manufacturer)
	WHERE deleted_at IS NULL;
CREATE INDEX ix_shoes_deleted
	ON shoes(deleted_at)
	WHERE deleted_at IS NOT NULL;
