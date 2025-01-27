﻿using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                {
                    Id=1,
                    UserName="Mustafa"
                },
                new UserComment
                {
                    Id=2,
                    UserName="Ali"
                },
                new UserComment
                {
                    Id=3,
                    UserName="Ayşe"
                }
            };
            return View(commentvalues);
        }
    }
}
