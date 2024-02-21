using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .UseOrleansClient(clientBuilder =>
        clientBuilder.UseLocalhostClustering())
    .Build();

await host.StartAsync();

var client = host.Services.GetRequiredService<IClusterClient>();
var gpsGrain = client.GetGrain<IGpsGrain>("PQP-2024");
await gpsGrain.RegisterLocalizationsync(new Gps { Latitude = 11.566, Longitude = 16.768, Altitude = 0 });
var result = await gpsGrain.GetLocalizationsync();

await host.StopAsync();
