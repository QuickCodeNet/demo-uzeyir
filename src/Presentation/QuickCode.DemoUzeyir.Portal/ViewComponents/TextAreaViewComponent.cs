using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickCode.DemoUzeyir.Portal.Models;

namespace QuickCode.DemoUzeyir.Portal.ViewComponents
{
    public class TextArea : ViewComponent
    {

        public TextArea()
        {

        }

        public IViewComponentResult Invoke(TextAreaData model)
        {
            return View(model);
        }

    }


}
