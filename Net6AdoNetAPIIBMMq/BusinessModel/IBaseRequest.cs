using System;

namespace BusinessModel
{
    public interface IBaseRequest
    {
        Guid RequestId { get; set; }
        string Userid { get; set; }
        public string Role { get; set; }
    }
}
