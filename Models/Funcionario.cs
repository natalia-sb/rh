using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace rh.Models
{
    public class Funcionario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Cargo { get; set; }

        [Required]
        public DateTime DataAdmissao { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Salario { get; set; }

        [Required]
        public required string Status { get; set; }
    }
}