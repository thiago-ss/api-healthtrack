using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication5;
using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{
     
    [Route("registerworkout/{id?}")]
    public class RegisterWorkoutController : ApiController
    {
        [HttpPost]
        public async Task<object> Workout([FromBody] WorkoutViewModel model, [FromUri] int? id)
        {

            HealthTrackDB2 entities = new HealthTrackDB2();

            try
            {
                
                Atividade atividade = new Atividade();
                atividade.Atividade1 = model.NomeAtividade;
                atividade.DataRegistro = DateTime.Now;
                atividade.IdUsuario = id;
                entities.Atividade.Add(atividade);


                await entities.SaveChangesAsync();
                return "Atividade cadastrada com sucesso";
            }
            catch (DbUpdateException)
            {
                return "04X01 - Falha interna no servidor";
            }
        }

    }
}