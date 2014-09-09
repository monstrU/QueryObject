using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcExample.Models.ServiceLayer;
using QueryObjectMvc.Models;

namespace QueryObjectMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var service = new DataServices();
            var nickName = "Basel";
            AuthorModel author=null;
            try
            {
                author = service.GetAuthor(nickName);
            }
            catch (Exception e)
            {
                TempData.Add("error", string.Format("ошибка {0} ", e.Message)); 
            }

            if (author == null)
            {
                TempData.Add("error", string.Format("Пользователь {0} не найден в базе.", nickName)); 
            }
            return View(author);
        }

    }
}
