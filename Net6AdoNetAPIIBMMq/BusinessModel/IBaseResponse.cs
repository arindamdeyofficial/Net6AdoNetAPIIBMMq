namespace BusinessModel
{
    public interface IBaseResponse
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        int ResponseCode { get; set; }
    }
}
