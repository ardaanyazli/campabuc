CREATE TABLE shoe_sizes(
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	"name" VARCHAR(20) NOT NULL,
	created_at TIMESTAMP NOT NULL DEFAULT(NOW()),
	updated_at TIMESTAMP  NULL ,
	deleted_at TIMESTAMP NULL
);
CREATE INDEX ix_shoe_sizes_not_deleted
	ON shoe_sizes(name)
	WHERE deleted_at IS  NULL;
CREATE INDEX ix_shoe_sizes_deleted
	ON shoe_sizes(deleted_at)
	WHERE deleted_at IS NOT NULL;

