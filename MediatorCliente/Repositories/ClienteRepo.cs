using MediatorCliente.Application.Models;

namespace MediatorCliente.Repositories
{
    public class ClienteRepo : IRepository<Cliente>
    {
        private static Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();

        public async Task<IEnumerable<Cliente>> GetAll() 
        {
            return await Task.Run(() => clientes.Values.ToList());
        }
        public async Task<Cliente> Get(int id)
        {
            return await Task.Run(() => clientes.GetValueOrDefault(id));
        }

        public async Task Add(Cliente cliente)
        {
            await Task.Run(() => clientes.Add(cliente.ClienteId, cliente));
        }

        public async Task Edit(Cliente cliente)
        {
            await Task.Run(() =>
            {
                clientes.Remove(cliente.ClienteId);
                clientes.Add(cliente.ClienteId, cliente);
            });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => clientes.Remove(id));
        }
    }
}
