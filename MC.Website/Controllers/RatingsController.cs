using MC.ApplicationServices.DTOs;
using MC.Website.RatingReference;
using MC.Website.ViewModels;
using MC.Website.ViewModels.RatingVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MC.Website.Controllers
{
    public class RatingsController : Controller
    {

        public ActionResult Index()
        {
            using (RatingReference.RatingClient client = new RatingClient())
            {
                List<RatingVM> ratingVMs = client.Get().Select(x => new RatingVM(x)).ToList();

                return View(ratingVMs);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RatingVM ratingVM)
        {
            using (RatingReference.RatingClient client = new RatingClient())
            {
                RatingDto ratingDto = new RatingDto
                {
                    RatingValue = ratingVM.RatingValue,
                    IsActive = true
                };

                client.Post(ratingDto);

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            using (RatingClient client = new RatingClient())
            {
                return View(new RatingVM(client.GetById(id)));
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            using (RatingReference.RatingClient client = new RatingClient())
            {
                client.Delete(id);

                return RedirectToAction("Index");
            }
        }
    }
}