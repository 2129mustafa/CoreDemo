using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook=new XLWorkbook()) //workbook=>çalışma kitabı
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); //worksheet=>çalışma sayfası ve ismi ayarladık
                worksheet.Cell(1, 1).Value = "Blog ID";  //1.satır,1.sutun
                worksheet.Cell(1, 2).Value = "Blog Adı"; //1.satır,2.sutun

                int blogRowCount = 2; //çünkü 1.satıra başlıklarımızı yazdık verilerimiz 2.satırdan başlayacak.

                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(blogRowCount, 1).Value = item.ID;
                    worksheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }

                using (var stream=new MemoryStream())   //memoride veri tutuyo gibi düşünelim
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray(); //verileri arraya dönüştür
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }

        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID=1,BlogName="C# Programlamaya Giriş"},
                new BlogModel{ID=2,BlogName="Tesla Firmasının Araçları"},
                new BlogModel{ID=3,BlogName="2022 Olimpiyatları"},
                new BlogModel{ID=4,BlogName="Yapay Zeka Dünyayı Ele Geçirecek Mi?"},
                new BlogModel{ID=5,BlogName="Php dili ölüyor Mu?"},
                new BlogModel{ID=6,BlogName="Kamp Hazırlıkları Başladı"},
            };
            return bm;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook()) //workbook=>çalışma kitabı
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); //worksheet=>çalışma sayfası ve ismi ayarladık
                worksheet.Cell(1, 1).Value = "Blog ID";  //1.satır,1.sutun
                worksheet.Cell(1, 2).Value = "Blog Adı"; //1.satır,2.sutun

                int blogRowCount = 2; //çünkü 1.satıra başlıklarımızı yazdık verilerimiz 2.satırdan başlayacak.

                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(blogRowCount, 1).Value = item.ID;
                    worksheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())   //memoride veri tutuyo gibi düşünelim
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray(); //verileri arraya dönüştür
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }
        }
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using (var c=new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel2
                {
                    ID = x.BlogId,
                    BlogName = x.BlogTitle
                }).ToList();
            }
            return bm;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
