using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace SignalR
{
    /// <summary>
    /// NotificationUserHub
    /// </summary>
    public class NotificationUserHub : Hub
    {
        private readonly IUserConnectionManager _userConnectionManager;

        private readonly IHttpContextAccessor _httpContextAccessor;



        /// <summary>
        /// NotificationUserHub
        /// </summary>
        /// <param name="userConnectionManager"></param>
        /// <param name="httpContextAccessor"></param>
        public NotificationUserHub(IUserConnectionManager userConnectionManager, IHttpContextAccessor httpContextAccessor)
        {
            _userConnectionManager = userConnectionManager;
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        /// GetConnectionId
        /// </summary>
        /// <returns></returns>
        public string GetConnectionId()
        {
            var httpContext = this.Context;
            var currentUser = httpContext.User;
            _userConnectionManager.KeepUserConnection(currentUser.Claims.FirstOrDefault(c => c.Type == "preferred_username").Value, Context.ConnectionId);
            return Context.ConnectionId;
        }

        /// <summary>
        /// OnDisconnectedAsync
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public async override Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            _userConnectionManager.RemoveUserConnection(connectionId);
            var value = await Task.FromResult(0);
        }
    }
}
