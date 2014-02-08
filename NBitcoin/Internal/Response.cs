namespace NBitcoin.Internal
{
    public class Response<T> : IHasError
    {
        public T Result { get; set; }
        public string Id { get; set; }
        public Error Error { get; set; }

        public bool HasError
        {
            get { return Error != null; }
        }
    }

    public interface IHasError
    {
        Error Error { get; set; }
        bool HasError { get; }
    }
}
