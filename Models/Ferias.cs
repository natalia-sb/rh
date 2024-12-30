using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace rh.Models
{
    public class Ferias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Funcionario")]
        public int FuncionarioId { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataTermino { get; set; }

        [Required]
        public StatusFerias Status { get; set; }

        // Propriedade de navegação
        public required Funcionario Funcionario { get; set; }
    }

    public enum StatusFerias
    {
        Pendente,
        EmAndamento,
        Concluido
    }
    
}