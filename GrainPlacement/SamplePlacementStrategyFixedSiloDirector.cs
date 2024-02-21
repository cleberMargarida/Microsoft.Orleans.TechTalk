using Orleans.Runtime;
using Orleans.Runtime.Placement;

public class SamplePlacementStrategyFixedSiloDirector : IPlacementDirector
{
    public Task<SiloAddress> OnAddActivation(
    PlacementStrategy strategy,
    PlacementTarget target,
    IPlacementContext context)
    {
        var silos = context.GetCompatibleSilos(target).OrderBy(s => s).ToArray();
        int silo = GetSiloNumber(target.GrainIdentity.Key, silos.Length);
        return Task.FromResult(silos[silo]);
    }

    private int GetSiloNumber(object primaryKey, int length)
    {
        throw new NotImplementedException();
    }
}
