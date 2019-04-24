using MC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.ApplicationServices.DTOs
{
    public class RatingDto : BaseDto
    {
        #region Properties
        public string RatingValue { get; set; }
        #endregion

        #region Constructors
        public RatingDto()
        {

        }

        public RatingDto(Rating rating) : base(rating.Id, rating.IsActive)
        {
            RatingValue = rating.RatingValue;
        }
        #endregion
    }
}
