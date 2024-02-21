using Orleans.EventSourcing;

public class GpsGrain : JournaledGrain<Gps, GpsEvent>, IGpsGrain
{
    public ValueTask<Gps> GetLocalizationsync()
    {
        return ValueTask.FromResult(State);
    }

    public Task RegisterLocalizationsync(double latitude, double longitude)
    {
        State.Latitude = latitude;
        State.Longitude = longitude;
        return Task.CompletedTask;
    }

    protected override void OnStateChanged()
    {
        // read state and/or event log and take appropriate action
    }
}

public interface IGpsGrain : IGrainWithStringKey
{
    Task RegisterLocalizationsync(double latitude, double longitude);
    ValueTask<Gps> GetLocalizationsync();
}

public class GpsEvent
{
}
