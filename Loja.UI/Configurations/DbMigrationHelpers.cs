
using Loja.Data.Context;
using Loja.Data.Model;
using Loja.UI.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Loja.UI.Configurations
{
    public static class DbMigrationHelperExtension
    {
        public static void UseDbMigrationHelper(this WebApplication app)
        {
            DbMigrationHelpers.EnsureSeedData(app).Wait();
        }
    }

    public static class DbMigrationHelpers
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<DataDbContext>();
            var contextId = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (env.IsDevelopment() || env.IsEnvironment("Docker") || env.IsStaging())
            {
                await context.Database.MigrateAsync();
                await contextId.Database.MigrateAsync();

                await EnsureSeedProducts(context, contextId);
            }
        }

        private static async Task EnsureSeedProducts(DataDbContext context, ApplicationDbContext contextId)
        {

            var idVendedor = Guid.NewGuid().ToString();

            if (!context.Vendedores.Any())
            {

                await context.Vendedores.AddAsync(new Vendedor()
                {
                    Id = idVendedor,
                    Nome = "Vendedor Teste",
                    Cpf = "49445522389",
                });

                await context.SaveChangesAsync();
            }

            if (!context.Categorias.Any())
            {

                await context.Categorias.AddAsync(new Categoria()
                {
                    Id = 1,
                    Nome = "Livros",
                    Descricao = "Livros Didáticos"
                });

                await context.Categorias.AddAsync(new Categoria()
                {
                    Id = 2,
                    Nome = "Cursos",
                    Descricao = "Cursos DEVXPERT FULL STACK .NET"
                });
            }

            if (!context.Produtos.Any())
            {

                await context.Produtos.AddAsync(new Produto()
                {
                    Nome = "Livro CSS",
                    Descricao = "A criação de Layout CSS sempre foi uma tarefa trabalhosa, mas agora os profissionais têm uma ferramenta poderosa ao seu alcance",
                    Preco = 95,
                    ImagemUrl = "/uploads/LivroCSS.jpg",
                    QuantidadeEstoque = 10,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    CategoriaId = 1,
                    VendedorId = idVendedor

                });

                await context.Produtos.AddAsync(new Produto()
                {
                    Nome = "Livro Bootstrap",
                    Descricao = "Bootstrap é a escolha mais popular entre os desenvolvedores para construir sites e aplicativos modernos e responsivos",
                    Preco = 64,
                    ImagemUrl = "/uploads/LivroBootstrap.jpg",
                    QuantidadeEstoque = 23,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    CategoriaId = 1,
                    VendedorId = idVendedor
                });

                await context.Produtos.AddAsync(new Produto()
                {
                    Nome = "Curso Fundamentos do C#",
                    Descricao = "Vá do 0 ao avançado em C# com esse curso",
                    Preco = 190,
                    ImagemUrl = "/uploads/cursoC.jpg",
                    QuantidadeEstoque = 90,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    CategoriaId = 2,
                    VendedorId = idVendedor
                });

                await context.Produtos.AddAsync(new Produto()
                {
                    Nome = "Iniciando com ASP.NET Core",
                    Descricao = "Tudo o que você precisa sabar para iniciar no mundo de ASP.NET Core",
                    Preco = 190,
                    ImagemUrl = "/uploads/cursoAspNetCore.jpg",
                    QuantidadeEstoque = 90,
                    Ativo = true,
                    DataCadastro = DateTime.Now,
                    CategoriaId = 2,
                    VendedorId = idVendedor
                });

                await context.SaveChangesAsync();
            }

            if (!contextId.Users.Any())
            {


                await contextId.Users.AddAsync(new IdentityUser
                {
                    Id = idVendedor,
                    UserName = "teste@teste.com",
                    NormalizedUserName = "TESTE@TESTE.COM",
                    Email = "teste@teste.com",
                    NormalizedEmail = "TESTE@TESTE.COM",
                    AccessFailedCount = 0,
                    LockoutEnabled = false,
                    PasswordHash = "AQAAAAIAAYagAAAAEEdWhqiCwW/jZz0hEM7aNjok7IxniahnxKxxO5zsx2TvWs4ht1FUDnYofR8JKsA5UA==",
                    TwoFactorEnabled = false,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                });

                await contextId.SaveChangesAsync();
            }

        }
    }
}