using System.Collections.Generic;

namespace SignalR
{
    /// <summary>
    /// IUserConnectionManager
    /// </summary>
    public interface IUserConnectionManager
    {
        public void KeepUserConnection(string userId, string connectionId);
        public void RemoveUserConnection(string connectionId);
        public List<string> GetUserConnections(string userId);
    }
}
