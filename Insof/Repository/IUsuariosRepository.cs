using Insof.DTO;
using Insof.Models;

namespace Insof.Repository
{
    public interface IUsuariosRepository
    {
        public Task<IEnumerable<Usuario>> ObtenerUsuariosRepositoryAsync();
        public Task<Usuario> ObtenerUsuarioXIdRepositoryAsync(int id);
        public Task<Usuario> CrearUsuarioRepositoryAsync(Usuario usuario);
        public Task<Usuario?> ActualizarUsuarioRepositoryAsync(Usuario usuario);
        public Task BorrarUsuarioRepositoryAsync(Usuario usuario);
        public Task<bool> IniciarSesionRepositoryAsync(InicioSesion usuario);

    }
}
