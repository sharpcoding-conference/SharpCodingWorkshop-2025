CREATE DATABASE AnagraficaPazienti;
GO
USE AnagraficaPazienti;
GO

-- Tabella Paziente
CREATE TABLE Paziente (
    ID_Paziente UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Nome NVARCHAR(100) NOT NULL,
    Cognome NVARCHAR(100) NOT NULL,
    Data_Nascita DATE NOT NULL,
    Codice_Fiscale NVARCHAR(16) UNIQUE NOT NULL,
    Indirizzo NVARCHAR(255),
    Telefono NVARCHAR(20),
    Email NVARCHAR(100) UNIQUE
);
GO

-- Tabella Cartella Clinica
CREATE TABLE CartellaClinica (
    ID_Cartella UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ID_Paziente UNIQUEIDENTIFIER NOT NULL,
    Gruppo_Sanguigno NVARCHAR(5),
    Allergie NVARCHAR(255),
    Patologie_Pregresse NVARCHAR(255),
    CONSTRAINT FK_Cartella_Paziente FOREIGN KEY (ID_Paziente) REFERENCES Paziente(ID_Paziente) ON DELETE CASCADE
);
GO

-- Tabella Medico Curante
CREATE TABLE MedicoCurante (
    ID_Medico UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Nome NVARCHAR(100) NOT NULL,
    Cognome NVARCHAR(100) NOT NULL,
    Specializzazione NVARCHAR(100),
    Contatti NVARCHAR(255)
);
GO

-- Tabella Specialista
CREATE TABLE Specialista (
    ID_Specialista UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Nome NVARCHAR(100) NOT NULL,
    Cognome NVARCHAR(100) NOT NULL,
    Specializzazione NVARCHAR(100),
    Struttura_Sanitaria NVARCHAR(255),
    Contatti NVARCHAR(255)
);
GO

-- Tabella Relazione Paziente-Specialista (N:M)
CREATE TABLE PazienteSpecialista (
    ID_Paziente UNIQUEIDENTIFIER NOT NULL,
    ID_Specialista UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (ID_Paziente, ID_Specialista),
    CONSTRAINT FK_Paziente_Specialista_P FOREIGN KEY (ID_Paziente) REFERENCES Paziente(ID_Paziente) ON DELETE CASCADE,
    CONSTRAINT FK_Paziente_Specialista_S FOREIGN KEY (ID_Specialista) REFERENCES Specialista(ID_Specialista) ON DELETE CASCADE
);
GO

-- Tabella Contatto di Emergenza
CREATE TABLE ContattoEmergenza (
    ID_Contatto UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ID_Paziente UNIQUEIDENTIFIER NOT NULL,
    Nome NVARCHAR(100) NOT NULL,
    Cognome NVARCHAR(100) NOT NULL,
    Relazione NVARCHAR(50),
    Telefono NVARCHAR(20),
    CONSTRAINT FK_Contatto_Paziente FOREIGN KEY (ID_Paziente) REFERENCES Paziente(ID_Paziente) ON DELETE CASCADE
);
GO

-- Tabella Visita Medica
CREATE TABLE VisitaMedica (
    ID_Visita UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ID_Paziente UNIQUEIDENTIFIER NOT NULL,
    ID_Medico UNIQUEIDENTIFIER NOT NULL,
    Data_Visita DATE NOT NULL,
    Diagnosi NVARCHAR(500),
    Terapia NVARCHAR(500),
    CONSTRAINT FK_Visita_Paziente FOREIGN KEY (ID_Paziente) REFERENCES Paziente(ID_Paziente) ON DELETE CASCADE,
    CONSTRAINT FK_Visita_Medico FOREIGN KEY (ID_Medico) REFERENCES MedicoCurante(ID_Medico)
);
GO

-- Tabella Esame Diagnostico
CREATE TABLE EsameDiagnostico (
    ID_Esame UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ID_Paziente UNIQUEIDENTIFIER NOT NULL,
    Tipo_Esame NVARCHAR(100) NOT NULL,
    Data_Esame DATE NOT NULL,
    Esito NVARCHAR(500),
    CONSTRAINT FK_Esame_Paziente FOREIGN KEY (ID_Paziente) REFERENCES Paziente(ID_Paziente) ON DELETE CASCADE
);
GO

-- Tabella Consensi e Privacy
CREATE TABLE ConsensiPrivacy (
    ID_Consenso UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ID_Paziente UNIQUEIDENTIFIER NOT NULL UNIQUE,
    Consenso_Dati_Sanitari BIT NOT NULL,
    Consenso_Contatti BIT NOT NULL,
    Data_Firma DATE NOT NULL,
    CONSTRAINT FK_Consenso_Paziente FOREIGN KEY (ID_Paziente) REFERENCES Paziente(ID_Paziente) ON DELETE CASCADE
);
GO

-- Tabella Documenti Allegati
CREATE TABLE DocumentoAllegato (
    ID_Documento UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ID_Paziente UNIQUEIDENTIFIER NOT NULL,
    Tipo_Documento NVARCHAR(100),
    File_Allegato VARBINARY(MAX),
    Data_Caricamento DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Documento_Paziente FOREIGN KEY (ID_Paziente) REFERENCES Paziente(ID_Paziente) ON DELETE CASCADE
);
GO
