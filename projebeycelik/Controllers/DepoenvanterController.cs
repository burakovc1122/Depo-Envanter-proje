using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml; // EPPlus kütüphanesini ekliyoruz
using projebeycelik.Data;
using projebeycelik.Models;
using System.IO;
using System.Linq;

namespace projebeycelik.Controllers
{
    public class DepoenvanterController : Controller
    {
        private readonly BeycelikContext _context;

        public DepoenvanterController(BeycelikContext context)
        {
            _context = context;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        // Index - Depo Tablosunu Listeleme ve Arama
        public IActionResult Index(string search)
        {
            var depoList = _context.Depo.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                depoList = depoList.Where(d =>
                    (d.Marka != null && d.Marka.Contains(search)) ||
                    (d.Product != null && d.Product.Contains(search)) ||
                    (d.AssetState != null && d.AssetState.Contains(search)) ||
                    (d.OrgSerialNumber != null && d.OrgSerialNumber.Contains(search)) ||
                    (d.ProductType != null && d.ProductType.Contains(search)) ||
                    (d.Site != null && d.Site.Contains(search)) ||
                    (d.UrunTipi != null && d.UrunTipi.Contains(search))
                );
            }

            ViewData["search"] = search;
            return View(depoList.ToList());
        }

        // Create (Veri Ekleme) - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Create (Veri Ekleme) - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Depo depo)
        {
            if (ModelState.IsValid)
            {
                _context.Depo.Add(depo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }


            return RedirectToAction(nameof(Index)); 
        }

        // Delete (Depo Silme) - GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var depo = _context.Depo.Find(id);

            if (depo == null)
            {
             
            }

            return View(depo);
        }

        // Delete (Depo Silme) - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var depo = await _context.Depo
                .FirstOrDefaultAsync(m => m.Id == id);  

            if (depo == null)
            {
                return NotFound("Depo verisi bulunamadı.");
            }

            _context.Depo.Remove(depo);
            await _context.SaveChangesAsync();  

            return RedirectToAction(nameof(Index));
        }


        // Excel Kaydetme İşlemi
        [HttpPost]
        public IActionResult ExportToExcel(string search, string fileName)
        {
            var filteredData = _context.Depo.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                filteredData = filteredData.Where(d =>
                    (d.Marka != null && d.Marka.Contains(search)) ||
                    (d.Product != null && d.Product.Contains(search)) ||
                    (d.AssetState != null && d.AssetState.Contains(search)) ||
                    (d.OrgSerialNumber != null && d.OrgSerialNumber.Contains(search)) ||
                    (d.ProductType != null && d.ProductType.Contains(search)) ||
                    (d.Site != null && d.Site.Contains(search)) ||
                    (d.UrunTipi != null && d.UrunTipi.Contains(search))
                );
            }

            var dataToExport = filteredData.ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Depo Envanteri");
                worksheet.Cells[1, 1].Value = "Marka";
                worksheet.Cells[1, 2].Value = "Product";
                worksheet.Cells[1, 3].Value = "Asset State";
                worksheet.Cells[1, 4].Value = "Org Serial Number";
                worksheet.Cells[1, 5].Value = "Product Type";
                worksheet.Cells[1, 6].Value = "Site";
                worksheet.Cells[1, 7].Value = "Urun Tipi";

                for (int i = 0; i < dataToExport.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = dataToExport[i].Marka;
                    worksheet.Cells[i + 2, 2].Value = dataToExport[i].Product;
                    worksheet.Cells[i + 2, 3].Value = dataToExport[i].AssetState;
                    worksheet.Cells[i + 2, 4].Value = dataToExport[i].OrgSerialNumber;
                    worksheet.Cells[i + 2, 5].Value = dataToExport[i].ProductType;
                    worksheet.Cells[i + 2, 6].Value = dataToExport[i].Site;
                    worksheet.Cells[i + 2, 7].Value = dataToExport[i].UrunTipi;
                }

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                // Dosya adı sağlanan parametreye göre ayarlanacak
                string fileNameToUse = string.IsNullOrEmpty(fileName) ? "DepoEnvanteri" : fileName;
                fileNameToUse = $"{fileNameToUse}.xlsx";

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileNameToUse);
            }
        }

        // Excel'e aktarılacak veriler için filtreleme yapılacak view
        public IActionResult ExportToExcelView(string search)
        {
            var depoList = _context.Depo.AsQueryable();

            // Arama parametresi varsa filtreleme yapılır
            if (!string.IsNullOrEmpty(search))
            {
                depoList = depoList.Where(d =>
                    (d.Marka != null && d.Marka.Contains(search)) ||
                    (d.Product != null && d.Product.Contains(search)) ||
                    (d.AssetState != null && d.AssetState.Contains(search)) ||
                    (d.OrgSerialNumber != null && d.OrgSerialNumber.Contains(search)) ||
                    (d.ProductType != null && d.ProductType.Contains(search)) ||
                    (d.Site != null && d.Site.Contains(search)) ||
                    (d.UrunTipi != null && d.UrunTipi.Contains(search))
                );
            }

            ViewData["search"] = search;
            return View(depoList.ToList());
        }
    }
}
