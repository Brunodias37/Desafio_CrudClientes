using CrudClientes.Repositories;
using CrudClientes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudClientes.Controllers
{
    public class RespostaController : Controller
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly IItensNotaFiscalRepository _itensNotaFiscalRepository;

        public RespostaController(INotaFiscalRepository notaFiscalRepository, IItensNotaFiscalRepository itensNotaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _itensNotaFiscalRepository = itensNotaFiscalRepository;
        }


        public IActionResult Index()
        {
            var resumoViewModel = new RespostaViewModel()
            {
                QuantidadeNfEmitidas = _notaFiscalRepository.QuantidadeNfEmitidas(),
                DataHoraPrimeiraNf = _notaFiscalRepository.DataHoraPrimeiraNf(),
                QuantidadeUniVendidasCif = _itensNotaFiscalRepository.QuantidadeUniVendidasCif(),

                ValorTotalTipoFob = _itensNotaFiscalRepository.ValorTotalTipoFob(),
                QuantidadeVendidasMouse = _itensNotaFiscalRepository.QuantidadeVendidasMouse(),
                QuantidadeVendidasMouseTeclado = _itensNotaFiscalRepository.QuantidadeVendidasMouseTeclado()
            };

            return View(resumoViewModel);
        }
    }
}
