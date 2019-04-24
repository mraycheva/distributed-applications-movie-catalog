using MC.ApplicationServices.DTOs;
using MC.Website.GenreReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MC.Website.ViewModels.GenreVM
{
    public class GenreVM
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        #endregion

        #region Constructors
        public GenreVM()
        {

        }

        public GenreVM(GenreDto genreDto)
        {
            Id = genreDto.Id;
            Name = genreDto.Name;
        }
        #endregion
    }
}