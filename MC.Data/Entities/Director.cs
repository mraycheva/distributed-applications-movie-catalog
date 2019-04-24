using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MC.Data.Entities
{
    public class Director : BaseEntity
    {
        #region Properties
        [Required]
        public string Username { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
        #endregion
    }
}
