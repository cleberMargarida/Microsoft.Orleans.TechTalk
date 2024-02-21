using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans.Configuration;
using Orleans.Versions.Compatibility;
using Orleans.Versions.Selector;

using var host = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.ConfigureLogging(log => log.AddConsole());
        builder.UseLocalhostClustering();
        builder.AddMemoryGrainStorageAsDefault();
        builder.Configure<GrainVersioningOptions>(options =>
        {
            options.DefaultCompatibilityStrategy = nameof(BackwardCompatible);
            options.DefaultVersionSelectorStrategy = nameof(MinimumVersion);
        });
    })
    .Build();

await host.RunAsync();
