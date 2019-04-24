using MC.ApplicationServices.DTOs;
using MC.ApplicationServices.Implementations;
using System.Collections.Generic;

namespace MC.WcfServices
{
    public class Movies : IMovies
    {
        #region Properties
        // _service
        private readonly MovieManagementService _service;
        #endregion

        #region Constructor
        public Movies()
        {
            _service = new MovieManagementService();
        }
        #endregion

        #region Methods
        // Get
        public List<MovieDto> Get()
        {
            return _service.Get();
        }

        // Post
        public string Post(MovieDto movieDto)
        {
            if (_service.Save(movieDto) == -1)
                return "Movie is not inserted";

            return "Movie is inserted";
        }

        // Delete
        public string Delete(int id)
        {
            if (_service.Delete(id) == -1)
                return $"Movie with id {id} is not deleted";

            return $"Movie with id {id} deleted";
        }

        // GetById
        public MovieDto GetById(int id)
        {
            return _service.GetById(id);
        }

        // Edit
        public string Edit(MovieDto movieDto)
        {
            if (_service.Edit(movieDto) == -1)
                return "Movie is not updated";

            return "Movie is updated";
        }

        // Message
        public string Message()
        {
            return "Wcf is running on localhost:49...";
        }
        #endregion
    }
}