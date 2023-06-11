using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Insof.Models;
using Insof.Repository;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace Insof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IUsuariosRepository usuariosRepository { get; set; }
        public UsuariosController(IUsuariosRepository repository)
        {
            usuariosRepository = repository;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {

            return await usuariosRepository.ObtenerUsuariosRepositoryAsync() == null
                ? NotFound()
                : Ok(usuariosRepository.ObtenerUsuariosRepositoryAsync());
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            return await usuariosRepository.ObtenerUsuarioXIdRepositoryAsync(id) == null
                ? NotFound()
                : Ok(usuariosRepository.ObtenerUsuarioXIdRepositoryAsync(id));
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.NumeroDocumento)
            {
                return BadRequest();
            }

            return await usuariosRepository.ActualizarUsuarioRepositoryAsync(usuario) == null 
                ? NotFound() 
                : Ok(usuariosRepository.ActualizarUsuarioRepositoryAsync(usuario));

        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            return await usuariosRepository.CrearUsuarioRepositoryAsync(usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await usuariosRepository.ObtenerUsuarioXIdRepositoryAsync(id);
            if (usuario.Equals(null))
            {
                return NotFound();
            }

            await usuariosRepository.BorrarUsuarioRepositoryAsync(usuario);

            return NoContent();
        }

    }
}
