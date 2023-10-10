using HRDao;
using HRModel;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace HRZS.Controllers
{
    public class SalaryscaleController : Controller
    {
        // GET: Salaryscale
        SDDDao sd=new SDDDao();
        SsdDAO ss = new SsdDAO();
        SSDao sao = new SSDao();
        UsersDao usersDao = new UsersDao();

        //薪资标准登记
        public ActionResult checkin()
        {
            return View();
        }

        //查询报销项目表{sdd(新增表)}
        public async Task<ActionResult> SDDSelect()
        {
            IEnumerable<SDD> list=await sd.SDDselect();
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        //查询薪酬标准
        public async Task<ActionResult> SelectSSDAsync()
        {
            IEnumerable<SS> list = await sao.SelectSSDAsync();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // 增加薪酬标准单详细信息表数据(SSD)
        public async Task<ActionResult> SSDInsert(SSD sd)
        {
            int count = await ss.InsertSSDAsync(sd);
            return Json(count,JsonRequestBehavior.AllowGet);
        }

        //增加薪酬标准基本信息表数据(SS)
        public async Task<ActionResult> SSInsertAsync(SS sa)
        {
            int count=await sao.InsertSSAsync(sa);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //薪资标准登记复核
        public ActionResult Review()
        {
            return View();
        }

        //SS分页查询
        public async Task<ActionResult> SSFenye(FenYe<SS> fenYe)
        {
            fenYe = await sao.SelectSSAsync(fenYe);
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return Content(JsonConvert.SerializeObject(fenYe, Formatting.Indented, timeFormat));
        }

        //SS修改页面
        public ActionResult ReviewUpdate()
        {
            return View();
        }

        //查询SS详细信息
        public async Task<ActionResult> SleseSSDyid(string ss)
        {
            SS ssa = await sao.SleseSSDyid(ss);
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return Content(JsonConvert.SerializeObject(ssa, Formatting.Indented, timeFormat));
        }

        //查询SSD详细信息
        public async Task<ActionResult> SelectSSDDyid(string dd)
        {
            IEnumerable<SSD> sdd = await ss.SelectSSDDyid(dd);
            return Json(sdd, JsonRequestBehavior.AllowGet);
        }

        //SS修改
        public async Task<ActionResult> SSUpdate(SS ss)
        {
            int count = await sao.SSDUpdate(ss);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //薪酬标准查询
        public ActionResult Inquire()
        {
            return View();
        }

        //薪酬标准查询跳转的分页
        public ActionResult pagination()
        {
            return View();
        }

        //薪酬标准查询跳转的分页查询
        public async Task<ActionResult> UsersRoleFenye(FenYe<SS> fenYe)
        {
            FenYe<SS> list =await sao.UsersRoleFenye(fenYe);
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return Content(JsonConvert.SerializeObject(fenYe, Formatting.Indented, timeFormat));
        }

        //薪酬标准变更
        public ActionResult alter()
        {
            return View();
        }

        //薪酬标准变更跳转的分页查询
        public ActionResult alterSelect()
        {
            return View();
        }

        //薪酬标准变更跳转的分页修改
        public ActionResult alterUpdate()
        {
            return View();
        }

        //薪酬标准薪酬更改
        public async Task<ActionResult> SSDSalaryUpdate(int id,int uid)
        {
            int count = await sd.SSDSalaryUpdate(id,uid);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //薪酬标准内容更改
        public async Task<ActionResult> DyidSSUpdate(SS ss)
        {
            int count = await sao.SSUpdate(ss);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //薪酬标准查询用户数据
        public async Task<ActionResult> StandardSelectUser()
        {
            IEnumerable<Users> select=await usersDao.StandardSelectUser();
            return Json(select, JsonRequestBehavior.AllowGet);
        }
    }
}