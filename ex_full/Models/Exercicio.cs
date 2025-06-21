using System.ComponentModel.DataAnnotations;

namespace ex_full.Models
{
    public class Exercicio
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public int Series { get; set; }
        public int Repeticoes { get; set; }

        [StringLength(500)]
        public string? Observacoes { get; set; }

        // Foreign Key
        public int TreinoId { get; set; }
        public virtual Treino Treino { get; set; }
    }
}
