# Guida all'Installazione dei Software per il Workshop Sharpcoding 2025

Benvenuti al workshop! Per partecipare, assicurati di aver installato i seguenti pacchetti e software sul tuo computer. Segui le istruzioni di installazione passo-passo per ogni strumento.

## Software Richiesti

### 1. **Visual Studio 2022**
Visual Studio è l'IDE che utilizzeremo per lo sviluppo durante il workshop. Ecco come installarlo:

#### Istruzioni di Installazione:
- Vai su [Visual Studio 2022 Download](https://visualstudio.microsoft.com/downloads/).
- Seleziona la versione **Community** (gratuita) o una delle altre versioni a pagamento.
- Durante l'installazione, seleziona i seguenti carichi di lavoro:
  - **.NET desktop development**
  - **ASP.NET and web development**
  - **Data storage and processing** (opzionale, se lavori con database)
- Completa l'installazione e avvia Visual Studio.

### 2. **PostgreSQL**
PostgreSQL è il sistema di gestione di database che utilizzeremo per il workshop. Segui questi passaggi per installarlo:

#### Istruzioni di Installazione:
- Vai su [PostgreSQL Official Website](https://www.postgresql.org/download/).
- Scegli il tuo sistema operativo e segui le istruzioni.
  - **Windows**: Scarica l'installer e segui la procedura guidata.
  - **macOS**: Usa **Homebrew**:
    ```bash
    brew install postgresql
    ```
  - **Linux** (Ubuntu/Debian):
    ```bash
    sudo apt update
    sudo apt install postgresql postgresql-contrib
    ```
- Durante l'installazione, prendi nota della password dell'utente `postgres`.
- Una volta installato, avvia il servizio PostgreSQL. Puoi farlo dal terminale con:
  - **Windows/macOS**: Utilizza l'app pgAdmin o avvia il servizio tramite il terminale.
  - **Linux**: Usa `sudo systemctl start postgresql`.

### 3. **pgAdmin (opzionale ma consigliato)**
pgAdmin è un'interfaccia grafica per gestire PostgreSQL. Ti aiuterà a interagire con il database in modo più semplice.

#### Istruzioni di Installazione:
- Vai su [pgAdmin Official Website](https://www.pgadmin.org/download/).
- Scarica e installa la versione corretta per il tuo sistema operativo.
- Dopo l'installazione, puoi connetterti al tuo database PostgreSQL utilizzando pgAdmin.

### 4. **Docker (Opzionale per la configurazione rapida di PostgreSQL)**
Se preferisci non installare PostgreSQL direttamente sul tuo sistema, puoi usare Docker per eseguire una versione contenuta di PostgreSQL.

#### Istruzioni di Installazione:
- Vai su [Docker Official Website](https://www.docker.com/products/docker-desktop) e scarica Docker Desktop.
- Dopo averlo installato, esegui il comando seguente per avviare una istanza di PostgreSQL in un container Docker:
  ```bash
  docker run --name postgres-local -e POSTGRES_USER=myuser -e POSTGRES_PASSWORD=mypassword -e POSTGRES_DB=mydb -p 5432:5432 -d postgres

### 5. **Driver .NET per PostgreSQL (Npgsql)**
Per interagire con PostgreSQL da una applicazione .NET, è necessario installare il driver Npgsql, che è una libreria ADO.NET per PostgreSQL.

- Istruzioni di Installazione:
  - Installa il pacchetto NuGet Npgsql:
    Puoi aggiungere il pacchetto Npgsql tramite il comando NuGet o la GUI di Visual Studio:
    Via CLI (dotnet):
    
    ```bash
    dotnet add package Npgsql
    ```

    Via GUI (Visual Studio):
    Apri NuGet Package Manager.
    Cerca Npgsql.
    Clicca su "Install" per aggiungere il pacchetto al tuo progetto.

### 6. Clonare il repository
Clona il repository del workshop sul tuo computer utilizzando il seguente comando:

```bash
    git clone https://github.com/sharpcoding-conference/SharpCodingWorkshop-2025.git
```
