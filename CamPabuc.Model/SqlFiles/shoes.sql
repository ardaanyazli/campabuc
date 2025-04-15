CREATE TABLE shoes(
	id UUID PRIMARY KEY,
	category INT NOT NULL,
	material BIGINT NOT NULL REFERENCES shoe_materials(id),
	color BIGINT NOT NULL REFERENCES shoe_colors(id),
	size BIGINT NOT NULL REFERENCES shoe_sizes(id),
	manufacturer BIGINT NOT NULL REFERENCES manufacturers(id),
	price DECIMAL(10,5) NOT NULL DEFAULT(0),
	inventory BIGINT NOT NULL DEFAULT(0),
	barcode VARCHAR(20) NULL,
	img_url VARCHAR(255) NULL
)
