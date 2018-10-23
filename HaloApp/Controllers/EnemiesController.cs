using HaloApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HaloApp.Controllers
{
    public class EnemiesController : Controller
    {
        // GET: Enemies
        public async Task<ActionResult> Index()
        {
            var enemies = await RequestEnemiesAsync();
            return View(enemies);
        }

        private async Task<List<Enemy>> RequestEnemiesAsync()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.AcceptLanguage.Add(StringWithQualityHeaderValue.Parse("en"));
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fb4676955bae402fb50b49909808f425");

            var uri = "https://www.haloapi.com/metadata/h5/metadata/enemies?" + queryString;

            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Enemy[]>(jsonResult);

            return result.ToList();
        }
    }
}