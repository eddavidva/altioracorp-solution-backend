using AltioracorpDataAccess.Interfaces;
using AltioracorpDataAccess.Models;

namespace AltioracorpDataAccess.Services
{
    public class ClientService : GenericService<Client>, IClientService
    {
        // private IClientRepository clientRepository;
        public ClientService(IClientRepository clientRepository) : base (clientRepository)
        {
            // this.clientRepository = clientRepository;
        }

        /*public async Task<IEnumerable<Client>> GetByName(string name)
        {
            return await clientRepository.GetByName(name);
        }*/
    }
}
