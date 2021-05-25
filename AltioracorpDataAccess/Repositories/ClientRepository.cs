using AltioracorpDataAccess.Interfaces;
using AltioracorpDataAccess.Models;

namespace AltioracorpDataAccess.Repositories
{
    // REPOSITORIO CON LA LÓGICA DE UN CRUD CLIENTE HEREDADO DEL REPOSITORIO GENÉRICO
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        // private readonly AltioracorpContext db;
        public ClientRepository(AltioracorpContext db) : base(db)
        {
            // this.db = db;
        }

        /*public async Task<IEnumerable<Client>> GetByName(string name)
        {
            return await db.Set<Client>().ToListAsync();
        }*/
    }
}
