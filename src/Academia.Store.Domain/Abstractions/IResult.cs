namespace Academia.Store.Domain.Abstractions
{
    public interface IResult
    {
        bool Sucess { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}
