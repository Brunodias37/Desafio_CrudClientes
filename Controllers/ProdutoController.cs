using CrudClientes.Models;
using CrudClientes.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudClientes.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepository.GetProdutos();

            return View(produtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var produto = _produtoRepository.GetProduto(id);

            return View(produto);
        }

        [HttpPost]
        public IActionResult Save(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (produto.Id == 0)
                _produtoRepository.Create(produto);
            else
                _produtoRepository.Edit(produto, produto.Id);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _produtoRepository.Delete(id);

            return RedirectToAction("Index");
        }






    }
}
