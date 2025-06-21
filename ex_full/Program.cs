using Microsoft.EntityFrameworkCore;
using ex_full.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

// Entity Framework
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Banco de dados - tentar criar mas não quebrar se der erro
try
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}
catch (Exception ex)
{
    // Log do erro mas não quebrar a aplicação
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "Erro ao configurar banco de dados: {Message}", ex.Message);
}

// Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Treino}/{action=Detalhes}/{id=1}");

app.Run();