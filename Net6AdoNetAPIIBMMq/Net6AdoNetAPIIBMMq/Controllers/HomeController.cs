using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Net6AdoNetAPIIBMMq.Repo;

namespace Net6AdoNetAPIIBMMq.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISqlRepo _sqlrepo;

        public HomeController(ILogger<HomeController> logger
            , ISqlRepo sqlrepo)
        {
            _logger = logger;
            _sqlrepo = sqlrepo;
        }

        [HttpGet]
        public IEnumerable<string> AllTables()
        {
            return _sqlrepo.RunQuery();
        }
    }
}