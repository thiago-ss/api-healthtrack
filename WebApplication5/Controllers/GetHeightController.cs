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

    [Route("get-height/{id?}")]
    public class GetHeightController : ApiController
    {
        [HttpGet]
        [EnableCors(origins: "http://localhost:44355/", headers: "", methods: "*")]
        public async Task<object> Height([FromUri] int? id)

        {
            HealthTrackDB2 entities = new HealthTrackDB2();

            try
            {
                var alturas = entities.
                    Altura
                    .FirstOrDefault(x => x.IdUsuario == id);
                return alturas.Usuario.Altura;
            }
            catch
            {
                return "01X00 - Falha interna no servidor";
            }
        }

    }
}