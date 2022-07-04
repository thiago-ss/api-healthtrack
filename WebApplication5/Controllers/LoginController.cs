using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication5;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{

    [Route("login")]
    public class LoginController : ApiController
    {
        [HttpPost]
        public async Task<object> Login([FromBody] Usuario user)
        {

            HealthTrackDB2 entities = new HealthTrackDB2();

            var usuario = entities.Usuario.FirstOrDefault(x => x.Email == user.Email);

            if (usuario == null)
                return "Usuário ou senha incorretos";
            else if (usuario.Senha == user.Senha)
            {
                return "Login feito com sucesso";
            }
            else
                return "Usuário ou senha incorretos";
        }

    }
}