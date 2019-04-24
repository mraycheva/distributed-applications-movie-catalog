using MC.Website.ViewModels;
using MC.Website.ViewModels.DirectorVM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MC.Website.Controllers
{
    public class DirectorsController : Controller
    {
        #region Variables
        private readonly Uri _uri = new Uri("http://localhost:50087/api/Directors/");
        #endregion

        #region Methods
        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = _uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("GetAll");
                string jsonString = await response.Content.ReadAsStringAsync();
                List<DirectorVM> directorVMs = JsonConvert.DeserializeObject<List<DirectorVM>>(jsonString);

                return View(directorVMs);
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(DirectorVM directorVM)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = _uri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string content = JsonConvert.SerializeObject(directorVM);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var bufferContext = new ByteArrayContent(buffer);
                    bufferContext.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    var response = await client.PostAsync("postdirector", bufferContext);
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw new Exception("Create unsuccessful.");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = _uri;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage responseMessage = await client.GetAsync("getbyid/" + id);
                    string jsonString = await responseMessage.Content.ReadAsStringAsync();
                    var responseData = JsonConvert.DeserializeObject<DirectorVM>(jsonString);

                    return View(responseData);
                }
            }
            catch (Exception)
            {

                throw new Exception("Delete unsuccessful.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection formCollection)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = _uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseMessage = await client.DeleteAsync("deletedirector?id=" + id);

                return RedirectToAction("Index");
            }
        }
        #endregion
    }
}