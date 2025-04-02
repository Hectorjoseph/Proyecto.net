
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Contraseña NVARCHAR(255) NOT NULL,
    FechaCreacion DATETIME NOT NULL DEFAULT GETDATE() 
);
GO

CREATE TABLE Lugares (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Nombre NVARCHAR(100) NOT NULL,
    Tipo NVARCHAR(50) NOT NULL,
    Latitud DECIMAL(9,6) NOT NULL, 
    Longitud DECIMAL(9,6) NOT NULL,
    Calificacion DECIMAL(2,1) NULL 
);
GO


CREATE TABLE Climas (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Temperatura DECIMAL(5,2) NOT NULL,
    Humedad DECIMAL(5,2) NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    LugarId INT NOT NULL,
    CONSTRAINT FK_Climas_Lugares FOREIGN KEY (LugarId) REFERENCES Lugares(Id)
);
GO

CREATE TABLE Rutas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Origen NVARCHAR(100) NOT NULL,
    Destino NVARCHAR(100) NOT NULL,
    Distancia DECIMAL(10,2) NOT NULL,
    TiempoEstimado DECIMAL(5,2) NOT NULL,
    UsuarioId INT NOT NULL, 
    CONSTRAINT FK_Rutas_Usuarios FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);
GO

CREATE TABLE PuntosRuta (
    Id INT PRIMARY KEY IDENTITY(1,1), 
    Orden INT NOT NULL,
    LugarId INT NOT NULL, 
    RutaId INT NOT NULL,
    CONSTRAINT FK_PuntosRuta_Lugares FOREIGN KEY (LugarId) REFERENCES Lugares(Id),
    CONSTRAINT FK_PuntosRuta_Rutas FOREIGN KEY (RutaId) REFERENCES Rutas(Id)
);
GO

INSERT INTO Lugares (Nombre, Tipo, Latitud, Longitud, Calificacion)
VALUES 
    ('Parque Tayrona', 'Parque Nacional', 11.311400, -74.077088, 4.8),
    ('Ciudad Amurallada de Cartagena', 'Sitio Histórico', 10.423603, -75.546289, 4.9),
    ('Comuna 13 de Medellín', 'Atracción Cultural', 6.248607, -75.573891, 4.7),
    ('Caño Cristales', 'Maravilla Natural', 2.259444, -73.797222, 4.9),
    ('Catedral de Sal de Zipaquirá', 'Monumento', 5.020833, -74.006944, 4.6);
GO

INSERT INTO Climas (Temperatura, Humedad, Estado, LugarId)
VALUES 
    (28.5, 80.0, 'Soleado', 1),  -- Tayrona
    (32.0, 75.0, 'Caluroso', 2),  -- Cartagena
    (22.5, 65.0, 'Parcialmente nublado', 3); -- Medellín
GO

CREATE INDEX IX_Climas_LugarId ON Climas(LugarId);
CREATE INDEX IX_PuntosRuta_LugarId ON PuntosRuta(LugarId);
CREATE INDEX IX_PuntosRuta_RutaId ON PuntosRuta(RutaId);
GO