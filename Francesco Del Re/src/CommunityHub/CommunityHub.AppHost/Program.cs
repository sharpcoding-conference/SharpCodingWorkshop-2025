using Aspire.Hosting;
using Npgsql;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres").WithPgWeb();
var postgresdb = postgres.AddDatabase("postgresdb");

var cache = builder.AddRedis("cache")
    .WithRedisInsight();

var apiService = builder.AddProject<Projects.CommunityHub_Api>("apiservice")
    .WithReference(postgresdb)
    .WaitFor(postgresdb);

builder.AddProject<Projects.CommunityHub_Frontend>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(postgresdb)
    .WithReference(cache)
    .WaitFor(apiService);

builder.Build().Run();