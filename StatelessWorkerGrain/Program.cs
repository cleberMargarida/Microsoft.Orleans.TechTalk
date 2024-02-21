using MessagePack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = new HostBuilder()
    .UseOrleans(builder => builder.UseLocalhostClustering())
    .Build();

await host.StartAsync();

var grainFactory = host.Services.GetRequiredService<IGrainFactory>();

Gps localization = new()
{
    Latitude = 16.1666,
    Longitude = 52.1666,
};

byte[] serializedLocalization = MessagePackSerializer.Serialize(localization);

var gpsGrain = grainFactory.GetGrain<IGpsGrain>("PQP-2024");
await gpsGrain.RegisterLocalizationsync(serializedLocalization);

await host.StopAsync();