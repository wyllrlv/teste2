// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using ex_full.Models;

namespace ex_full.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações das relações
            modelBuilder.Entity<Exercicio>()
                .HasOne(e => e.Treino)
                .WithMany(t => t.Exercicios)
                .HasForeignKey(e => e.TreinoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Treino)
                .WithMany(t => t.Comentarios)
                .HasForeignKey(c => c.TreinoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Data - Dados iniciais
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Treinos
            modelBuilder.Entity<Treino>().HasData(
                new Treino { Id = 1, Titulo = "Treino de Peito e Tríceps", Descricao = "Treino focado no desenvolvimento dos músculos peitorais e tríceps, ideal para iniciantes e intermediários. Concentre-se na execução correta dos movimentos.", Avaliacao = 4.5 },
                new Treino { Id = 2, Titulo = "Treino de Costas e Bíceps", Descricao = "Sessão completa para fortalecimento das costas e bíceps. Foque na conexão mente-músculo para máximos resultados.", Avaliacao = 4.8 },
                new Treino { Id = 3, Titulo = "Treino de Pernas", Descricao = "Treino intenso para membros inferiores. Prepare-se para um dos treinos mais desafiadores, mas também mais recompensadores.", Avaliacao = 4.2 }
            );

            // Exercícios do Treino 1
            modelBuilder.Entity<Exercicio>().HasData(
                new Exercicio { Id = 1, Nome = "Supino Reto", Series = 4, Repeticoes = 12, Observacoes = "Controle a descida", TreinoId = 1 },
                new Exercicio { Id = 2, Nome = "Supino Inclinado", Series = 3, Repeticoes = 10, Observacoes = "45° de inclinação", TreinoId = 1 },
                new Exercicio { Id = 3, Nome = "Crucifixo", Series = 3, Repeticoes = 12, Observacoes = "Amplitude completa", TreinoId = 1 },
                new Exercicio { Id = 4, Nome = "Tríceps Testa", Series = 3, Repeticoes = 15, Observacoes = "Cotovelos fixos", TreinoId = 1 },
                new Exercicio { Id = 5, Nome = "Tríceps Corda", Series = 3, Repeticoes = 12, Observacoes = "Extensão completa", TreinoId = 1 },
                new Exercicio { Id = 6, Nome = "Mergulho", Series = 2, Repeticoes = 8, Observacoes = "Até a falha", TreinoId = 1 }
            );

            // Exercícios do Treino 2
            modelBuilder.Entity<Exercicio>().HasData(
                new Exercicio { Id = 7, Nome = "Barra Fixa", Series = 4, Repeticoes = 8, Observacoes = "Pegada pronada", TreinoId = 2 },
                new Exercicio { Id = 8, Nome = "Remada Curvada", Series = 4, Repeticoes = 10, Observacoes = "Tronco a 45°", TreinoId = 2 },
                new Exercicio { Id = 9, Nome = "Puxada Frente", Series = 3, Repeticoes = 12, Observacoes = "Peito para frente", TreinoId = 2 },
                new Exercicio { Id = 10, Nome = "Rosca Direta", Series = 4, Repeticoes = 12, Observacoes = "Sem balanço", TreinoId = 2 },
                new Exercicio { Id = 11, Nome = "Rosca Martelo", Series = 3, Repeticoes = 10, Observacoes = "Pegada neutra", TreinoId = 2 },
                new Exercicio { Id = 12, Nome = "Rosca 21", Series = 2, Repeticoes = 21, Observacoes = "7+7+7 repetições", TreinoId = 2 }
            );

            // Exercícios do Treino 3
            modelBuilder.Entity<Exercicio>().HasData(
                new Exercicio { Id = 13, Nome = "Agachamento Livre", Series = 5, Repeticoes = 8, Observacoes = "Profundidade completa", TreinoId = 3 },
                new Exercicio { Id = 14, Nome = "Leg Press", Series = 4, Repeticoes = 15, Observacoes = "Pés na largura dos ombros", TreinoId = 3 },
                new Exercicio { Id = 15, Nome = "Extensora", Series = 3, Repeticoes = 12, Observacoes = "Pausa no topo", TreinoId = 3 },
                new Exercicio { Id = 16, Nome = "Flexora", Series = 3, Repeticoes = 12, Observacoes = "Contração isométrica", TreinoId = 3 },
                new Exercicio { Id = 17, Nome = "Panturrilha em Pé", Series = 4, Repeticoes = 20, Observacoes = "Amplitude completa", TreinoId = 3 },
                new Exercicio { Id = 18, Nome = "Panturrilha Sentado", Series = 3, Repeticoes = 15, Observacoes = "Pausa na contração", TreinoId = 3 }
            );

            // Comentários
            modelBuilder.Entity<Comentario>().HasData(
                new Comentario { Id = 1, Texto = "Excelente treino! Senti bastante o peito trabalhando.", DataCriacao = DateTime.Now.AddDays(-2), Usuario = "Usuário Anônimo", TreinoId = 1 },
                new Comentario { Id = 2, Texto = "Muito bom para iniciantes, recomendo!", DataCriacao = DateTime.Now.AddDays(-1), Usuario = "Usuário Anônimo", TreinoId = 1 },
                new Comentario { Id = 3, Texto = "Poderia ter mais exercícios de tríceps.", DataCriacao = DateTime.Now.AddHours(-5), Usuario = "Usuário Anônimo", TreinoId = 1 },
                new Comentario { Id = 4, Texto = "Treino pesado, mas muito eficiente!", DataCriacao = DateTime.Now.AddDays(-3), Usuario = "Usuário Anônimo", TreinoId = 2 },
                new Comentario { Id = 5, Texto = "A rosca 21 é um exercício incrível!", DataCriacao = DateTime.Now.AddHours(-8), Usuario = "Usuário Anônimo", TreinoId = 2 },
                new Comentario { Id = 6, Texto = "Treino muito pesado, quase não consegui terminar!", DataCriacao = DateTime.Now.AddDays(-1), Usuario = "Usuário Anônimo", TreinoId = 3 },
                new Comentario { Id = 7, Texto = "Adoro treino de pernas, sempre dou meu máximo!", DataCriacao = DateTime.Now.AddHours(-12), Usuario = "Usuário Anônimo", TreinoId = 3 },
                new Comentario { Id = 8, Texto = "O agachamento livre é o rei dos exercícios!", DataCriacao = DateTime.Now.AddHours(-3), Usuario = "Usuário Anônimo", TreinoId = 3 }
            );
        }
    }
}