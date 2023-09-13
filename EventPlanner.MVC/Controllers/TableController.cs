using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EventPlanner.Models.TableModels;
using EventPlanner.Services.TableServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventPlanner.MVC.Controllers
{
    public class TableController : Controller
    {
        private readonly ILogger<TableController> _logger;
        private readonly ITableService _tableService;
        public TableController(ILogger<TableController> logger, ITableService tableService)
        {
            _logger = logger;
            _tableService = tableService;
        }

        public async Task<IActionResult> Index()
        {
            var tables = await _tableService.GetTables();
            return View(tables);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var table = await _tableService.GetTableById(id);
            return View(table);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> CreateTable(TableCreate model)
        {
            if(ModelState.IsValid == true)
            {
                if(await _tableService.CreateTable(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ModelState);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var table = await _tableService.GetTableById(id);
            var tableEdit = new TableEdit
            {
                Id = table.Id,
                AmountOfChairs = table.AmountOfChairs,
                Price = table.Price,
            };
            return View(tableEdit);
        }

        public async Task<IActionResult> EditTable(TableEdit model)
        {
            if(ModelState.IsValid == true)
            {
                if(await _tableService.UpdateTable(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(ModelState);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var table = await _tableService.GetTableById(id);
            
            return View(table);
        }

        public async Task<IActionResult> DeleteTable(int id)
        {
                if(await _tableService.DeleteTable(id))
                {
                    return RedirectToAction(nameof(Index));
                }
            
            return BadRequest("Invalid Id.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}