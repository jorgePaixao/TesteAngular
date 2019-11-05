using System.Linq;
using System.Threading.Tasks;
using CadastroUsuarios.Dominio;
using Microsoft.EntityFrameworkCore;

namespace CadastroUsuarios.Repositorio
{
    public class CadastroUsuarioRepositorio : ICadastroUsuarioRepositorio
    {
        public CadastroContext _context { get; }

        public CadastroUsuarioRepositorio(CadastroContext context)
        {
            _context = context;
        }
        public void Add<T>(T entidade) where T : class
        {
            _context.Add(entidade);
        }
        public void Update<T>(T entidade) where T : class
        {
            _context.Update(entidade);
        }
        public void Delete<T>(T entidade) where T : class
        {
            _context.Remove(entidade);
        }

        public async Task<Usuario[]> GetTodosUsuarios()
        {
            IQueryable<Usuario>  query = _context.Usuarios;

            return await query.ToArrayAsync(); 
        }

        public Usuario GetUsuario(int id)
        {
            Usuario  usuario = _context.Usuarios.Where(x => x.UsuarioId == id).FirstOrDefault();  
            
            return usuario; 
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}