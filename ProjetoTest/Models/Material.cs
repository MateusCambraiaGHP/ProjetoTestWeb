using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoTest.Models
{
    public class Material
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SupplierId { get; set; }
        
        [Column(TypeName = "varchar(10)")]
        public string Code { get; set; }
        
        [Column(TypeName = "varchar(45)")]
        public string Name { get; set; }
        
        [Column(TypeName = "varchar(120)")]
        public string Description { get; set; }
        
        [Column(TypeName = "varchar(25)")]
        public string FiscalCode { get; set; }

        public string Specie { get; set; }
        
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column(TypeName = "varchar(45)")]
        public string CreatedBy { get; set; } = "Adminstrador";
        
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        [Column(TypeName = "varchar(45)")]
        public string UpdatedBy { get; set; } = "Adminstrador";

    }
}
