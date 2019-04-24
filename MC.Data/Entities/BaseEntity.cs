using System.ComponentModel.DataAnnotations;

namespace MC.Data.Entities
{
    public abstract class BaseEntity
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        public bool IsActive { get; set; }
        #endregion
    }
}
