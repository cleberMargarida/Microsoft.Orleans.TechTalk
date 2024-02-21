using Orleans.EventSourcing;

public class GpsGrain : JournaledGrain<Gps, >, IGpsGrain
{
    public ValueTask<Gps> GetLocalizationsync()
    {
        return ValueTask.FromResult(State);
    }

    public Task RegisterLocalizationsync(double latitude, double longitude)
    {
        State.Latitude = latitude;
        State.Longitude = longitude;
        return WriteStateAsync();
    }
}

public interface IGpsGrain : IGrainWithStringKey
{
    Task RegisterLocalizationsync(double latitude, double longitude);
    ValueTask<Gps> GetLocalizationsync();
}
