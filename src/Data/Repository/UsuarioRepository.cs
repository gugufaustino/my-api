using Business.Interface.Repository;
using Business.Models;
using Data.Contexto;

namespace Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext contexto)
            : base(contexto)
        {   

        }

    }
}
