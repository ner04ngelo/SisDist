using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TerritoryController : Controller
    {
        ///URL Local del APIREST

        string URL = "http://localhost:51178";
        public async Task<ActionResult> Index()
        {

            List<Territory> territoryInfo = new List<Territory>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Llamada a todlos los metodos

                HttpResponseMessage res = await client.GetAsync("api/Territories");

                if (res.IsSuccessStatusCode)
                {
                    var TerrResponse = res.Content.ReadAsStringAsync().Result;

                    territoryInfo = JsonConvert.DeserializeObject<List<Territory>>(TerrResponse);
                }

                return View(territoryInfo);
            }

        }


    }
}


