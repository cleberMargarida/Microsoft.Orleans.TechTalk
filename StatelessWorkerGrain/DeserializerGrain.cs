using MessagePack;
using Orleans.Concurrency;

[StatelessWorker]
public class DeserializerGrain : Grain, IGpsDeserializerGrain
{
    public ValueTask<T> DeserializeAsync<T>(byte[] payload)
        where T : class
    {
        return ValueTask.FromResult(MessagePackSerializer.Deserialize<T>(payload));
    }
}

public interface IGpsDeserializerGrain : IGrainWithIntegerKey
{
    ValueTask<T> DeserializeAsync<T>(byte[] payload)
        where T : class;
}
