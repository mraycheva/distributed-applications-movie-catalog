using MC.ApplicationServices.DTOs;
using MC.Data.Contexts;
using MC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MC.ApplicationServices.Implementations
{
    public class MovieManagementService
    {
        #region Variables
        // _context
        private readonly MovieCatalogDbContext _context = new MovieCatalogDbContext();
        private readonly DirectorManagementService _directorManagementService = new DirectorManagementService();
        private readonly GenreManagementService _genreManagementService = new GenreManagementService();
        private readonly RatingManagementService _ratingManagementService = new RatingManagementService();
        #endregion

        #region Methods
        // Get
        public List<MovieDto> Get()
        {
            List<MovieDto> movieDtos = new List<MovieDto>();

            foreach (var movie in _context.Movies.ToList())
            {
                MovieDto movieDto = new MovieDto(movie);
                int directorId = (int)movieDto.DirectorId;
                DirectorDto directorDto = _directorManagementService.GetById(directorId);

                movieDto.DirectorName = directorDto.FName + " " + directorDto.LName;

                int genreId = (int)movieDto.GenreId;
                GenreDto genreDto = _genreManagementService.GetById(genreId);

                movieDto.GenreName = genreDto.Name;

                if (movieDto.RatingId == null) { movieDto.RatingName = ""; }
                else
                {
                    int ratingId = (int)movieDto.RatingId;
                    RatingDto ratingDto = _ratingManagementService.GetById(ratingId);

                    movieDto.RatingName = ratingDto.RatingValue;
                }

                movieDtos.Add(movieDto);
            }

            return movieDtos;
        }

        // GetById
        public MovieDto GetById(int id)
        {
            MovieDto movieDto = new MovieDto(_context.Movies.Find(id));
            int directorId = (int)movieDto.DirectorId;
            DirectorDto directorDto = _directorManagementService.GetById(directorId);

            movieDto.DirectorName = directorDto.FName + " " + directorDto.LName;

            int genreId = (int)movieDto.GenreId;
            GenreDto genreDto = _genreManagementService.GetById(genreId);
            movieDto.GenreName = genreDto.Name;

            if (movieDto.RatingId == null) { movieDto.RatingName = ""; }
            else
            {
                int ratingId = (int)movieDto.RatingId;
                RatingDto ratingDto = _ratingManagementService.GetById(ratingId);
                movieDto.RatingName = ratingDto.RatingValue;
            }

            return movieDto;
        }

        // Save
        public int Save(MovieDto movieDto)
        {
            try
            {
                Movie movie = new Movie
                {
                    IsActive = movieDto.IsActive,
                    Title = movieDto.Title,
                    ReleaseDate = movieDto.ReleaseDate,
                    ReleaseCountry = movieDto.ReleaseCountry,
                    GenreId = movieDto.GenreId,
                    DirectorId = movieDto.DirectorId,
                    RatingId = movieDto.RatingId
                };

                _context.Movies.Add(movie);
                _context.SaveChanges();

                return movie.Id;
            }
            catch (System.Exception)
            {
                return -1;
            }
        }

        // Edit
        public int Edit(MovieDto movieDto)
        {
            try
            {
                Movie movie = new Movie
                {
                    Id = movieDto.Id,
                    IsActive = movieDto.IsActive,
                    Title = movieDto.Title,
                    ReleaseDate = movieDto.ReleaseDate,
                    ReleaseCountry = movieDto.ReleaseCountry,
                    GenreId = movieDto.GenreId,
                    DirectorId = movieDto.DirectorId,
                    RatingId = movieDto.RatingId
                };

                _context.Movies.Attach(movie);
                _context.Entry(movie).State = EntityState.Modified;
                _context.SaveChanges();

                return movie.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        // Delete
        public int Delete(int id)
        {
            try
            {
                Movie movie = _context.Movies.Find(id);

                if (movie == null)
                {
                    return -1;
                }

                _context.Movies.Remove(movie);
                _context.SaveChanges();

                return id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion
    }
}