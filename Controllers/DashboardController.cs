using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR8.Data;
using SignalR8.Models;
using ClosedXML.Excel;
using System.Data;
using System.Diagnostics;

namespace SignalR8.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _oHostEnvironment;

        public DashboardController(ApplicationDbContext context, IWebHostEnvironment oHostEnvironment)
        {
            _context = context;
            _oHostEnvironment = oHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<FileResult> ExportProductInExcel()
        {
            var products = await  _context.Product.ToListAsync();
            var fileName = "products.xlsx";
            return GenerateExcel(fileName, products);
        }

        private FileResult GenerateExcel(string fileName, IEnumerable<Product> products)
        {
            DataTable dataTable = new DataTable("Persons");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Id"),
                new DataColumn("Name"),
                new DataColumn("Category"),
                new DataColumn("Price")
            });

            foreach (var emp in products)
            {
                dataTable.Rows.Add(emp.Id, emp.Name, emp.Category, emp.Price);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);

                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileName);
                }
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProductViewModel addProductRequest)
        {
            var product = new Product()
            {
                Name = addProductRequest.Name,
                Category = addProductRequest.Category,
                Price = addProductRequest.Price
            };

             await _context.Product.AddAsync(product);
             await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var y = await _context.Product.FirstOrDefaultAsync(x => x.Id == id);

            if (y != null)
            {
                var viewModel = new UpdateProductViewModel()
                {
                    Id = y.Id,
                    Name = y.Name,
                    Category = y.Category,
                    Price = y.Price
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateProductViewModel model)
        {
            var z = await _context.Product.FindAsync(model.Id);

            if (z != null)
            {
                z.Name = model.Name;
                z.Category = model.Category;
                z.Price = model.Price;

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateProductViewModel model)
        {
            var a = await _context.Product.FindAsync(model.Id);

            if (a != null)
            {
                _context.Product.Remove(a);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }    
}
