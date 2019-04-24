// Same as the other
using MC.ApplicationServices.DTOs;
using MC.Data.Contexts;
using MC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MC.ApplicationServices.Implementations
{
    public class GenreManagementService
    {
        #region Variables
        // _context
        private readonly MovieCatalogDbContext _context = new MovieCatalogDbContext();
        #endregion

        #region Methods
        // Get
        public List<GenreDto> Get()
        {
            List<GenreDto> genreDtos = new List<GenreDto>();

            foreach (var genre in _context.Genres.ToList())
            {
                genreDtos.Add(new GenreDto(genre));
            }

            return genreDtos;
        }

        //GetById
        public GenreDto GetById(int id)
        {
            return new GenreDto(_context.Genres.Find(id));
        }

        // Save
        public int Save(GenreDto genreDto)
        {
            Genre genre = new Genre
            {
                IsActive = genreDto.IsActive,
                Name = genreDto.Name
            };

            try
            {
                _context.Genres.Add(genre);
                _context.SaveChanges();

                return genre.Id;
            }
            catch (System.Exception)
            {
                return -1;
            }
        }

        // Delete
        public int Delete(int id)
        {
            try
            {
                Genre genre = _context.Genres.Find(id);

                if (genre == null)
                {
                    return -1;
                }

                _context.Genres.Remove(genre);
                _context.SaveChanges();

                return id;
            }
            catch (System.Exception)
            {
                return -1;
            }
        }
        #endregion
    }
}