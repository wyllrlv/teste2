using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ex_full.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treinos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Avaliacao = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treinos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TreinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Treinos_TreinoId",
                        column: x => x.TreinoId,
                        principalTable: "Treinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Series = table.Column<int>(type: "int", nullable: false),
                    Repeticoes = table.Column<int>(type: "int", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TreinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicios_Treinos_TreinoId",
                        column: x => x.TreinoId,
                        principalTable: "Treinos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Treinos",
                columns: new[] { "Id", "Avaliacao", "Descricao", "Titulo" },
                values: new object[,]
                {
                    { 1, 4.5, "Treino focado no desenvolvimento dos músculos peitorais e tríceps, ideal para iniciantes e intermediários. Concentre-se na execução correta dos movimentos.", "Treino de Peito e Tríceps" },
                    { 2, 4.7999999999999998, "Sessão completa para fortalecimento das costas e bíceps. Foque na conexão mente-músculo para máximos resultados.", "Treino de Costas e Bíceps" },
                    { 3, 4.2000000000000002, "Treino intenso para membros inferiores. Prepare-se para um dos treinos mais desafiadores, mas também mais recompensadores.", "Treino de Pernas" }
                });

            migrationBuilder.InsertData(
                table: "Comentarios",
                columns: new[] { "Id", "DataCriacao", "Texto", "TreinoId", "Usuario" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 6, 20, 43, 56, 661, DateTimeKind.Local).AddTicks(4034), "Excelente treino! Senti bastante o peito trabalhando.", 1, "Usuário Anônimo" },
                    { 2, new DateTime(2025, 6, 7, 20, 43, 56, 663, DateTimeKind.Local).AddTicks(7500), "Muito bom para iniciantes, recomendo!", 1, "Usuário Anônimo" },
                    { 3, new DateTime(2025, 6, 8, 15, 43, 56, 663, DateTimeKind.Local).AddTicks(7515), "Poderia ter mais exercícios de tríceps.", 1, "Usuário Anônimo" },
                    { 4, new DateTime(2025, 6, 5, 20, 43, 56, 663, DateTimeKind.Local).AddTicks(7525), "Treino pesado, mas muito eficiente!", 2, "Usuário Anônimo" },
                    { 5, new DateTime(2025, 6, 8, 12, 43, 56, 663, DateTimeKind.Local).AddTicks(7527), "A rosca 21 é um exercício incrível!", 2, "Usuário Anônimo" },
                    { 6, new DateTime(2025, 6, 7, 20, 43, 56, 663, DateTimeKind.Local).AddTicks(7529), "Treino muito pesado, quase não consegui terminar!", 3, "Usuário Anônimo" },
                    { 7, new DateTime(2025, 6, 8, 8, 43, 56, 663, DateTimeKind.Local).AddTicks(7530), "Adoro treino de pernas, sempre dou meu máximo!", 3, "Usuário Anônimo" },
                    { 8, new DateTime(2025, 6, 8, 17, 43, 56, 663, DateTimeKind.Local).AddTicks(7531), "O agachamento livre é o rei dos exercícios!", 3, "Usuário Anônimo" }
                });

            migrationBuilder.InsertData(
                table: "Exercicios",
                columns: new[] { "Id", "Nome", "Observacoes", "Repeticoes", "Series", "TreinoId" },
                values: new object[,]
                {
                    { 1, "Supino Reto", "Controle a descida", 12, 4, 1 },
                    { 2, "Supino Inclinado", "45° de inclinação", 10, 3, 1 },
                    { 3, "Crucifixo", "Amplitude completa", 12, 3, 1 },
                    { 4, "Tríceps Testa", "Cotovelos fixos", 15, 3, 1 },
                    { 5, "Tríceps Corda", "Extensão completa", 12, 3, 1 },
                    { 6, "Mergulho", "Até a falha", 8, 2, 1 },
                    { 7, "Barra Fixa", "Pegada pronada", 8, 4, 2 },
                    { 8, "Remada Curvada", "Tronco a 45°", 10, 4, 2 },
                    { 9, "Puxada Frente", "Peito para frente", 12, 3, 2 },
                    { 10, "Rosca Direta", "Sem balanço", 12, 4, 2 },
                    { 11, "Rosca Martelo", "Pegada neutra", 10, 3, 2 },
                    { 12, "Rosca 21", "7+7+7 repetições", 21, 2, 2 },
                    { 13, "Agachamento Livre", "Profundidade completa", 8, 5, 3 },
                    { 14, "Leg Press", "Pés na largura dos ombros", 15, 4, 3 },
                    { 15, "Extensora", "Pausa no topo", 12, 3, 3 },
                    { 16, "Flexora", "Contração isométrica", 12, 3, 3 },
                    { 17, "Panturrilha em Pé", "Amplitude completa", 20, 4, 3 },
                    { 18, "Panturrilha Sentado", "Pausa na contração", 15, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_TreinoId",
                table: "Comentarios",
                column: "TreinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicios_TreinoId",
                table: "Exercicios",
                column: "TreinoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Exercicios");

            migrationBuilder.DropTable(
                name: "Treinos");
        }
    }
}
