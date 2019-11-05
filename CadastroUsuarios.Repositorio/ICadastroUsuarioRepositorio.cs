using System.Threading.Tasks;
using CadastroUsuarios.Dominio;

namespace CadastroUsuarios.Repositorio
{
    public interface ICadastroUsuarioRepositorio
    {
        void Add<T>(T entidade) where T : class;
        void Update<T>(T entidade) where T : class;
        void Delete<T>(T entidade) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Usuario[]> GetTodosUsuarios();

        Task<Usuario> GetUsuario(int id);

        bool VerificaUsuarioExiste(int id);

    }
}