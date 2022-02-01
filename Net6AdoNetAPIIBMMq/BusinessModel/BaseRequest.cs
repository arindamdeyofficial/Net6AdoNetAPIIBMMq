using System.Diagnostics.CodeAnalysis;

namespace BusinessModel
{
    [ExcludeFromCodeCoverage]
    public class BaseRequest : IBaseRequest
    {
        public Guid RequestId { get; set; }
        public string Userid { get; set; }
        public string Role { get; set; }
    }
}
