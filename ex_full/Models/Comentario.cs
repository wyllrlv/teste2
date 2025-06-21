using System.ComponentModel.DataAnnotations;

namespace ex_full.Models
{
    public class Comentario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Texto { get; set; }

        public DateTime DataCriacao { get; set; }

        [StringLength(100)]
        public string Usuario { get; set; } = "Usuário Anônimo";

        // Foreign Key
        public int TreinoId { get; set; }
        public virtual Treino Treino { get; set; }
    }
}