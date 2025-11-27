-- Creación de la base de datos
CREATE DATABASE distribucion_materiales;

-- Conectar a la base de datos
\c distribucion_materiales;

-- Tabla para Orígenes
CREATE TABLE origen (
    id_origen SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    tipo VARCHAR(50),  -- fábrica, almacén, centro de acopio
    capacidad_produccion INT,  -- capacidad de oferta
    ubicacion VARCHAR(255)  -- ubicación del origen
);

-- Tabla para Destinos
CREATE TABLE destino (
    id_destino SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    tipo VARCHAR(50),  -- zona, sucursal, institución
    demanda INT,  -- cantidad demandada
    ubicacion VARCHAR(255)  -- ubicación del destino
);

-- Tabla para Productos
CREATE TABLE producto (
    id_producto SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    tipo_producto VARCHAR(50),  -- alimento, vacuna, material de construcción, etc.
    unidad_medida VARCHAR(50),  -- por ejemplo, kg, unidades, metros cúbicos
    cantidad_disponible INT  -- cantidad disponible en el origen
);

-- Tabla para Rutas de distribución (origen-destino)
CREATE TABLE ruta (
    id_ruta SERIAL PRIMARY KEY,
    id_origen INT REFERENCES origen(id_origen),
    id_destino INT REFERENCES destino(id_destino),
    costo_transporte DECIMAL(10, 2),  -- costo del transporte
    distancia_km DECIMAL(10, 2),  -- distancia en kilómetros
    tiempo_horas DECIMAL(10, 2),  -- tiempo estimado de transporte en horas
    capacidad_requerida INT  -- capacidad de transporte requerida
);

-- Tabla para Distribución de productos
CREATE TABLE distribucion (
    id_distribucion SERIAL PRIMARY KEY,
    id_ruta INT REFERENCES ruta(id_ruta),
    id_producto INT REFERENCES producto(id_producto),
    cantidad_enviada INT  -- cantidad de producto enviada por esta ruta
);

-- Tabla para la demanda y oferta total (usada para cálculos)
CREATE TABLE oferta_demanda (
    id_oferta_demanda SERIAL PRIMARY KEY,
    id_origen INT REFERENCES origen(id_origen),
    id_destino INT REFERENCES destino(id_destino),
    oferta INT,  -- oferta disponible en el origen
    demanda INT   -- demanda en el destino
);

-- Tabla para modelos de optimización (costos totales, soluciones, etc.)
CREATE TABLE modelo_optimizacion (
    id_modelo SERIAL PRIMARY KEY,
    metodo VARCHAR(50),  -- 'Noroeste', 'Vogel', etc.
    costo_total DECIMAL(10, 2),  -- costo total calculado
    solucion TEXT  -- solución en formato texto o JSON
);

-- Tabla para almacenar registros de transporte por fecha
CREATE TABLE registro_transporte (
    id_registro SERIAL PRIMARY KEY,
    id_ruta INT REFERENCES ruta(id_ruta),
    fecha TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    cantidad_enviada INT  -- cantidad de producto enviada en esta fecha
);


CREATE TABLE usuario (
  id_usuario SERIAL PRIMARY KEY,
  usuario varchar (10),
  password varchar (10)
);

INSERT INTO usuario (usuario, password) VALUES
('admin', 'admin');
SELECT COUNT(*) FROM usuario WHERE usuario = 'admin' AND password = 'admin';



-- =====================================================
-- INSERCIÓN DE DATOS - DISTRIBUCIÓN DE MATERIALES
-- =====================================================

-- 1. ORÍGENES (Almacenes Regionales)
INSERT INTO origen (nombre, tipo, capacidad_produccion, ubicacion) VALUES
('Almacén Regional Norte', 'almacén', 15000, 'Santa Cruz - Av. Cristo Redentor Km 7'),
('Almacén Regional Sur', 'almacén', 12000, 'Santa Cruz - Carretera a Cotoca Km 9'),
('Centro de Acopio Central', 'centro de acopio', 18000, 'Santa Cruz - Parque Industrial');

-- 2. DESTINOS (Obras y Municipalidades)
INSERT INTO destino (nombre, tipo, demanda, ubicacion) VALUES
('Obra Puente El Urubó', 'obra en ejecución', 5000, 'El Urubó - Carretera antigua'),
('Municipalidad de Warnes', 'municipalidad', 4500, 'Warnes - Plaza Principal'),
('Obra Hospital La Guardia', 'obra en ejecución', 6000, 'La Guardia - Zona Norte'),
('Municipalidad de Porongo', 'municipalidad', 3500, 'Porongo - Centro'),
('Obra Complejo Deportivo Cotoca', 'obra en ejecución', 4000, 'Cotoca - Zona Este');

-- 3. PRODUCTOS (Materiales de Construcción)
INSERT INTO producto (nombre, tipo_producto, unidad_medida, cantidad_disponible) VALUES
('Cemento Portland', 'material construcción', 'bolsas 50kg', 25000),
('Arena lavada', 'agregado', 'metros cúbicos', 8000),
('Grava triturada', 'agregado', 'metros cúbicos', 7500),
('Ladrillos gambote', 'material construcción', 'unidades', 150000),
('Fierro corrugado 12mm', 'acero', 'barras 12m', 5000),
('Bloques de hormigón', 'material construcción', 'unidades', 80000);

-- 4. RUTAS (Origen-Destino con costos realistas)
-- Desde Almacén Regional Norte
INSERT INTO ruta (id_origen, id_destino, costo_transporte, distancia_km, tiempo_horas, capacidad_requerida) VALUES
(1, 1, 450.00, 18.5, 0.75, 5000),  -- Norte -> Obra El Urubó
(1, 2, 380.00, 15.2, 0.60, 4500),  -- Norte -> Warnes
(1, 3, 520.00, 22.8, 0.95, 6000),  -- Norte -> Obra La Guardia
(1, 4, 680.00, 28.4, 1.20, 3500),  -- Norte -> Porongo
(1, 5, 420.00, 16.7, 0.70, 4000);  -- Norte -> Obra Cotoca

-- Desde Almacén Regional Sur
INSERT INTO ruta (id_origen, id_destino, costo_transporte, distancia_km, tiempo_horas, capacidad_requerida) VALUES
(2, 1, 580.00, 25.3, 1.05, 5000),  -- Sur -> Obra El Urubó
(2, 2, 720.00, 31.5, 1.35, 4500),  -- Sur -> Warnes
(2, 3, 490.00, 19.8, 0.85, 6000),  -- Sur -> Obra La Guardia
(2, 4, 350.00, 13.6, 0.55, 3500),  -- Sur -> Porongo
(2, 5, 320.00, 11.9, 0.50, 4000);  -- Sur -> Obra Cotoca

-- Desde Centro de Acopio Central
INSERT INTO ruta (id_origen, id_destino, costo_transporte, distancia_km, tiempo_horas, capacidad_requerida) VALUES
(3, 1, 510.00, 21.0, 0.88, 5000),  -- Central -> Obra El Urubó
(3, 2, 440.00, 17.5, 0.73, 4500),  -- Central -> Warnes
(3, 3, 550.00, 23.5, 0.98, 6000),  -- Central -> Obra La Guardia
(3, 4, 590.00, 25.8, 1.08, 3500),  -- Central -> Porongo
(3, 5, 380.00, 14.8, 0.62, 4000);  -- Central -> Obra Cotoca

-- 5. OFERTA Y DEMANDA (Para el modelo de transporte)
INSERT INTO oferta_demanda (id_origen, id_destino, oferta, demanda) VALUES
-- Ofertas por origen (total disponible)
(1, 1, 15000, 5000),
(1, 2, 15000, 4500),
(1, 3, 15000, 6000),
(1, 4, 15000, 3500),
(1, 5, 15000, 4000),

(2, 1, 12000, 5000),
(2, 2, 12000, 4500),
(2, 3, 12000, 6000),
(2, 4, 12000, 3500),
(2, 5, 12000, 4000),

(3, 1, 18000, 5000),
(3, 2, 18000, 4500),
(3, 3, 18000, 6000),
(3, 4, 18000, 3500),
(3, 5, 18000, 4000);

-- 6. DISTRIBUCIÓN INICIAL (Ejemplos de envíos realizados)
INSERT INTO distribucion (id_ruta, id_producto, cantidad_enviada) VALUES
-- Distribución desde Almacén Norte
(1, 1, 800),   -- Cemento a Obra El Urubó
(2, 4, 15000), -- Ladrillos a Warnes
(3, 5, 250),   -- Fierro a Obra La Guardia

-- Distribución desde Almacén Sur
(8, 2, 120),   -- Arena a Obra La Guardia
(10, 3, 95),   -- Grava a Obra Cotoca

-- Distribución desde Centro Acopio
(11, 1, 600),  -- Cemento a Obra El Urubó
(14, 6, 8000); -- Bloques a Porongo

-- 7. REGISTRO DE TRANSPORTES (Historial)
INSERT INTO registro_transporte (id_ruta, fecha, cantidad_enviada) VALUES
(1, '2025-01-15 08:30:00', 800),
(2, '2025-01-16 09:15:00', 15000),
(3, '2025-01-17 10:00:00', 250),
(8, '2025-01-18 07:45:00', 120),
(10, '2025-01-19 11:20:00', 95),
(11, '2025-01-20 08:00:00', 600),
(14, '2025-01-21 09:30:00', 8000),
(5, '2025-01-22 10:15:00', 450),
(7, '2025-01-23 08:45:00', 5500),
(13, '2025-01-24 09:00:00', 180);

-- 8. MODELOS DE OPTIMIZACIÓN (Resultados esperados para comparar)
INSERT INTO modelo_optimizacion (metodo, costo_total, solucion) VALUES
('Esquina Noroeste', 0.00, 'Pendiente de cálculo'),
('Método de Vogel', 0.00, 'Pendiente de cálculo'),
('Método Óptimo', 0.00, 'Pendiente de cálculo');

-- =====================================================
-- CONSULTAS ÚTILES PARA VERIFICAR LOS DATOS
-- =====================================================

-- Ver matriz de costos
SELECT
    o.nombre as origen,
    d.nombre as destino,
    r.costo_transporte,
    r.distancia_km,
    r.tiempo_horas
FROM ruta r
JOIN origen o ON r.id_origen = o.id_origen
JOIN destino d ON r.id_destino = d.id_destino
ORDER BY o.nombre, d.nombre;

-- Ver oferta total vs demanda total
SELECT
    SUM(DISTINCT o.capacidad_produccion) as oferta_total,
    SUM(DISTINCT d.demanda) as demanda_total
FROM origen o, destino d;

-- Ver distribuciones realizadas con productos
SELECT
    o.nombre as origen,
    d.nombre as destino,
    p.nombre as producto,
    dist.cantidad_enviada,
    r.costo_transporte,
    (dist.cantidad_enviada * r.costo_transporte / r.capacidad_requerida) as costo_parcial
FROM distribucion dist
JOIN ruta r ON dist.id_ruta = r.id_ruta
JOIN origen o ON r.id_origen = o.id_origen
JOIN destino d ON r.id_destino = d.id_destino
JOIN producto p ON dist.id_producto = p.id_producto
ORDER BY o.nombre;