using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Task.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }
    }
}
