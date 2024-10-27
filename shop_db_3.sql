CREATE TABLE [Brand] (
  [id] bigint PRIMARY KEY IDENTITY(1,1),
  [name] varchar(255) NOT NULL,
  [user_identifier] varchar(255)
)
GO

CREATE TABLE [Product] (
  [id] bigint PRIMARY KEY, 
  [name] varchar(255) NOT NULL,
  [title] varchar(255) NOT NULL,
  [thumbnail_image] varchar(255),
  [brand_id] bigint NOT NULL,
  [sold] int NOT NULL,
  [allow_multiple_config] bit NOT NULL,
  [url] nvarchar(255) NOT NULL,
  [created_date] datetime NOT NULL,
  [review_score] decimal(3,2),
  [review_count] int NOT NULL,
  [has_3d_assets] bit NOT NULL,
  [layout] varchar(255),
  [location] varchar(255)
)
GO

CREATE TABLE [Price] (
  [id] bigint PRIMARY KEY IDENTITY(1,1),
  [product_id] bigint NOT NULL,
  [currency] varchar(3),
  [amount] decimal(6,2) NOT NULL,
  [og_currency] nvarchar(3),
  [og_amount] decimal(6,2) NOT NULL,
  [fp_currency] varchar(3),
  [fp_amount] decimal(6,2) NOT NULL,
  [dp_currency] varchar(3),
  [dp_amount] decimal(6,2) NOT NULL
)
GO

CREATE TABLE [Collection] (
  [id] bigint PRIMARY KEY,
  [name] varchar(255) NOT NULL
)
GO

CREATE TABLE [Tag] (
  [id] bigint PRIMARY KEY,
  [parent_id] bigint NOT NULL,
  [name] varchar(255) NOT NULL,
  [parent_name] varchar(255) NOT NULL,
  [user_identifier] varchar(255),
  [collection_id] bigint NOT NULL,
  [thumbnail_image] varchar(255)
)
GO

CREATE TABLE [Category] (
  [id] bigint PRIMARY KEY,
  [parent_id] bigint NOT NULL,
  [name] varchar(255) NOT NULL,
  [title] varchar(255) NOT NULL
)
GO

CREATE TABLE [Image] (
  [id] bigint PRIMARY KEY IDENTITY(1,1),
  [name] varchar(255) NOT NULL,
  [description] varchar(1024),
  [alt] varchar(255) NOT NULL,
  [original] varchar(255) NOT NULL,
  [large] varchar(255) NOT NULL,
  [medium_large] varchar(255) NOT NULL,
  [medium] varchar(255) NOT NULL,
  [medium_small] varchar(255) NOT NULL,
  [small] varchar(255) NOT NULL,
  [thumbnail] varchar(255) NOT NULL,
  [small_thumbnail] varchar(255) NOT NULL
)
GO

CREATE TABLE [ProductImage] (
  [id] bigint PRIMARY KEY IDENTITY(1,1),
  [product_id] bigint NOT NULL,
  [image_id] bigint NOT NULL
)
GO

CREATE TABLE [ProductCategory] (
  [id] bigint PRIMARY KEY IDENTITY(1,1),
  [product_id] bigint NOT NULL,
  [category_id] bigint NOT NULL
)
GO

CREATE TABLE [ProductTag] (
  [id] bigint PRIMARY KEY IDENTITY(1,1),
  [product_id] bigint NOT NULL,
  [tag_id] bigint NOT NULL
)
GO

ALTER TABLE [Price] ADD FOREIGN KEY ([product_id]) REFERENCES [Product] ([id])
GO

--ALTER TABLE [Tag] ADD FOREIGN KEY ([parent_id]) REFERENCES [Tag] ([id])
--GO

--ALTER TABLE [Category] ADD FOREIGN KEY ([parent_id]) REFERENCES [Category] ([id])
--GO

ALTER TABLE [ProductImage] ADD FOREIGN KEY ([product_id]) REFERENCES [Product] ([id])
GO

ALTER TABLE [ProductImage] ADD FOREIGN KEY ([image_id]) REFERENCES [Image] ([id])
GO

ALTER TABLE [ProductCategory] ADD FOREIGN KEY ([product_id]) REFERENCES [Product] ([id])
GO

ALTER TABLE [ProductCategory] ADD FOREIGN KEY ([category_id]) REFERENCES [Category] ([id])
GO

ALTER TABLE [ProductTag] ADD FOREIGN KEY ([product_id]) REFERENCES [Product] ([id])
GO

ALTER TABLE [ProductTag] ADD FOREIGN KEY ([tag_id]) REFERENCES [Tag] ([id])
GO

ALTER TABLE [Product] ADD FOREIGN KEY ([brand_id]) REFERENCES [Brand] ([id])
GO

ALTER TABLE [Tag] ADD FOREIGN KEY ([collection_id]) REFERENCES [Collection] ([id])
GO
