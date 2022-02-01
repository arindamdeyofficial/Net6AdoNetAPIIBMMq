namespace BusinessModel
{
    public interface IHealthCheckConfig
    {
        public string BuildNumber { get; set; }
        public string SwaggerUrl { get; set; }
    }
}
