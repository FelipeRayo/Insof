using Insof.DTO;
using Insof.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Insof.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly InsofContext _context;

        public UsuariosRepository(InsofContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosRepositoryAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObtenerUsuarioXIdRepositoryAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario?> ActualizarUsuarioRepositoryAsync(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.NumeroDocumento))
                {
                    return null;
                }
            }

            return await ObtenerUsuarioXIdRepositoryAsync(usuario.NumeroDocumento);
        }

        public async Task BorrarUsuarioRepositoryAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> CrearUsuarioRepositoryAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return await ObtenerUsuarioXIdRepositoryAsync(usuario.NumeroDocumento);
        }

        public async Task<bool> IniciarSesionRepositoryAsync(InicioSesion usuario)
        {
            var credenciales = await (from user in _context.Usuarios
                                where user.NombreUsuario == usuario.NombreUsuario
                                && user.Clave == usuario.Clave
                                select new InicioSesion
                                {
                                    NombreUsuario = user.NombreUsuario,
                                    Clave = user.Clave
                                }).FirstOrDefaultAsync();

            return credenciales == null;
        }

        private bool UsuarioExists(int id)
        {
            var usuario = ObtenerUsuarioXIdRepositoryAsync(id);
            return usuario.Id == 0;
        }

    }
}
