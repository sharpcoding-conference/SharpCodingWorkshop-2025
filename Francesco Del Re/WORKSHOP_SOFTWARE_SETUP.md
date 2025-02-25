# Guida all'Installazione dei Software per il Workshop Sharpcoding 2025

Benvenuti al workshop! Per partecipare, assicurati di aver installato i seguenti pacchetti e software sul tuo computer. 
Segui le istruzioni di installazione passo-passo per ogni strumento.

## Software e configurazioni

### 1. Clonare il repository
Clona il repository del workshop sul tuo computer utilizzando il seguente comando:

```bash
    git clone https://github.com/sharpcoding-conference/SharpCodingWorkshop-2025.git
```

### 2. **Visual Studio 2022**
Visual Studio è l'IDE che utilizzeremo per lo sviluppo durante il workshop. Ecco come installarlo:

#### Istruzioni di Installazione:
- Vai su [Visual Studio 2022 Download](https://visualstudio.microsoft.com/downloads/).
- Seleziona la versione **Community** (gratuita) o una delle altre versioni a pagamento.
- Durante l'installazione, seleziona i seguenti carichi di lavoro:
  - **.NET desktop development**
  - **ASP.NET and web development**
  - **Data storage and processing** (opzionale, se lavori con database)
- Completa l'installazione e avvia Visual Studio.

### 4. **Docker**
Docker è una piattaforma che consente di creare, distribuire ed eseguire applicazioni in container.

#### Istruzioni di Installazione:
- Vai su [Docker Official Website](https://www.docker.com/products/docker-desktop) e scarica Docker Desktop.

### 5. **Podman e Podman Desktop** (alternativa a Docker)
Se preferisci utilizzare un'alternativa open-source e gratuita a Docker Desktop, puoi configurare Podman, un motore container compatibile con Docker.

#### Istruzioni di Installazione:
- Vai su [Podman Official Website](https://podman.io)
- Seleziona la versione compatibile per il sistema operativo di riferimento.
- Configura una **podman machine** con il comando ```podman machine init```.
Se sei su Windows, ti verrà richiesta l'installazione del sottosistema Windows for Linux (WSL), in alternativa puoi installare il sottosistema manualmente. Per ulteriori dettagli consulta la documentazione ufficiale: https://github.com/containers/podman/blob/main/docs/tutorials/podman-for-windows.md 
- Assicuratevi che sia abilitata la virtualizzazione sul vostro OS, per [abilitarla](https://support.microsoft.com/en-us/windows/enable-virtualization-on-windows-c5578302-6e43-4b4b-a449-8ced115f58e1)

## Altre informazioni utili:
- [.NET Aspire setup and tooling](https://learn.microsoft.com/en-us/dotnet/aspire/fundamentals/setup-tooling?tabs=windows&pivots=visual-studio)
