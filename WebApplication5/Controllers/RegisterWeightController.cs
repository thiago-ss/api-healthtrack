using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication5;
using WebApplication5.Models;
using WebApplication5.ViewModels;

namespace WebApplication5.Controllers
{

    [Route("registerweight/{id?}")]
    public class RegisterWeightController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "http://localhost:44332/", headers: "", methods: "*")]
        public async Task<object> Weight([FromBody] WeightViewModel model, [FromUri] int? id)

        {

            HealthTrackDB2 entities = new HealthTrackDB2();

            try
            {
                Peso peso = new Peso();
                peso.Peso1 = model.ValorPeso;
                peso.DataRegistro = DateTime.Now;
                peso.IdUsuario = id;
                entities.Peso.Add(peso);

                await entities.SaveChangesAsync();
                return "Peso cadastrado com sucesso";
            }
            catch (DbUpdateException)
            {
                return "04X01 - Falha interna no servidor";
            }
        }

    }
}