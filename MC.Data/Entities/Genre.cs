using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MC.Data.Entities
{
    public class Genre : BaseEntity
    {
        #region Properties
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        #endregion
    }
}