namespace HttpClients
{
    /// <summary>
    /// IEmailClient
    /// </summary>
    public interface IEmailClient
    {
        public Task<string> SendNotificationEmailOnFailure();
    }
}
