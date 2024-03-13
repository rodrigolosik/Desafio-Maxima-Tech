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