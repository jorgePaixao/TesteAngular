using CadastroUsuarios.Dominio;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarios.Repositorio
{
    public class CadastroContext : DbContext
    {
        public CadastroContext(DbContextOptions<CadastroContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}