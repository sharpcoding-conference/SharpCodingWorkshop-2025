var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
                      //.WithImage("docker.io/library/postgres:latest")
                      .WithPgWeb();
var postgresdb = postgres.AddDatabase("postgresdb");

var apiService = builder.AddProject<Projects.CommunityHub_Api>("apiservice")
    .WithReference(postgresdb);

builder.AddProject<Projects.CommunityHub_Frontend>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(postgresdb)
    .WaitFor(apiService);

builder.Build().Run();
