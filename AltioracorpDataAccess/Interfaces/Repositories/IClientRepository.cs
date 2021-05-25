using AltioracorpDataAccess.Models;

namespace AltioracorpDataAccess.Interfaces
{
    // DEFINICIÓN DE LA ESTRUCTURA PARA UN CRUD DE CLIENTE HEREDADO DE LA INTERFAZ GENÉRICA
    public interface IClientRepository : IGenericRepository<Client>
    {
        // Task<IEnumerable<Client>> GetByName(string name);
    }
}
