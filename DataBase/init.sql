-- ==========================================
-- DDL: Estructura de InventarySystem
-- ==========================================

CREATE TABLE companies (
    id INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id)
);

CREATE TABLE warehouses (
    id INT NOT NULL,
    company_id INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    FOREIGN KEY (company_id) REFERENCES companies(id)
);

CREATE TABLE categories (
    id INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id)
);

CREATE TABLE products (
    id INT NOT NULL,
    category_id INT,
    sku VARCHAR(50) NOT NULL,
    name VARCHAR(150) NOT NULL,
    unit VARCHAR(20) NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    FOREIGN KEY (category_id) REFERENCES categories(id)
);

CREATE TABLE company_products (
    company_id INT NOT NULL,
    product_id INT NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    PRIMARY KEY (company_id, product_id),
    FOREIGN KEY (company_id) REFERENCES companies(id),
    FOREIGN KEY (product_id) REFERENCES products(id)
);

CREATE TABLE stocks (
    product_id INT NOT NULL,
    warehouse_id INT NOT NULL,
    quantity DECIMAL(10, 2) NOT NULL DEFAULT 0,
    last_updated TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (product_id, warehouse_id),
    FOREIGN KEY (product_id) REFERENCES products(id),
    FOREIGN KEY (warehouse_id) REFERENCES warehouses(id)
);

CREATE TABLE movements (
    id INT NOT NULL,
    company_id INT NOT NULL,
    warehouse_id INT NOT NULL,
    type VARCHAR(10) NOT NULL,
    status VARCHAR(20) NOT NULL DEFAULT 'DRAFT',
    movement_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    notes TEXT,
    PRIMARY KEY (id),
    FOREIGN KEY (company_id) REFERENCES companies(id),
    FOREIGN KEY (warehouse_id) REFERENCES warehouses(id)
);

CREATE TABLE movement_details (
    id INT NOT NULL,
    movement_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (movement_id) REFERENCES movements(id),
    FOREIGN KEY (product_id) REFERENCES products(id)
);

CREATE TABLE kardex (
    id INT NOT NULL,
    company_id INT NOT NULL,
    warehouse_id INT NOT NULL,
    product_id INT NOT NULL,
    movement_detail_id INT NOT NULL,
    transaction_type VARCHAR(10) NOT NULL,
    quantity DECIMAL(10, 2) NOT NULL,
    balance_after DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id),
    FOREIGN KEY (company_id) REFERENCES companies(id),
    FOREIGN KEY (warehouse_id) REFERENCES warehouses(id),
    FOREIGN KEY (product_id) REFERENCES products(id),
    FOREIGN KEY (movement_detail_id) REFERENCES movement_details(id)
);

-- ==========================================
-- DML: Datos Semilla (Seed)
-- ==========================================

INSERT INTO companies (id, name) VALUES 
(1, 'Ferretería Tuerca Mágica'),
(2, 'Minimarket El Sol');

INSERT INTO warehouses (id, company_id, name) VALUES 
(1, 1, 'Bodega Central Ferretería'),
(2, 2, 'Almacén Tienda Minimarket');

INSERT INTO categories (id, name) VALUES 
(1, 'Herramientas'),
(2, 'Bebidas');

INSERT INTO products (id, category_id, sku, name, unit) VALUES 
(1, 1, 'HRR-001', 'Martillo de Acero 500g', 'UNIDAD'),
(2, 2, 'BEB-001', 'Coca-Cola 2L', 'UNIDAD'),
(3, 2, 'BEB-002', 'Agua Mineral 1L', 'UNIDAD');

INSERT INTO company_products (company_id, product_id) VALUES 
(1, 1),
(2, 2), 
(2, 3);

-- Movimiento Confirmado (Ferretería)
INSERT INTO movements (id, company_id, warehouse_id, type, status, notes) VALUES 
(1, 1, 1, 'IN', 'CONFIRMED', 'Compra inicial de martillos');

INSERT INTO movement_details (id, movement_id, product_id, quantity) VALUES 
(1, 1, 1, 50.00);

INSERT INTO kardex (id, company_id, warehouse_id, product_id, movement_detail_id, transaction_type, quantity, balance_after) VALUES 
(1, 1, 1, 1, 1, 'IN', 50.00, 50.00);

INSERT INTO stocks (product_id, warehouse_id, quantity) VALUES 
(1, 1, 50.00);

-- Movimiento en Borrador (Minimarket)
INSERT INTO movements (id, company_id, warehouse_id, type, status, notes) VALUES 
(2, 2, 2, 'IN', 'DRAFT', 'Llegó el camión, contando mercancía...');

INSERT INTO movement_details (id, movement_id, product_id, quantity) VALUES 
(2, 2, 2, 24.00), 
(3, 2, 3, 12.00);