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

    [Route("registerfood/{id?}")]
    public class RegisterFoodController : ApiController
    {
        [HttpPost]
        public async Task<object> Food([FromBody] FoodViewModel model, [FromUri] int? id)
        {

            HealthTrackDB2 entities = new HealthTrackDB2();

            try
            {
                Comida comida = new Comida();
                comida.Comida1 = model.TipoComida;
                comida.DataRegistro = DateTime.Now;
                comida.IdUsuario = id;
                entities.Comida.Add(comida);

                await entities.SaveChangesAsync();
                return "Comida cadastrada com sucesso";
            }
            catch (DbUpdateException)
            {
                return "04X01 - Falha interna no servidor";
            }
        }

    }
}