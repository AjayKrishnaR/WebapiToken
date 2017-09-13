using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebApiToken.Models;

namespace WebApiToken.Controllers.mvc
{
    public class DisplayController : Controller
    {
        // GET: Display
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<TokenEntity> wp = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:61442/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Auth");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TokenEntity>>();
                    readTask.Wait();

                    wp = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    wp = Enumerable.Empty<TokenEntity>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(wp);
        }
        public ActionResult hai()
        {
            return View();
        }
    }
}