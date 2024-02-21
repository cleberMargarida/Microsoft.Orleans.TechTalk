public interface IPlacementSampleGrain : IGrainWithStringKey
{
    ValueTask<string> SayHello(string greeting);
}
