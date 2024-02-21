using Orleans.CodeGeneration;

[Version(2)]
public interface IGpsGrain : IGrainWithStringKey
{
    Task RegisterLocalizationsync(Gps payload);
    ValueTask<Gps> GetLocalizationsync();
}
