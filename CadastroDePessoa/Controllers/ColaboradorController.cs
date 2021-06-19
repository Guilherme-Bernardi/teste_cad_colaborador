using CadastroDePessoa.Models;
using CadastroDePessoa.Models.ViewModels;
using CadastroDePessoa.Services;
using CadastroDePessoa.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CadastroDePessoa.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly ColaboradorService _colaboradorService;
        private readonly DepartamentoService _departamentoService;


        public ColaboradorController(ColaboradorService colaboradorService, DepartamentoService departamentoService)
        {
            _colaboradorService = colaboradorService;
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _colaboradorService.FindAllAsync();

            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            var departamentos = await _departamentoService.FindAllAsync();
            var viewModel = new ColaboradorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.FindAllAsync();
                var viewModel = new ColaboradorFormViewModel { Colaborador = colaborador, Departamentos = departamentos };
                return View(viewModel);

            }
            await _colaboradorService.Insert(colaborador);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _colaboradorService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _colaboradorService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _colaboradorService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _colaboradorService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Departamentos> departamentos = await _departamentoService.FindAllAsync();
            ColaboradorFormViewModel viewModel = new ColaboradorFormViewModel { Colaborador = obj, Departamentos = departamentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.FindAllAsync();
                var viewModel = new ColaboradorFormViewModel { Colaborador = colaborador, Departamentos = departamentos };
                return View(viewModel);
            }

            if (id != colaborador.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            try
            {
                await _colaboradorService.UpdateAsync(colaborador);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}


