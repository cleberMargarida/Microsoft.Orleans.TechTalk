using Orleans.Concurrency;
using Orleans.Placement;
using Orleans.Runtime;

namespace OrleansSample
{
    [RandomPlacement] // Random, simple.
    public class RandomPlacementGrain : Grain, IRandomPlacementGrain
    {
        public Task<string> SayHello(string greeting)
        {
            return Task.FromResult($"RandomPlacement: Hello, {greeting}!");
        }
    }

    [HashBasedPlacement] // Hash the grain id to a non-negative integer and modulo it with the number of compatible servers.
    public class HashBasedPlacementGrain : Grain, IHashBasedPlacementGrain
    {
        public Task<string> SayHello(string greeting)
        {
            return Task.FromResult($"HashBasedPlacement: Hello, {greeting}!");
        }
    }

    [PreferLocalPlacement] // Most used by Ariadne. If the local server is compatible, select the local server, otherwise select a random server.
    public class PreferLocalPlacementGrain : Grain, IPreferLocalPlacementGrain
    {
        public Task<string> SayHello(string greeting)
        {
            return Task.FromResult($"PreferLocalPlacement: Hello, {greeting}!");
        }
    }

    [ActivationCountBasedPlacement] // Based on the "Power of Two Choices" in randomized load balancing.
    public class ActivationCountBasedPlacementGrain : Grain, IActivationCountBasedPlacementGrain
    {
        public Task<string> SayHello(string greeting)
        {
            return Task.FromResult($"ActivationCountBasedPlacement: Hello, {greeting}!");
        }
    }

    [StatelessWorker] // Special placement strategy used by stateless worker grains.
    public class StatelessWorkerGrain : Grain, IStatelessWorkerGrain
    {
        public Task<string> SayHello(string greeting)
        {
            return Task.FromResult($"StatelessWorker: Hello, {greeting}!");
        }
    }
  
    [SiloRoleBasedPlacement] // Places grains on silos with a specific role.
    public class SiloRoleBasedPlacementGrain : Grain, ISiloRoleBasedPlacementGrain
    {
        public Task<string> SayHello(string greeting)
        {
            return Task.FromResult($"SiloRoleBasedPlacement: Hello, {greeting}!");
        }
    }

}
