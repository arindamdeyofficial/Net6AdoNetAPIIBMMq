using BusinessModel.Config;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BusinessModel.Config
{
    public interface ICustomConfigService
    {
        Task<ActionResult<ConfigModel>> ReadConfig();
    }
}
