using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("update-user/{id}")]
    public class ModificationAccountController : ApiController
    {
        [HttpPut]
        public async Task<object> Change([FromBody] Usuario user, [FromUri] int id)
        {

            HealthTrackDB2 entities = new HealthTrackDB2();

            try
            {
                var usuario = entities
                    .Usuario
                    .First(x => x.ID == id);

                usuario.Nome = user.Nome;
                usuario.Idade = user.Idade;
                usuario.Genero = user.Genero;
                usuario.Email = user.Email;
                usuario.Senha = user.Senha;


                await entities.SaveChangesAsync();

                return "Alterações realizadas com sucesso!";
            }
            catch (DbUpdateException)
            {
                return "01X04 - Não foi possível alterar as informações de usuário";
            }
            catch
            {
                return "01X05 - Falha interna no servidor";
            }
        }
    }
}