using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = new HostBuilder()
    .UseOrleans(builder =>
    {
        builder.UseLocalhostClustering();

        //builder.AddMemoryGrainStorageAsDefault();

        builder.AddRedisGrainStorageAsDefault(options => options.ConnectionString = "localhost:56677");

        //http://aka.ms/orleans-sql-scripts
        //builder.AddAdoNetGrainStorage("sqlserver", options => options.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Orleans;Integrated Security=True;Persist Security Info=False");
    })
    .Build();

await host.StartAsync();

var grainFactory = host.Services.GetRequiredService<IGrainFactory>();
var gpsGrain = grainFactory.GetGrain<IGpsGrain>("PQP-2024");
var actual = await gpsGrain.GetLocalizationsync();
await gpsGrain.RegisterLocalizationsync(16.555, 52.443);

await host.StopAsync();