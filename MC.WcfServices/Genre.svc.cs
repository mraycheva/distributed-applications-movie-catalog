using MC.ApplicationServices.DTOs;
using MC.ApplicationServices.Implementations;
using System.Collections.Generic;

namespace MC.WcfServices
{
    public class Genre : IGenre
    {
        #region Variables
        // _service
        private readonly GenreManagementService _service;
        #endregion

        #region Constructor
        public Genre()
        {
            _service = new GenreManagementService();
        }
        #endregion

        #region Methods
        // GetGenres
        public List<GenreDto> Get()
        {
            return _service.Get();
        }

        // GetById
        public GenreDto GetById(int id)
        {
            return _service.GetById(id);
        }

        // PostGenre
        public string Post(GenreDto genreDto)
        {
            if (_service.Save(genreDto) == -1)
                return "Genre is not inserted";

            return "Genre is inserted";
        }

        // DeleteGenre
        public string Delete(int id)
        {
            if (_service.Delete(id) == -1)
                return $"Genre with id {id} is not deleted";

            return $"Genre with id {id} deleted";
        }
        #endregion
    }
}