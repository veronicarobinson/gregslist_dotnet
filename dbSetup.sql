-- TODO don't forget to create your accounts table today!
CREATE TABLE
  IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
  ) DEFAULT charset utf8mb4 COMMENT '';

-- NOTE make sure your id column is the *FIRST* column declared in this table
CREATE TABLE
  cars (
    id INT PRIMARY KEY AUTO_INCREMENT,
    make VARCHAR(50) NOT NULL,
    model VARCHAR(100) NOT NULL,
    `year` SMALLINT UNSIGNED NOT NULL,
    price MEDIUMINT UNSIGNED NOT NULL,
    img_url VARCHAR(500) NOT NULL,
    description VARCHAR(500),
    engine_type ENUM ('V6', 'V8', 'V10', '4-cylinder', 'unknown') NOT NULL,
    color VARCHAR(50) NOT NULL,
    mileage MEDIUMINT NOT NULL,
    has_clean_title BOOLEAN NOT NULL,
    creator_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
  );

INSERT INTO
  cars (
    make,
    model,
    `year`,
    price,
    img_url,
    description,
    engine_type,
    color,
    mileage,
    has_clean_title,
    creator_id
  )
VALUES
  (
    'chevy',
    'cobalt',
    2008,
    1000,
    'https://images.unsplash.com/photo-1654851783043-c19620497da5?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8Y2hldnklMjBjb2JhbHR8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&q=60&w=500',
    'most iconic car ever, no lowballs I KNOW WHAT I HAVE',
    '4-cylinder',
    'blue',
    1000000,
    FALSE,
    '670ff93326693293c631476f'
  ),
  (
    'mazda',
    'miata',
    1997,
    8000,
    'https://images.unsplash.com/photo-1552615526-40e47a79f9d7?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bWlhdGF8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&q=60&w=500',
    NULL,
    '4-cylinder',
    'gray',
    80000,
    TRUE,
    '65f87bc1e02f1ee243874743'
  );