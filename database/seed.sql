-- Fictitious test data for the Admin Portal.
-- The Identity login account is created separately through User Secrets.

INSERT INTO users
    (user_id, first_name, last_name, user_name, user_email, user_address)
VALUES
    (1, 'Albert', 'Einstein', 'aeinstein', 'albert@example.test', 'Test Street 1'),
    (2, 'Marie', 'Curie', 'mcurie', 'marie@example.test', 'Test Street 2'),
    (3, 'Isaac', 'Newton', 'inewton', 'isaac@example.test', 'Test Street 3'),
    (4, 'Nikola', 'Tesla', 'ntesla', 'nikola@example.test', 'Test Street 4'),
    (5, 'Charles', 'Darwin', 'cdarwin', 'charles@example.test', 'Test Street 5'),
    (6, 'Alan', 'Turing', 'aturing', 'alan@example.test', 'Test Street 6'),
    (7, 'Galileo', 'Galilei', 'ggalilei', 'galileo@example.test', 'Test Street 7'),
    (8, 'Nicolaus', 'Copernicus', 'ncopernicus', 'nicolaus@example.test', 'Test Street 8'),
    (9, 'Michael', 'Faraday', 'mfaraday', 'michael@example.test', 'Test Street 9'),
    (10, 'Max', 'Planck', 'mplanck', 'max@example.test', 'Test Street 10'),
    (11, 'Ada', 'Lovelace', 'alovelace', 'ada@example.test', 'Test Street 11'),
    (12, 'Grace', 'Hopper', 'ghopper', 'grace@example.test', 'Test Street 12');

INSERT INTO customer
    (customer_id, user_id, age)
VALUES
    (1, 1, 76),
    (2, 2, 66),
    (3, 3, 84),
    (4, 4, 86),
    (5, 5, 73),
    (6, 6, 41),
    (7, 7, 77),
    (8, 8, 70),
    (9, 9, 76),
    (10, 10, 89),
    (11, 11, 36),
    (12, 12, 85);


INSERT INTO product_catalogue
    (
        product_id,
        product_name,
        description,
        product_price,
        quantity_in_stock
    )
VALUES
    (1, 'Amoxicillin', 'Broad-spectrum antibiotic, oral use', 12.50, 120),
    (2, 'Doxycycline', 'Antibiotic for bacterial infections', 9.95, 80),
    (3, 'Azithromycin', 'Macrolide antibiotic for various infections', 18.75, 60),
    (4, 'Ciprofloxacin', 'Fluoroquinolone antibiotic', 22.40, 45),
    (5, 'Clarithromycin', 'Antibiotic for respiratory infections', 19.90, 50),
    (6, 'Cetirizine', 'Antihistamine for allergy relief', 4.99, 200),
    (7, 'Loratadine', 'Non-drowsy antihistamine', 5.49, 180),
    (8, 'Desloratadine', 'Long-acting antihistamine', 6.75, 150),
    (9, 'Fexofenadine', 'Antihistamine for hay fever', 7.95, 140),
    (10, 'Levocetirizine', 'Antihistamine for allergic rhinitis', 6.25, 160);

INSERT INTO orders
    (order_id, customer_id, order_date, order_status)
VALUES
    (1, 7, '2024-02-02', 'PLACED'),
    (2, 2, '2024-02-04', 'PLACED'),
    (3, 10, '2024-02-06', 'PLACED'),
    (4, 4, '2024-02-08', 'PLACED'),
    (5, 9, '2024-02-10', 'PLACED'),
    (6, 1, '2024-02-12', 'PLACED'),
    (7, 6, '2024-02-14', 'PLACED'),
    (8, 3, '2024-02-16', 'PLACED'),
    (9, 8, '2024-02-18', 'PLACED'),
    (10, 5, '2024-02-20', 'PLACED'),
    (11, 11, '2024-02-22', 'CART'),
    (12, 12, '2024-02-24', 'COMPLETED'),
    (13, 3, '2024-02-26', 'REJECTED');

    INSERT INTO order_details
    (detail_id, order_id, product_id, amount, total_price)
VALUES
    (1, 1, 6, 2, 9.98),
    (2, 1, 1, 1, 12.50),
    (3, 2, 7, 1, 5.49),
    (4, 2, 3, 1, 18.75),
    (5, 3, 2, 1, 9.95),
    (6, 4, 4, 1, 22.40),
    (7, 5, 6, 3, 14.97),
    (8, 5, 8, 1, 6.75),
    (9, 6, 9, 1, 7.95),
    (10, 7, 10, 2, 12.50),
    (11, 8, 5, 1, 19.90),
    (12, 9, 1, 1, 12.50),
    (13, 9, 7, 1, 5.49),
    (14, 10, 6, 1, 4.99),
    (15, 11, 2, 2, 19.90),
    (16, 12, 3, 2, 37.50),
    (17, 13, 4, 1, 22.40);