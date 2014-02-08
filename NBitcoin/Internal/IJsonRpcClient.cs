namespace NBitcoin.Internal
{
    public interface IJsonRpcClient
    {
        TOutput InvokeMethod<TOutput>(Request request)
            where TOutput : class, IHasError, new();
    }
}