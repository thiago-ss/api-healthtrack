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

    [Route("registerHeight/{id?}")]
    public class RegisterHeightController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "http://localhost:44355/", headers: "", methods: "*")]
        public async Task<object> Height([FromBody] HeightViewModel model, [FromUri] int? id)

        {

            HealthTrackDB2 entities = new HealthTrackDB2();

            try
            {
                Altura altura = new Altura();
                altura.Altura1 = model.ValorAltura;
                altura.DataRegistro = DateTime.Now;
                altura.IdUsuario = id;
                entities.Altura.Add(altura);

                await entities.SaveChangesAsync();
                return "Altura cadastrada com sucesso";
            }
            catch (DbUpdateException)
            {
                return "04X01 - Falha interna no servidor";
            }
        }

    }
}