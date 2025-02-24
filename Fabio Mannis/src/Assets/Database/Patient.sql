CREATE TABLE Patients
(
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), -- Il campo Id viene generato automaticamente come GUID
    FirstName NVARCHAR(100) NOT NULL,                  -- Nome del paziente
    LastName NVARCHAR(100) NOT NULL,                   -- Cognome del paziente
    DateOfBirth DATETIME NOT NULL,                     -- Data di nascita
    FiscalCode NVARCHAR(16) NOT NULL,                  -- Codice fiscale (potrebbe essere un codice di 16 caratteri)
    Address NVARCHAR(255),                             -- Indirizzo
    PhoneNumber NVARCHAR(20)                          -- Numero di telefono
);
