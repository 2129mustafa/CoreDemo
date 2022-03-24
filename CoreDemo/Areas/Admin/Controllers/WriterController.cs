using BusinessLayer.Concrete;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(GetWriter());
            return Json(jsonWriters);
        }
        public IActionResult GetByWriterId(int writerid)
        {
            var findWriter = GetWriter().FirstOrDefault(x => x.Id == writerid);
            //var findWriter = writers.FirstOrDefault(x => x.Id == writerid);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
        
        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            Writer writer = new Writer();
            writer.WriterName = w.Name;
            writer.WriterAbout = w.About;
            writer.WriterStatus = true;
            writer.WriterImage = w.Image;
            writer.WriterPassword = w.Password;
            writer.WriterMail = w.Mail;
            writerManager.TAdd(writer);
            //GetWriter().Add(w);
            //writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writerid = writerManager.TGetById(id);
            writerManager.TDelete(writerid);

           // var writer = GetWriter().FirstOrDefault(x => x.Id == id);
            //var writer = writers.FirstOrDefault(x => x.Id == id);
           // writerManager.TDelete(w);
            return Json(writerid);
        }

        public IActionResult UpdateWriter(WriterClass w,int id)
        {
            var writer = writerManager.TGetById(id);
            writer.WriterName = w.Name;
            writer.WriterMail = w.Mail;
            writer.WriterPassword = w.Password;

            writerManager.TUpdate(writer);
            var jsonwriter = JsonConvert.SerializeObject(w);
            return Json(jsonwriter);
        }
        public List<WriterClass> GetWriter()
        {
            List<WriterClass> wc = new List<WriterClass>();
            using (var c=new Context())
            {      
                wc = c.Writers.Select(x => new WriterClass
                {
                    Id = x.WriterId,
                    Name = x.WriterName,
                    About = x.WriterAbout,
                    Mail = x.WriterMail,
                    Password = x.WriterPassword,
                    Image = x.WriterImage,
                    Status = x.WriterStatus
                }).ToList();
            }
            return wc;
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            
            new WriterClass
            {
                Id=1,
                Name="Ayşe"
            },
             new WriterClass
            {
                Id=2,
                Name="Mehmet"
            },
              new WriterClass
            {
                Id=3,
                Name="Fatma"
            },
               new WriterClass
            {
                Id=4,
                Name="Emel"
            },
                new WriterClass
            {
                Id=5,
                Name="Kübra"
            }
        };
    }
}
