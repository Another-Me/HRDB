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

namespace HRZS.Controllers
{

    
    /// <summary>
    /// 面试管理控制器
    /// </summary>
    public class InterviewManagementController : Controller
    {
        // GET: InterviewManagement

        EIDao eIDao =new EIDao();
        ERDao erDao =new ERDao();
        /// <summary>
        /// 面试登记展示
        /// </summary>
        /// <returns></returns>
        public ActionResult InterviewResltRegister()
        {
            return View();
        }
        /// <summary>
        /// 面试结果登记展示（传值）
        /// </summary>
        /// <returns></returns>
        public ActionResult InterviewResltRegisterShow()
        {
            return View();
        }
        /// <summary>
        /// 是否存在重复的面试资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> SelectEIByResumeId(int id)
        {
            EI ei = await eIDao.SelectEIByResumeId(id);
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return Content(JsonConvert.SerializeObject(ei, Formatting.Indented, timeFormat));
        }
        /// <summary>
        /// 面试筛选展示
        /// </summary>
        /// <returns></returns>
        public ActionResult InterviewScreen()
        {
            return View();
        }
        /// <summary>
        ///  面试筛选展示分页数据
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> EIFenYe2(FenYe<EI> fenYe)
        {
            fenYe = await eIDao.EIFenYe2(fenYe);
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd hh:mm:ss";
            return Content(JsonConvert.SerializeObject(fenYe, Formatting.Indented, timeFormat));
        }
        /// <summary>
        ///  面试筛选展示数据(传值 是否建议录用)
        /// </summary>
        /// <returns></returns>
        public ActionResult HireResume()
        {
            return View();
        }
        /// <summary>
        /// 筛选指定的面试资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> SelectEIById(int id)
        {
            EI ei = await eIDao.SelectEIById(id);
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return Content(JsonConvert.SerializeObject(ei, Formatting.Indented, timeFormat));
        }
        /// <summary>
        /// 面试表数据添加
        /// </summary>
        /// <param name="EI"></param>
        /// <returns></returns>
        public async Task<ActionResult> InsertEI(EI ei)
        {
            int result = await eIDao.AddEI(ei);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 面试表数据添加成功后的面试状态更改（为面试）
        /// </summary>
        /// <param name="EI"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateStatusER(int id)
        {
            int result = await erDao.UpdateStatusER(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 简历一筛选
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateStatusER2(int id)
        {
            int result = await erDao.UpdateStatusER2(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 已面试
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateStatusER7(int id)
        {
            int result = await erDao.UpdateStatusER7(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 是否通过申请
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateStatusER3(int id,ER er)
        {
            int result = await erDao.UpdateStatusER3(id, er);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 是否通过审批
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateStatusER4(int id, ER er)
        {
            int result = await erDao.UpdateStatusER4(id, er);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 筛选后状态的更改
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        /// 
        public async Task<ActionResult> UpdateStatusEI(EI ei)
        {
            int result = await eIDao.UpdateStatusEI(ei);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除简历
        /// </summary>
        /// <param name="ei"></param>
        /// <returns></returns>
        public async Task<ActionResult> DeleteEI(int id)
        {
            int result = await erDao.ERDeleteById(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult OpenWordDocument(string filePath)
        {
            try
            {
                System.Diagnostics.Process.Start("D:\\S3course\\HRDB\\HRTD\\HRZS\\Uploader/" + filePath);
                return RedirectToAction("InterviewResltRegisterShow"); // 重定向到您的首页或其他适当的页面
            }
            catch (Exception ex)
            {
                // 处理错误，可能是文件不存在或无法打开
                ViewBag.ErrorMessage = "无法打开文件：" + ex.Message;
                return View("Error"); // 或者显示一个错误页面
            }
        }
    }
}