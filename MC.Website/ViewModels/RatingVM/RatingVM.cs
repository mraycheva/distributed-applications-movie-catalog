using MC.ApplicationServices.DTOs;
using MC.Website.RatingReference;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MC.Website.ViewModels.RatingVM
{
    public class RatingVM
    {
        #region Constructors

        public RatingVM()
        {

        }

        public RatingVM(RatingDto ratingDto)
        {
            Id = ratingDto.Id;
            RatingValue = ratingDto.RatingValue;
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        [Required]
        [Display(Name = "Rating value")]
        public string RatingValue { get; set; }
        #endregion
    }
}