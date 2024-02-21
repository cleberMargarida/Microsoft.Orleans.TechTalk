public class GpsGrain : Grain<Gps>, IGpsGrain
{
    public ValueTask<Gps> GetLocalizationsync()
    {
        return ValueTask.FromResult(State);
    }

    public Task RegisterLocalizationsync(Gps payload)
    {
        State.Latitude = payload.Latitude;
        State.Longitude = payload.Longitude;
        return WriteStateAsync();
    }
}
