using System.Diagnostics.CodeAnalysis;

namespace BusinessModel
{
    [ExcludeFromCodeCoverage]
    public class BaseResponse: IBaseResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public int ResponseCode{ get; set; }
    }
}
