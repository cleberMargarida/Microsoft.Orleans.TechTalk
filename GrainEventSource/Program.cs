using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.UseLocalhostClustering();
        builder.AddRedisGrainStorageAsDefault(options => options.ConnectionString = "localhost:56677");
    })
    .Build();

await host.StartAsync();

var grainFactory = host.Services.GetRequiredService<IGrainFactory>();
var gpsGrain = grainFactory.GetGrain<IGpsGrain>("PQP-2024");

var actual = await gpsGrain.GetLocalizationsync();
await gpsGrain.RegisterLocalizationsync(16.555, 52.443);

await host.StopAsync();