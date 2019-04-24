using MC.Data.Entities;
using System;

namespace MC.ApplicationServices.DTOs
{
    public class GenreDto : BaseDto
    {
        #region Properties
        public string Name { get; set; }
        #endregion

        #region Constructors
        public GenreDto()
        {

        }

        public GenreDto(Genre genre) : base(genre.Id, genre.IsActive)
        {
            Name = genre.Name;
        }
        #endregion
    }
}