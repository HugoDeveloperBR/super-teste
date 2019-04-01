using SuperTest.Domain.Entities.Usuarios;
using SuperTest.Domain.Repositories.Usuarios;
using SuperTest.Infra.Repository.Context;
using System.Linq;

namespace SuperTest.Infra.Repository.Data
{
    public sealed class UsuarioRepository : IUsuarioRepository
    {
        private readonly SuperTestDbContext _context;

        public UsuarioRepository(SuperTestDbContext context)
        {
            _context = context;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            return _context.Usuarios.Where(u => u.Email.Equals(email)).FirstOrDefault();
        }
    }
}