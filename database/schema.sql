
DROP TABLE IF EXISTS order_details;
DROP TABLE IF EXISTS orders;
DROP TABLE IF EXISTS product_catalogue;
DROP TABLE IF EXISTS customer;
DROP TABLE IF EXISTS admin;
DROP TABLE IF EXISTS users;

CREATE TABLE users
(
    user_id INT NOT NULL AUTO_INCREMENT,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    user_name VARCHAR(50) NOT NULL UNIQUE,
    user_email VARCHAR(100) NOT NULL UNIQUE,
    user_address VARCHAR(100),
    PRIMARY KEY (user_id)
);

CREATE TABLE customer
(
    customer_id INT NOT NULL AUTO_INCREMENT,
    user_id INT NOT NULL,
    age INT NOT NULL,
    PRIMARY KEY (customer_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE admin
(
    admin_id INT NOT NULL AUTO_INCREMENT,
    user_id INT NOT NULL,
    PRIMARY KEY (admin_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE product_catalogue
(
    product_id INT NOT NULL AUTO_INCREMENT,
    product_name VARCHAR(50) NOT NULL UNIQUE,
    description VARCHAR(255),
    product_price DECIMAL(10, 2) NOT NULL,
    quantity_in_stock INT NOT NULL,
    PRIMARY KEY (product_id)
);

CREATE TABLE orders
(
    order_id INT NOT NULL AUTO_INCREMENT,
    customer_id INT NOT NULL,
    order_date DATE NOT NULL,
    order_status ENUM(
        'CART',
        'PLACED',
        'COMPLETED',
        'REJECTED'
    ) NOT NULL DEFAULT 'CART',
    PRIMARY KEY (order_id),
    FOREIGN KEY (customer_id) REFERENCES customer(customer_id)
);

CREATE TABLE order_details
(
    detail_id INT NOT NULL AUTO_INCREMENT,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    amount INT NOT NULL,
    total_price DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (detail_id),
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES product_catalogue(product_id)
);