// Creazione di un oggetto builder per configurare l'applicazione distribuita
var builder = DistributedApplication.CreateBuilder(args);

// Definizione e aggiunta di un'istanza di PostgreSQL all'applicazione distribuita
// Il metodo WithPgWeb() aggiunge un'interfaccia web per la gestione del database PostgreSQL
var postgres = builder
    .AddPostgres("postgres")
    .WithPgWeb();

// Creazione di un database specifico all'interno dell'istanza PostgreSQL
var postgresdb = postgres.AddDatabase("postgresdb");

// Aggiunta di un'istanza di Redis all'applicazione distribuita per la gestione della cache
// WithRedisInsight() abilita un'interfaccia web per monitorare Redis
var cache = builder
    .AddRedis("cache")
    .WithRedisInsight();

// Definizione e configurazione del servizio API principale dell'applicazione
var apiService = builder
    .AddProject<Projects.CommunityHub_Api>("apiservice")
    .WithReference(postgresdb) // L'API fa riferimento al database PostgreSQL
    .WaitFor(postgresdb); // Si assicura che il database sia pronto prima di avviare il servizio API

// L'API fa riferimento al database PostgreSQL
builder.AddProject<Projects.CommunityHub_Frontend>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(postgresdb)
    .WithReference(cache)
    .WaitFor(apiService);

// Costruzione e avvio dell'applicazione distribuita
builder.Build().Run();