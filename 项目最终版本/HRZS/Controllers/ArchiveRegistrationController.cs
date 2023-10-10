using Dapper;
using HRDao;
using HRModel;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace HRZS.Controllers
{
    /// <summary>
    /// 人力资源档案登记控制器模块
    /// </summary>
    public class ArchiveRegistrationController : Controller
    {

        CFTKDao cFTKDao = new CFTKDao();
        CMDao cMDao = new CMDao();
        CPCDao cPCDao = new CPCDao();
        HFDao hFDao = new HFDao();
        ERDao eRDao = new ERDao();
        HFDDao hfdDao = new HFDDao();
        // GET: ArchiveRegistration

        /// <summary>
        /// 查询列表展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchiveRegistrationShow()
        {
            return View();
        }
        /// <summary>
        /// 多添加查询建档列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchiveRegistrationSelecte()
        {
            return View();
        }
        /// <summary>
        /// 条件查询后详细信息展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchiveRegistrationInfoShow()
        {
            return View();
        }
        /// <summary>
        /// 查询列表展示后档案登记展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchiveRegistrationShow2()
        {
            return View();
        }
        /// <summary>
        /// 待复核列表展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchiveRegistrationReviewShow()
        {
            return View();
        }
        /// <summary>
        /// 可更改列表展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchiveRegistrationUpdateShow()
        {
            return View();
        }
        /// <summary>
        /// 可更改列表展示(传值修改)
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchiveRegistrationUpdateShow2()
        {
            return View();
        }
        /// <summary>
        /// 查询列表展示后复核数据展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchiveRegistrationReviewShow2()
        {
            return View();
        }
        /// <summary>
        /// 档案表数据更改添加
        /// </summary>
        /// <param name="EI"></param>
        /// <returns></returns>
        public async Task<ActionResult> AddHFD(HFD hfd)
        {
            int result = await hfdDao.AddHFD(hfd);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 档案表数据添加
        /// </summary>
        /// <param name="EI"></param>
        /// <returns></returns>
        public async Task<ActionResult> AddHF(HF hf)
        {
            int result = await hFDao.AddHF(hf);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 档案表数据修改（修改）
        /// </summary>
        /// <param name="hf"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateHF2(HF hf)
        {
            int result = await hFDao.UpdateHF2(hf);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 档案表数据复核（修改）
        /// </summary>
        /// <param name="EI"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateHF(HF hf)
        {
            int result = await hFDao.UpdateHF(hf);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 已建档
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateStatusER(int id)
        {
            int result = await eRDao.UpdateStatusER5(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 人力资源复核展示分页数据
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> HFFenYe(FenYe<HF> fenYe)
        {
            fenYe = await hFDao.HFFenYe(fenYe);
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return Content(JsonConvert.SerializeObject(fenYe, Formatting.Indented, timeFormat));

        }
        /// <summary>
        /// 人力资源档案查询
        /// </summary>
        /// <param name="HufId"></param>
        /// <returns></returns>
        public async Task<ActionResult> HFSelecteById(int id)
        {
            HF hf = await hFDao.HFSelecteById(id);
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return Content(JsonConvert.SerializeObject(hf, Formatting.Indented, timeFormat));
        }
        /// <summary>
        /// 档案数据的查询分页展示（条件查询）
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        public async Task<ActionResult> DanAnSelect(FenYe<HF> fenYe)
        {
            fenYe = await hFDao.DanAnSelect(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 查询职位
        /// </summary>
        /// <returns></returns>
        public ActionResult ZhiWeiCascadeAsync()
        {
            List<CM> cMs = cMDao.SelectCMLEVELAsync();
            return Json(cMs, JsonRequestBehavior.AllowGet);
           
        }
        /// <summary>
        /// 查询机构
        /// </summary>
        /// <returns></returns>
        public ActionResult CascadeAsync()
        {
            List<CFTK> cFTKs = cFTKDao.SelectLEVELAsync();
            return Json(cFTKs, JsonRequestBehavior.AllowGet);
            return View();
        }
        
    }
}