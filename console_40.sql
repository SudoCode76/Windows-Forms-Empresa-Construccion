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
select * from origen;

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
