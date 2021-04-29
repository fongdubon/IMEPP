using System.ComponentModel.DataAnnotations;

namespace IMEPP.Entities
{
    public class Adviser
    {
        #region Propiedades
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string CellphoneNumber { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        [StringLength(200)]
        public string Department { get; set; }
        #endregion
    }
}
