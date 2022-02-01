using SignalR;
using System.Collections.Generic;

namespace SignalR
{
    public class UserConnectionManager : IUserConnectionManager
    {
        private static Dictionary<string, List<string>> userConnectionMap = new Dictionary<string, List<string>>();
        private static string userConnectionMapLocker = string.Empty;

        /// <summary>
        /// KeepUserConnection
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="connectionId"></param>
        public void KeepUserConnection(string userId, string connectionId)
        {
            lock (userConnectionMapLocker)
            {
                if (!userConnectionMap.ContainsKey(userId))
                {
                    userConnectionMap[userId] = new List<string>();
                }
                userConnectionMap[userId].Add(connectionId);
            }
        }

        /// <summary>
        /// RemoveUserConnection
        /// </summary>
        /// <param name="connectionId"></param>
        public void RemoveUserConnection(string connectionId)
        {
            lock (userConnectionMapLocker)
            {
                foreach (var userId in userConnectionMap.Keys)
                {
                    if (userConnectionMap.ContainsKey(userId))
                    {
                        if (userConnectionMap[userId].Contains(connectionId))
                        {
                            userConnectionMap[userId].Remove(connectionId);
                            break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// GetUserConnections
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetUserConnections(string userId)
        {
            var conn = new List<string>();
            lock (userConnectionMapLocker)
            {
                conn = userConnectionMap[userId];
            }
            return conn;
        }
    }
}
