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

    [Route("registerPressure/{id?}")]
    public class RegisterPressureController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "http://localhost:44332/", headers: "", methods: "*")]
        public async Task<object> Pressure([FromBody] PressureViewModel model, [FromUri] int? id)

        {

            HealthTrackDB2 entities = new HealthTrackDB2();

            try
            {
                PressaoArterial pressao = new PressaoArterial();
                pressao.PressaoArterial1 = model.ValorPressao;
                pressao.DataRegistro = DateTime.Now;
                pressao.IdUsuario = id;
                entities.PressaoArterial.Add(pressao);

                await entities.SaveChangesAsync();
                return "Pressao Arterial cadastrada com sucesso";
            }
            catch (DbUpdateException)
            {
                return "04X01 - Falha interna no servidor";
            }
        }

    }
}