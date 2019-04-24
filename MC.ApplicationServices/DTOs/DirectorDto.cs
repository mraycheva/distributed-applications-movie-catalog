using MC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ApplicationServices.DTOs
{
    public class DirectorDto : BaseDto
    {
        #region Properties
        public string Username { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Description { get; set; }
        #endregion

        #region Constructors
        public DirectorDto()
        {

        }

        public DirectorDto(Director director) : base(director.Id, director.IsActive)
        {
            Username = director.Username;
            FName = director.FName;
            LName = director.LName;
            Description = director.Description;
        }
        #endregion
    }
}
