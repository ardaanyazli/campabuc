CREATE TABLE shoe_materials(
	id bigint GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	name nvarchar(20) NOT NULL
	created_at TIMESTAMP NOT NULL DEFAULT(NOW()),
	updated_at TIMESTAMP NULL,
)

