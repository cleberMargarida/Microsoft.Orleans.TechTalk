//public class GpsGrain : Grain<Gps>, IGpsGrain
//{
//    public ValueTask<Gps> GetLocalizationsync()
//    {
//        return ValueTask.FromResult(State);
//    }

//    public Task RegisterLocalizationsync(double latitude, double longitude)
//    {
//        State.Latitude = latitude;
//        State.Longitude = longitude;
//        return WriteStateAsync();
//    }
//}

using Orleans.Runtime;

public class GpsGrain : Grain, IGpsGrain
{
    private readonly IPersistentState<Gps> _gps;

    public GpsGrain([PersistentState(nameof(Gps))] IPersistentState<Gps> gps)
    {
        _gps = gps;
    }

    public ValueTask<Gps> GetLocalizationsync()
    {
        return ValueTask.FromResult(_gps.State);
    }

    public Task RegisterLocalizationsync(double latitude, double longitude)
    {
        _gps.State.Latitude = latitude;
        _gps.State.Longitude = longitude;
        return _gps.WriteStateAsync();
    }
}

public interface IGpsGrain : IGrainWithStringKey
{
    Task RegisterLocalizationsync(double latitude, double longitude);
    ValueTask<Gps> GetLocalizationsync();
}
