using MC.ApplicationServices.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MC.Website.ViewModels.DirectorVM
{
    public class DirectorVM
    {
        #region Properties
        public int Id { get; set; }
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "First name")]
        public string FName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LName { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        #endregion

        #region Constructors
        public DirectorVM()
        {

        }

        public DirectorVM(DirectorDto directorDto)
        {
            Id = directorDto.Id;
            Username = directorDto.Username;
            FName = directorDto.FName;
            LName = directorDto.LName;
            Description = directorDto.Description;
        }
        #endregion
    }
}