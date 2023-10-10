using HRDao;
using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRZS.Controllers
{
    public class UsersController : Controller
    {
        UsersDao usersDao=new UsersDao();
        JurisdictionDao jdao=new JurisdictionDao();
        // GET: Users
        public ActionResult LoginShow()
        {
            return View();
        }

        public async Task<ActionResult> Login(string UName, string UPassWord)
        {
            IEnumerable<Users> users = await usersDao.UsersSelectByIdAsync(UName, UPassWord);
            return Json(users, JsonRequestBehavior.AllowGet);

        }

        //去主页
        public ActionResult Host()
        {
            return View();
        }
        //主页图片
        public ActionResult Cs()
        {
            return View();
        }

        //左侧边栏
        public async Task<ActionResult> CsTask(int id)
        {
            List<Jurisdiction> lidt = jdao.SelectJurisdiction(id);
            return Json(lidt, JsonRequestBehavior.AllowGet);
        }
    }
}