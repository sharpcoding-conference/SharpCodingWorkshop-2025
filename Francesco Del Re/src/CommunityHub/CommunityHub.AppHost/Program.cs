using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
                      //.WithEnvironment("POSTGRES_USER", "postgres")
                      //.WithEnvironment("POSTGRES_PASSWORD", "password")
                      .WithPgWeb();
var postgresdb = postgres.AddDatabase("postgresdb");

var cache = builder.AddRedis("cache")
    .WithRedisInsight();

var apiService = builder.AddProject<Projects.CommunityHub_Api>("apiservice")
    .WithReference(postgresdb);

builder.AddProject<Projects.CommunityHub_Frontend>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(postgresdb)
    .WithReference(cache)
    .WaitFor(apiService);

builder.Build().Run();
