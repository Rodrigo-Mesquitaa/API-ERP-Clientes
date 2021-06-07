using ERP_API_Shared.Repository;
using ERP_API_Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ERP_API_Clientes.Controllers
{
    [Route("api/cliente/")]
    public class ClienteController : Controller
    {
        [HttpPost]
        public ClienteVM Add([FromBody] ClienteVM DadosCliente)
        {
            BaseRepository.RepositorioClientes.Add(DadosCliente);
            return DadosCliente;
        }

        [HttpGet("{id}")]
        public ClienteVM GetClienteById(string id)
        {
            var cliente = BaseRepository.RepositorioClientes.Where(cli => cli.id == id).FirstOrDefault();
            return cliente;
        }

        [HttpGet]
        public ICollection<ClienteVM> GetAllClientes()
        {
            return BaseRepository.RepositorioClientes;
        }

        [HttpDelete("{id}")]
        public object Deletar(string id)
        {
            var cliente = BaseRepository.RepositorioClientes.Where(cli => cli.id == id).FirstOrDefault();
            if (BaseRepository.RepositorioClientes.Remove(cliente))
            {
                return new
                {
                    resultado = "Cliente: " + id + " excluido com sucesso!"
                };
            }
            else
            {
                return new
                {
                    resultado = "Erro ao excluir o cliente " + id
                };
            }
        }
    }
}