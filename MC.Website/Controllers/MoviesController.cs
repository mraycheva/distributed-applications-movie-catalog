using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MC.Website.MovieReference;
using MC.Website.GenreReference;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MC.Data.Entities;
using MC.Website.RatingReference;
using MC.ApplicationServices.DTOs;
using MC.Website.ViewModels.MovieVM;
using MC.Website.ViewModels.DirectorVM;

namespace MC.Website.Controllers
{
    public class MoviesController : Controller
    {
        private async Task LoadDdls(EditVM editVM)
        {
            await LoadDdlDirs(editVM);
            LoadDdlGenres(editVM);
            LoadDdlRatings(editVM);
        }

        private async Task LoadDdlDirs(EditVM editVM)
        {
            editVM.Directors = new List<SelectListItem> { new SelectListItem() };

            var ddl = editVM.Directors;
            Uri _uriDirectors = new Uri("http://localhost:50087/api/Directors/");

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = _uriDirectors;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("GetAll");
                string jsonString = await response.Content.ReadAsStringAsync();
                List<DirectorVM> directorVMs = JsonConvert.DeserializeObject<List<DirectorVM>>(jsonString);

                foreach (var item in directorVMs)
                {
                    var si = new SelectListItem
                    {
                        Text = item.FName + " " + item.LName,
                        Value = item.Id.ToString()
                    };

                    if (item.Id == editVM.DirectorId)
                    {
                        si.Selected = true;
                    }

                    ddl.Add(si);
                }
            }
        }

        private void LoadDdlGenres(EditVM editVM)
        {
            editVM.Genres = new List<SelectListItem> { new SelectListItem() };

            var ddl = editVM.Genres;

            using (GenreClient client = new GenreClient())
            {
                var genres = client.Get();

                foreach (var item in genres)
                {
                    var si = new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString()
                    };

                    if (item.Id == editVM.GenreId)
                    {
                        si.Selected = true;
                    }

                    ddl.Add(si);
                }
            }


        }

        private void LoadDdlRatings(EditVM editVM)
        {
            editVM.Ratings = new List<SelectListItem> { new SelectListItem() };

            var ddl = editVM.Ratings;

            using (RatingClient client = new RatingClient())
            {
                var ratings = client.Get();

                foreach (var item in ratings)
                {
                    var si = new SelectListItem
                    {
                        Text = item.RatingValue,
                        Value = item.Id.ToString()
                    };

                    if (item.Id == editVM.RatingId)
                    {
                        si.Selected = true;
                    }

                    ddl.Add(si);
                }
            }


        }

        public ActionResult Index()
        {
            using (MoviesClient client = new MoviesClient())
            {
                List<IndexVM> movieVMs = client.Get().Select(x => new IndexVM(x)).ToList();

                return View(movieVMs);

            }
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            EditVM editVM = new EditVM();
            await LoadDdls(editVM);

            return View(editVM);
        }

        [HttpPost]
        public ActionResult Create(IndexVM movieVM)
        {
            using (MoviesClient client = new MoviesClient())
            {
                MovieDto movieDto = new MovieDto
                {
                    Title = movieVM.Title,
                    ReleaseDate = movieVM.ReleaseDate,
                    ReleaseCountry = movieVM.ReleaseCountry,
                    GenreId = movieVM.GenreId,
                    DirectorId = movieVM.DirectorId,
                    IsActive = true
                };

                client.Post(movieDto);

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            EditVM editVM;

            using (MoviesClient client = new MoviesClient())
            {
                MovieDto movieDto = client.GetById(id);

                editVM = new EditVM
                {
                    Id = movieDto.Id,
                    Title = movieDto.Title,
                    ReleaseDate = movieDto.ReleaseDate,
                    ReleaseCountry = movieDto.ReleaseCountry,
                    DirectorId = movieDto.DirectorId,
                    DirectorName = movieDto.DirectorName,
                    GenreId = movieDto.GenreId,
                    GenreName = movieDto.GenreName,
                    RatingId = movieDto.RatingId,
                    RatingName = movieDto.RatingName
                };
            }

            await LoadDdls(editVM);

            return View(editVM);
        }

        [HttpPost]
        public ActionResult Edit(IndexVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            MovieDto movieDto = new MovieDto
            {
                Id = model.Id,
                Title = model.Title,
                ReleaseDate = model.ReleaseDate,
                ReleaseCountry = model.ReleaseCountry,
                GenreId = model.GenreId,
                DirectorId = model.DirectorId,
                RatingId = model.RatingId,
                IsActive = true
            };

            using (MoviesClient client = new MoviesClient())
            {
                client.Edit(movieDto);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (MoviesClient client = new MoviesClient())
            {
                IndexVM movieVM = new IndexVM(client.GetById(id));

                return View(movieVM);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            using (MoviesClient client = new MoviesClient())
            {
                client.Delete(id);

                return RedirectToAction("Index");
            }
        }
    }
}