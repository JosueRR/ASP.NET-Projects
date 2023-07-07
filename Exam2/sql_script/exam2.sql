/* Examen 2 */
/* Josué Retana Rodriguez C06440 */

use C06440

-- Create table for escuelas
CREATE TABLE Escuelas (
	Id INTEGER PRIMARY KEY IDENTITY,
    Nombre VARCHAR(255) NOT NULL,
    Provincia VARCHAR(255) NOT NULL,
    Estado VARCHAR(255) NOT NULL,
    NumeroAulas INT NOT NULL,
    EsPublica BIT NOT NULL
);


-- Create data samples
INSERT INTO Escuelas (Nombre, Provincia, Estado, NumeroAulas, EsPublica)
VALUES
    ('Escuela Primaria Central', 'San Jose', 'San Jose Centro', 10, 1),
    ('Escuela Santa Ana Norte', 'San Jose', 'Santa Ana', 8, 1),
    ('Escuela Manuel Antonio', 'Puntarenas', 'Quepos', 6, 1);


-- View of table
Select * from Escuelas

-- Testing you are NOT supposed to run this
UPDATE [dbo].[Escuelas] SET EsPublica = 0 WHERE Id = 3;	-- for updating a school
DELETE [dbo].[Escuelas] WHERE Id=4
DROP TABLE Escuelas;									-- for deleting the table
