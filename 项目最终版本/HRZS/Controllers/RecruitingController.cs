using HRDao;
using HRModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRZS.Controllers
{
    /// <summary>
    /// 招聘管理控制器
    /// </summary>
    public class RecruitingController : Controller
    {

        EMRDao eMRDao= new  EMRDao();

        // GET: Recruiting
        /// <summary>
        /// 职位发布展示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult PositionIssueShow()
        {
            return View();
        }
        /// <summary>
        /// 职位发布数据添加
        /// </summary>
        /// <param name="EMR"></param>
        /// <returns></returns>
        public async Task<ActionResult> InsertEMR(EMR emr)
        {
            int result = await eMRDao.AddEMR(emr);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 职位发布展示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult PositionShow()
        {
            return View();
        }
        /// <summary>
        /// 职位发布更改展示分页数据
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> EMRFenYe(FenYe<EMR> fenYe)
        {
            fenYe = await eMRDao.ERMFenYe(fenYe);
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return Content(JsonConvert.SerializeObject(fenYe, Formatting.Indented, timeFormat));

        }
        /// <summary>
        /// 职位发布更改展示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult PositionUpdateShow()
        {
            return View();
        }
        /// <summary>
        /// 职位发布更改数据展示
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> EMRSelecteById(int id)
        {
            EMR eMR = await eMRDao.EMRSelecteById(id);
            return Json(eMR, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 职位发布更改数据
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> EMRUpdate(EMR eMR)
        {
            int result = await eMRDao.UpdateEMR(eMR);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 职位发布删除
        /// </summary>
        /// <param name="cpc"></param>
        /// <returns></returns>
        public async Task<ActionResult> EMRDelete(int id)
        {
            int result = await eMRDao.EMRDeleteAsync(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 职位发布查询展示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult PositionLookUpShow()
        {
            return View();
        }


    }
}