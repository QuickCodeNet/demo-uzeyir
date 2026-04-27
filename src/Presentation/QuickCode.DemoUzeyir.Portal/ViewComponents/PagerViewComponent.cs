using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickCode.DemoUzeyir.Portal.Models;

namespace QuickCode.DemoUzeyir.Portal.ViewComponents
{
    public class Pager : ViewComponent
    {

        public Pager()
        {

        }

        public IViewComponentResult Invoke(PagerData pagerData)
        {

            return View(pagerData);
        }

    }


}
