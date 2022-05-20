using CrudClientes.Models;
using CrudClientes.ViewModels;
using CrudClientes.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrudClientes.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            var clientes = _clienteRepository.GetClientes();
            var clienteViewModel = new List<ClienteViewModel>();
                foreach (var item in clientes)
            {
                clienteViewModel.Add(new ClienteViewModel() { Nome = item.Nome, Id = item.Id });
            }
            return View(clienteViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var cliente = _clienteRepository.GetCliente(id);

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (cliente.Id == 0)
                _clienteRepository.Create(cliente);
            else
                _clienteRepository.Edit(cliente, cliente.Id);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _clienteRepository.Delete(id);

            return RedirectToAction("Index");
        }


    }
}
