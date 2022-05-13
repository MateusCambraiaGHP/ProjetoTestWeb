using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoTest.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(45)")]
        public string NameSupplier { get; set; }
        public string CNPJ { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Cep { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataCadastro { get; set; }
        [Column(TypeName = "varchar(120)")]
        public string QrCode { get; set; }
    }
}
