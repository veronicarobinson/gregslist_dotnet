-- TODO don't forget to create your accounts table today!
CREATE TABLE IF NOT EXISTS accounts (
    id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT 'primary key',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name VARCHAR(255) COMMENT 'User Name',
    email VARCHAR(255) UNIQUE COMMENT 'User Email',
    picture VARCHAR(255) COMMENT 'User Picture'
) DEFAULT charset utf8mb4 COMMENT '';

-- NOTE make sure your id column is the *FIRST* column declared in this table
CREATE TABLE cars (
    id INT PRIMARY KEY AUTO_INCREMENT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    make VARCHAR(50) NOT NULL,
    model VARCHAR(100) NOT NULL,
    `year` SMALLINT UNSIGNED NOT NULL,
    price MEDIUMINT UNSIGNED NOT NULL,
    img_url VARCHAR(500) NOT NULL,
    description VARCHAR(500),
    engine_type ENUM(
        'V6',
        'V8',
        'V10',
        '4-cylinder',
        'unknown'
    ) NOT NULL,
    color VARCHAR(50) NOT NULL,
    mileage MEDIUMINT NOT NULL,
    has_clean_title BOOLEAN NOT NULL,
    creator_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
);

CREATE TABLE houses (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    sqft INT NOT NULL,
    bedrooms INT NOT NULL,
    bathrooms DECIMAL(2, 1) NOT NULL,
    img_url VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    price MEDIUMINT NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    creator_id VARCHAR(255) NOT NULL,
    FOREIGN KEY (creator_id) REFERENCES accounts (id) ON DELETE CASCADE
);

DROP TABLE cars;

DROP TABLE houses;

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
VALUES (
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
        1996,
        8000,
        'https://images.unsplash.com/photo-1552615526-40e47a79f9d7?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8bWlhdGF8ZW58MHx8MHx8fDA%3D&auto=format&fit=crop&q=60&w=500',
        NULL,
        '4-cylinder',
        'gray',
        80000,
        TRUE,
        '65f87bc1e02f1ee243874743'
    );

INSERT INTO
    houses (
        sqft,
        bedrooms,
        bathrooms,
        img_url,
        description,
        price,
        creator_id
    )
VALUES (
        1400,
        3,
        2.5,
        'https://images.unsplash.com/photo-1572120360610-d971b9d7767c?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&q=80&w=1170',
        'meeeeeeeeeeeep',
        150000,
        '68c330cbc775754ad19335d2'
    ),
    (
        200,
        1,
        0,
        'https://images.unsplash.com/photo-1434082033009-b81d41d32e1c?ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&q=80&w=1170',
        'YOURE A TOWEL',
        5,
        '68c33215fc2662494f9a90b3'
    );

-- NOTE because of the ON DELETE CASCADE, if someone's account gets deleted it also deletes all of their cars
DELETE FROM accounts WHERE id = '670ff93326693293c631476f';

SELECT * FROM cars;

SELECT * FROM houses;

SELECT cars.*, accounts.*
FROM cars
    INNER JOIN accounts ON cars.creator_id = accounts.id
ORDER BY cars.id;

SELECT cars.*, accounts.*
FROM cars
    JOIN accounts ON accounts.id = cars.creator_id
WHERE
    cars.id = 1;