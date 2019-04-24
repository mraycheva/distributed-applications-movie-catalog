using MC.Data.Entities;
using System;

namespace MC.ApplicationServices.DTOs
{
    public class MovieDto : BaseDto
    {
        #region Constructors
        public MovieDto() { }

        public MovieDto(Movie movie) : base(movie.Id, movie.IsActive)
        {
            Title = movie.Title;
            ReleaseDate = movie.ReleaseDate;
            ReleaseCountry = movie.ReleaseCountry;
            GenreId = movie.GenreId.Value;
            DirectorId = movie.DirectorId;
            RatingId = movie.RatingId;
        }
        #endregion

        #region Properties
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string ReleaseCountry { get; set; }
        public int GenreId { get; set; }
        public int? DirectorId { get; set; }
        public int? RatingId { get; set; }

        public String DirectorName { get; set; }
        public String GenreName { get; set; }
        public String RatingName { get; set; }

        #endregion
    }
}