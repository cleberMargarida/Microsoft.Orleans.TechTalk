using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans.Runtime;
using Orleans.Runtime.Placement;

using var host = new HostBuilder()
    .UseOrleans(siloBuilder =>
    {
        siloBuilder.UseLocalhostClustering();
        #region more
        siloBuilder.ConfigureServices(services =>
        {
            services.AddSingletonNamedService<PlacementStrategy, SamplePlacementStrategy>(nameof(SamplePlacementStrategy));
            services.AddSingletonKeyedService<Type, IPlacementDirector, SamplePlacementStrategyFixedSiloDirector>(typeof(SamplePlacementStrategy));
        });
        #endregion
    })
    .Build();

await host.StartAsync();

var grainFactory = host.Services.GetRequiredService<IGrainFactory>();
var friend = grainFactory.GetGrain<IPlacementSampleGrain>("friend");
var result = await friend.SayHello("Good morning!");

await host.StopAsync();
