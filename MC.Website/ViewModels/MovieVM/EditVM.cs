using MC.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MC.Website.ViewModels.MovieVM
{
    public class EditVM : IndexVM
    {
        #region Constructors
        public EditVM() { }

        public EditVM(MovieDto movieDto) : base(movieDto)
        {
        }
        #endregion

        #region Properties
        public List<SelectListItem> Directors { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public List<SelectListItem> Ratings { get; set; }
        #endregion
    }
}