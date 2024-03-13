CREATE TABLE Departments (
	Id CHAR(36),
	Code VARCHAR(5) NOT NULL,
	Description VARCHAR(100) NOT NULL,
	PRIMARY KEY (Id)
);

CREATE TABLE Products (
	Id CHAR(36),
	Code VARCHAR(5) NOT NULL,
	Description VARCHAR(100) NOT NULL,
	DepartmentId CHAR(36),
	Price DECIMAL(10,2) NOT NULL,
	Status BIT DEFAULT 1,
	PRIMARY KEY(Id),
	FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

INSERT INTO Departments (Id, Code, Description) 
VALUES
(UUID(), "010", "BEBIDAS"),
(UUID(), "020", "CONGELADOS"),
(UUID(), "030", "LATICINIOS"),
(UUID(), "040", "VEGETAIS");