using APICollection.Repository.Interfaces;

namespace APICollection.Responses
{
    public class ServiceResult : IServiceResult
    {
        private object data;
        private string message;
        private bool success;

        public object Data { get => data; set => data = value; }
        public string Message { get => message; set => message = value; }
        public bool Success { get => success; set => success = value; }
    }
}
