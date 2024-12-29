var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.CommunityHub_Api>("apiservice");

builder.AddProject<Projects.CommunityHub_Frontend>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
