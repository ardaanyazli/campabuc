CREATE TABLE manufacturers(
	id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	name nvarchar(255) NOT NULL,
	address nvarchar(max) NULL,
	phone varchar(20) NULL,
	contact_name nvarchar(50) null,
	created_at TIMESTAMP NOT NULL DEFAULT(NOW()),
	updated_at TIMESTAMP NULL
)

