using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("delete-user/{id}")]
    public class DeleteAccountController : ApiController
    {
        [HttpDelete]
        public async Task<object> Delete([FromUri] int id)
        {

            HealthTrackDB2 entities = new HealthTrackDB2();

            try
            {

                var usuario = entities
                .Usuario
                .FirstOrDefault(x => x.ID == id);


                if (usuario == null)
                    return "Usuario não encontrado";

                else
                {
                    entities.Usuario.Remove(usuario);
                    await entities.SaveChangesAsync();
                    return "Deletada com Sucesso";
                }

            }
            catch (DbUpdateException)
            {
                return "01X04 - Não foi possivel deletar usuario";
            }
            catch
            {
                return "01X05 - Falha interna no servidor";
            }
        }
    }
}


