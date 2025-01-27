﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class NewsLatterController : Controller
    {
        NewsLatterManager newsLatterManager = new NewsLatterManager(new EfNewsLatterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(NewsLatter p)
        {
            p.MailStatus = true;
            newsLatterManager.AddNewsLatter(p);
            return PartialView();
        }
    }
}
