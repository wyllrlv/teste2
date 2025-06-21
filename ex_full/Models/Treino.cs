using System.ComponentModel.DataAnnotations;

namespace ex_full.Models
{
    public class Treino
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Descricao { get; set; }

        public double Avaliacao { get; set; }

        // Navigation Properties
        public virtual ICollection<Exercicio> Exercicios { get; set; } = new List<Exercicio>();
        public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}