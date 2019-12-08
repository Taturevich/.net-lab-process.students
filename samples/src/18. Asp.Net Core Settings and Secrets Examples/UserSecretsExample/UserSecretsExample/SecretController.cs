using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace UserSecretsExample
{
    public class SecretController : ControllerBase
    {
        public IActionResult Index([FromServices]IOptions<OptionsWithSecrets> options)
        {
            return Ok( new { options.Value.FirstSecret, options.Value.SecondSecret });
        }
    }
}
