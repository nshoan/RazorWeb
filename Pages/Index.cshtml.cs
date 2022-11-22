﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyBlogContext _myBlogContext;
        public IndexModel(ILogger<IndexModel> logger, MyBlogContext myBlogContext)
        {
            _logger = logger;
            _myBlogContext = myBlogContext;
        }

        public void OnGet()
        {
            var posts = (from a in _myBlogContext.Article
                        orderby a.Created descending
                        select a).ToList();
            ViewData["posts"]= posts;
        }
    }
}
