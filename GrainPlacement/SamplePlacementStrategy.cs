using Orleans.Placement;
using Orleans.Runtime;

[Serializable]
public sealed class SamplePlacementStrategy : PlacementStrategy
{
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class SamplePlacementStrategyAttribute : PlacementAttribute
{
    public SamplePlacementStrategyAttribute() :
    base(new SamplePlacementStrategy())
    {
    }
}
