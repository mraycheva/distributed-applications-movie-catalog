using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MC.ApplicationServices.Implementations;
using MC.ApplicationServices.DTOs;

namespace MC.WebApiServices.Controllers
{
    public class DirectorsController : ApiController
    {
        #region Variables
        private readonly DirectorManagementService _service;
        #endregion

        #region Constructors
        public DirectorsController()
        {
            _service = new DirectorManagementService();
        }
        #endregion

        #region Methods
        // GetAll
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Json(_service.Get());
        }

        //GetById
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            return Json(_service.GetById(id));
        }

        // GetByUsername
        [HttpGet]
        public IHttpActionResult GetByUsername(string username)
        {
            List<DirectorDto> directorDtos = _service.GetByUsername(username);

            return Json(directorDtos);
        }

        // GetByFirstName
        [HttpGet]
        public IHttpActionResult GetByFirstName(string firstName)
        {
            return Json(_service.GetByFirstName(firstName));
        }

        // PostDirector
        [HttpPost]
        public IHttpActionResult PostDirector(DirectorDto directorDto)
        {
            if (_service.Save(directorDto) == -1)
                return Json("Director is not inserted");

            return Json("Director is inserted");
        }

        // DeleteDirector
        [HttpDelete]
        public IHttpActionResult DeleteDirector(int id)
        {
            if (_service.Delete(id) == -1)
                return Json($"Director with id {id} is not deleted");

            return Json($"Director with id {id} deleted");
        }

        [HttpGet]
        public IHttpActionResult Message()
        {
            return Json("Web Api is working");
        }
        #endregion
    }
}