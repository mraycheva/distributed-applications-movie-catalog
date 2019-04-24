using MC.ApplicationServices.DTOs;
using MC.Website.GenreReference;
using MC.Website.ViewModels;
using MC.Website.ViewModels.GenreVM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MC.Website.Controllers
{
    public class GenresController : Controller
    {
        public ActionResult Index()
        {
            using (GenreReference.GenreClient client = new GenreClient())
            {
                List<GenreVM> genreVMs = client.Get().Select(x => new GenreVM(x)).ToList();

                return View(genreVMs);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GenreVM genreVM)
        {
            using (GenreReference.GenreClient client = new GenreClient())
            {
                GenreDto genreDto = new GenreDto
                {
                    Name = genreVM.Name,
                    IsActive = true
                };

                client.Post(genreDto);

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (GenreReference.GenreClient client = new GenreClient())
            {
                return View(new GenreVM(client.GetById(id)));
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            using (GenreReference.GenreClient client = new GenreClient())
            {
                client.Delete(id);

                return RedirectToAction("Index");
            }
        }
    }
}
