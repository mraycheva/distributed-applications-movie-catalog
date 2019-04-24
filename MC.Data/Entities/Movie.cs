﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MC.Data.Entities
{
    public class Movie : BaseEntity
    {
        #region Properties
        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public string ReleaseCountry { get; set; }

        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        public int? DirectorId { get; set; }
        public virtual Director Director { get; set; }

        public int? RatingId { get; set; }
        public virtual Rating Rating { get; set; }
        #endregion
    }
}