using Insof.Models;

namespace Insof.Repository
{
    public interface IProductosRepository
    {
        public Task<IEnumerable<Usuario>> ObtenerProductosRepositoryAsync();
        public Task<Usuario> ObtenerProductoXIdRepositoryAsync(int id);
        public Task<Usuario> CrearProductoRepositoryAsync(Producto producto);
        public Task<Usuario?> ActualizarProductoRepositoryAsync(Producto producto);
        public Task BorrarProductoRepositoryAsync(Producto producto);

    }
}
