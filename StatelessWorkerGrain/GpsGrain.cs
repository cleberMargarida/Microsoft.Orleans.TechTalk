public class GpsGrain : Grain, IGpsGrain
{
    private Gps _gps = default!;

    public async ValueTask RegisterLocalizationsync(byte[] serializedLocal)
    {
        //Stateless
        IGpsDeserializerGrain deserializerGrain = GrainFactory.GetGrain<IGpsDeserializerGrain>(0);

        _gps = await deserializerGrain.DeserializeAsync<Gps>(serializedLocal);
    }

    public ValueTask<Gps> GetLocalizationsync()
    {
        return ValueTask.FromResult(_gps);
    }
}

public interface IGpsGrain : IGrainWithStringKey
{
    ValueTask RegisterLocalizationsync(byte[] payload);
    ValueTask<Gps> GetLocalizationsync();
}
