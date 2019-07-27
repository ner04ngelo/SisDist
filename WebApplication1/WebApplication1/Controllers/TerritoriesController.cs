using ConectarDatos;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class TerritoriesController : ApiController
    {
        private NorthwindEntities dbContext = new NorthwindEntities();

        [HttpGet]
        public IEnumerable<Territory> Get()
        {
            using (NorthwindEntities northwind = new NorthwindEntities())
            {
                return northwind.Territories.ToList();
            }
        }

        [HttpGet]
        public Territory Get(string id)
        {

            using (NorthwindEntities northwind = new NorthwindEntities())
            {
                return northwind.Territories.FirstOrDefault(e => e.TerritoryID == id);
            }
        }

        [HttpPost]
        public IHttpActionResult AgregarTerritory([FromBody]Territory terr)
        {
            if (ModelState.IsValid)
            {
                dbContext.Territories.Add(terr);
                dbContext.SaveChanges();
                return Ok(terr);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]

        public IHttpActionResult Actualizar(string id, [FromBody]Territory terr)
        {
            if (ModelState.IsValid)
            {
                var TerritoryExist = dbContext.Territories.Count(c => c.TerritoryID == id) > 0;
                if (TerritoryExist)
                {
                    dbContext.Entry(terr).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult Eliminar(string id)
        {
            var territory = dbContext.Territories.Find(id);

            if (territory != null)
            {
                dbContext.Territories.Remove(territory);
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();

            }
    }


    }



}
