namespace APICollection.Repository.Interfaces
{
    public interface IServiceResult
    {
        string Message { get; set; }

        bool Success { get; set; }
    }
}
