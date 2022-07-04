using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("register")]
    public class RegisterController : ApiController
    {
        [HttpPost]
        public async Task<object> Register([FromBody] Usuario user)
        {
            HealthTrackDB2 entities = new HealthTrackDB2();

            var usuario = new Usuario
            {
                Nome = user.Nome,
                Idade = user.Idade,
                Genero = user.Genero,
                Email = user.Email,
                Senha = user.Senha,
            };

            try
            {
                entities.Usuario.Add(user);
                await entities.SaveChangesAsync();
                return "Usuário registrado com sucesso!";
            }
            catch (DbUpdateException)
            {
                return "04X00 - Este E-mail já está cadastrado";
            }
            catch
            {
                return "04X01 - Falha interna no servidor";
            }
        }
    }
}