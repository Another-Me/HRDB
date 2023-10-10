using HRDao;
using HRModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRZS.Controllers
{
    //简历管理控制器
    public class ResumeManagementController : Controller
    {
        // GET: Default

        CPCDao cPCDao = new CPCDao();
        ERDao erDao = new ERDao();

        /// <summary>
        /// 简历登记展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ResumeRegisterShow()
        {
            return View();
        }
        /// <summary>
        /// 简历登记展示
        /// </summary>
        /// <returns></returns>
        public ActionResult ResumeRegisterShow1()
        {
            return View();
        }
        /// <summary>
        /// 简历条件筛选展示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ResumeScreenShow()
        {
            return View();
        }
        /// <summary>
        /// 有效简历条件筛选展示页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidResumeScreenShow()
        {
            return View();
        }
        /// <summary>
        /// 简历条件筛选后展示编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ResumeShow()
        {
            return View();
        }
        /// <summary>
        /// 简历条件筛选
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        public async Task<ActionResult> JianLiSelect(FenYe<ER> fenYe)
        {
            fenYe = await erDao.JianLiSelect(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 有效简历条件筛选
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        public async Task<ActionResult> YXJianLiSelect(FenYe<ER> fenYe)
        {
            fenYe = await erDao.JianLiSelect(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 简历数据更改数据展示（传值）
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ERSelecteById(int id)
        {
            ER eR = await erDao.ERSelecteById(id);
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd";
            return Content(JsonConvert.SerializeObject(eR, Formatting.Indented, timeFormat));
        }
        /// <summary>
        /// 简历数据更改数据（是否推荐）
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> RecommendER(ER eR)
        {
            int result = await erDao.RecommendER(eR);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询国籍
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GuoJiSelecte()
        {
            IEnumerable<CPC> list =await cPCDao.GuoJiSelecte();
            return Json(list, JsonRequestBehavior.AllowGet);
           
        }
        /// <summary>
        /// 查询民族
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> MinZuSelecte()
        {
            IEnumerable<CPC> list = await cPCDao.MinZuSelecte();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询宗教信仰
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZongJiaoSelecte()
        {
            IEnumerable<CPC> list = await cPCDao.ZongJiaoSelecte();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询政治面貌
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZZMianMaoSelecte()
        {
            IEnumerable<CPC> list = await cPCDao.ZZMianMaoSelecte();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询教育年限
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> JYNianXianSelecte()
        {
            IEnumerable<CPC> list = await cPCDao.JYNianXianSelecte();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询教育年限
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZhuanYeSelecte()
        {
            IEnumerable<CPC> list = await cPCDao.ZhuanYeSelecte();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询学历
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> XueLiSelecte()
        {
            IEnumerable<CPC> list = await cPCDao.XueLiSelecte();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询特长
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> TeChangSelecte()
        {
            IEnumerable<CPC> list = await cPCDao.TeChangSelecte();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询爱好
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> AiHaoSelecte()
        {
            IEnumerable<CPC> list = await cPCDao.AiHaoSelecte();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 查询职称
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZhiChengSelecte()
        {
            IEnumerable<CPC> list = await cPCDao.ZhiChengSelecte();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public ActionResult WSC()
        {
            //获取上传文件控件对象
            var file = HttpContext.Request.Files["file"];
            //相对路径
            string path = "../Uploader/" + file.FileName;
            string jpath = Server.MapPath(path);
            file.SaveAs(jpath);
            return Content(path);
        } 

        //public ActionResult OpenWordDocument(string filePath)
        //{
        //    try
        //    {
        //        System.Diagnostics.Process.Start("D:\\S3course\\HRDB\\HRTD\\HRZS\\Uploader/" + filePath);
        //        return RedirectToAction("ResumeRegisterShow"); // 重定向到您的首页或其他适当的页面
        //    }
        //    catch (Exception ex)
        //    {
        //        // 处理错误，可能是文件不存在或无法打开
        //        ViewBag.ErrorMessage = "无法打开文件：" + ex.Message;
        //        return View("Error"); // 或者显示一个错误页面
        //    }
        //}
        /// <summary>
        /// 简历登记数据添加
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> AddER(ER er)
        {
           /* if (!ModelState.IsValid)
            {
                return View(er);
            }*/
            int result = await erDao.AddER(er);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}