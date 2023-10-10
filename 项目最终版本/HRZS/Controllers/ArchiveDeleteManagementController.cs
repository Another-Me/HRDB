using HRDao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRZS.Controllers
{
    /// <summary>
    /// 档案删除管理
    /// </summary>
    public class ArchiveDeleteManagementController : Controller
    {
        HFDao hfDao = new HFDao ();

        // GET: ArchiveDeleteManagement

        /// <summary>
        /// 查询出可做操作的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchiveDeleteList()
        {
            return View();
        }
        /// <summary>
        /// 查询出可做操作的删除数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchiveDeleteListShow()
        {
            return View();
        }
        /// <summary>
        /// 查询出可做恢复的数据
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchiveRecoverListShow()
        {
            return View();
        }/// <summary>
         /// 进行恢复的数据
         /// </summary>
         /// <returns></returns>
        public ActionResult ArchiveRecoverListShow2()
        {
            return View();
        }
        /// <summary>
        /// 查询出可做删除的数据（永久删除）
        /// </summary>
        /// <returns></returns>
        public ActionResult ArchivePerpetualDeleteListShow()
        {
            return View();
        }
        /// <summary>
        /// 删除档案（修改档案状态）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateStatusHF(int id)
        {
            int result = await hfDao.UpdateStatusHF(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 恢复档案（修改档案状态）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> UpdateStatusHF2(int id)
        {
            int result = await hfDao.UpdateStatusHF2(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 永久档案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> DleteHF(int id)
        {
            int result = await hfDao.DeleteHF(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}