namespace OrleansSample
{
    public interface IRandomPlacementGrain : IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }

    public interface IHashBasedPlacementGrain : IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }

    public interface IPreferLocalPlacementGrain : IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }
    public interface IActivationCountBasedPlacementGrain : IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }

    public interface IStatelessWorkerGrain : IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }

    public interface ISiloRoleBasedPlacementGrain : IGrainWithIntegerKey
    {
        Task<string> SayHello(string greeting);
    }
}
