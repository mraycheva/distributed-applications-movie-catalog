using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MC.Website.MovieReference;
using MC.ApplicationServices.DTOs;
using System.Web.Mvc;

namespace MC.Website.ViewModels.MovieVM
{
    public class IndexVM
    {
        #region Constructors
        public IndexVM() { }

        public IndexVM(MovieDto movieDto)
        {
            Id = movieDto.Id;
            Title = movieDto.Title;
            ReleaseDate = movieDto.ReleaseDate;
            ReleaseCountry = movieDto.ReleaseCountry;
            DirectorId = movieDto.DirectorId;
            GenreId = movieDto.GenreId;
            RatingId = movieDto.RatingId;
            DirectorName = movieDto.DirectorName;
            GenreName = movieDto.GenreName;
            RatingName = movieDto.RatingName;
        }
        #endregion

        #region Properties
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Release Country")]
        public string ReleaseCountry { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public int? DirectorId { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        public int GenreId { get; set; }

        public int? RatingId { get; set; }

        [Display(Name = "Director")]
        public String DirectorName { get; set; }

        [Display(Name = "Genre")]
        public String GenreName { get; set; }

        [Display(Name = "Rating")]
        public string RatingName { get; set; }
        #endregion
    }
}