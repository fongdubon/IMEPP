using System.ComponentModel.DataAnnotations;

namespace IMEPP.Entities
{
    public class Company
    {
        #region Propiedades
    [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Addres { get; set; }

        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string Photo { get; set; }
        #endregion

    }
}
