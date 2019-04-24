using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Data.Entities
{
    public class Rating : BaseEntity
    {
        #region Properties
        [Required]
        public string RatingValue { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        #endregion
    }
}
