using Academia.Store.Domain.Abstractions;

namespace Academia.Store.Domain.Implementations
{
    public class ApiContract : IResult
    {
        public ApiContract(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
