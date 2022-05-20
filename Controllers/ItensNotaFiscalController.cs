using CrudClientes.Models;
using CrudClientes.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudClientes.Controllers
{
    public class ItensNotaFiscalController : Controller
    {

        private readonly IItensNotaFiscalRepository _itensNotafiscalRepository;
        
        private readonly IProdutoRepository _produtolRepository;

        //private readonly INotaFiscalRepository _notafiscalRepository;

        public ItensNotaFiscalController(IItensNotaFiscalRepository itensNotafiscalRepository, INotaFiscalRepository notafiscalRepository, IProdutoRepository produtolRepository)
        {
            _itensNotafiscalRepository = itensNotafiscalRepository;
            
            _produtolRepository = produtolRepository;
        }

        public IActionResult Index()
        {
            var itensnotaFiscal = _itensNotafiscalRepository.GetItensNotasFiscais();

            return View(itensnotaFiscal);
        }

        public async Task<IActionResult> Create()
        {
            var produtos = await _produtolRepository.GetProdutos();
            ViewBag.Produtos = new SelectList(produtos, "Id", "NomeProduto");
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produtos =  await _produtolRepository.GetProdutos();
            ViewBag.Produtos = new SelectList(produtos, "Id", "NomeProduto");
            var itemnotaFiscal = _itensNotafiscalRepository.GetItemNotaFiscal(id);

            return View(itemnotaFiscal);
        }

        [HttpPost]
        public IActionResult Save(ItensNotaFiscal itensNotaFiscal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (itensNotaFiscal.Id == 0)
                _itensNotafiscalRepository.Create(itensNotaFiscal);
            else
                _itensNotafiscalRepository.Edit(itensNotaFiscal, itensNotaFiscal.Id);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _itensNotafiscalRepository.Delete(id);

            return RedirectToAction("Index");
        }

        




    }
}
