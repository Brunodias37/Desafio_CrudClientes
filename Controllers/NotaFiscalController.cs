using CrudClientes.Models;
using CrudClientes.Repositories;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudClientes.Controllers
{
    public class NotaFiscalController : Controller
    {

        private readonly INotaFiscalRepository _notafiscalRepository;
        private readonly IClienteRepository _clienteRepository;

        public NotaFiscalController(INotaFiscalRepository notafiscalRepository, IClienteRepository clienteRepository)
        {
            _notafiscalRepository = notafiscalRepository;
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            var notaFiscal = _notafiscalRepository.GetNotasFiscais();

            return View(notaFiscal);
        }

        public IActionResult Create()
        {
            var clientes = _clienteRepository.GetClientes();
            ViewBag.Clientes = new SelectList(clientes,"Id","Nome");
            return View();
        }

        
        public IActionResult Edit(int id)
        {
            
            var clientes = _clienteRepository.GetClientes();
            ViewBag.Clientes = new SelectList(clientes, "Id", "Nome");
            var notaFiscal = _notafiscalRepository.GetNotaFiscal(id);

            return View(notaFiscal);
        }

        [HttpPost]
        public IActionResult Save(NotaFiscal notaFiscal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (notaFiscal.Id == 0)
                _notafiscalRepository.Create(notaFiscal);
            else
                _notafiscalRepository.Edit(notaFiscal, notaFiscal.Id);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _notafiscalRepository.Delete(id);

            return RedirectToAction("Index");
        }


    }
}
