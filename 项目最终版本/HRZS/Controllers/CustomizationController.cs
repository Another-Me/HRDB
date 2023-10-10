
using HRModel;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
﻿using HRDao;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;



//客户化设置板块控制器

namespace HRZS.Controllers
{
    public class CustomizationController : Controller
    {
        CMDao CmDao = new CMDao();
        CMKDao CmkDao = new CMKDao();
        CPCDao CpcDao = new CPCDao();
        // GET: Customization
        CFFKDao cFFKDao = new CFFKDao();
        CFSKDao cFSKDao = new CFSKDao();
        CFTKDao cFTKDao = new CFTKDao();

        SDDDao sDDDao = new SDDDao();

        TCmDAO cmDAO = new TCmDAO();
        SsdDAO sdDAO = new SsdDAO();

        //跳转一级机构页面
        public ActionResult Level()
        {
            return View();
        }

        //职位设置View展示
        public ActionResult PositionSettingShow()
        {
            return View();
        }
        //职位添加View展示
        public ActionResult PositionInsertShow()
        {
            return View();
        }
        //职位设置查询分页数据（CM表）
        public async Task<ActionResult> ShowData(FenYe<CM> fenYe)
        {
            fenYe = await CmDao.SelectCMAll(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 职位分类下拉框的获取
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> CMKXiaLa()
        {
            IEnumerable<CMK> cmk = await CmkDao.SelecteCMK();
            return Json(cmk, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 职位设置添加数据
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public async Task<ActionResult> CMInsert(CM cm)
        {
           
            int zhi = await CmDao.CMInsertAsync(cm);
            return Json(zhi, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 职位设置删除数据
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
       public async Task<ActionResult> CmmDelete(int id)
        {
            int result = await CmDao.CMDeleteAsync(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        /// 公共属性View展示
        /// </summary>
        /// <returns></returns>
        public ActionResult GongGongShow()
        {
            return View();
        }

        /// <summary>
        /// 公共属性查询分页数据（CPC表）
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        public async Task<ActionResult> GongGongCha(FenYe<CPC> fenYe)
        {
            fenYe = await CpcDao.GongGongFenYe(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        /// 公共属性添加窗口展示
        /// </summary>
        /// <returns></returns>
        public  ActionResult CPCInsertShow()
        {
            return View();
        }

        /// <summary>
        /// 公共属性添加
        /// </summary>
        /// <param name="cpc"></param>
        /// <returns></returns>
        public async Task<ActionResult> InsertCPC(CPC cpc)
        {
            int result = await CpcDao.CPCInsertAsync(cpc);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
  
        /// <summary>
        /// 公共属性删除
        /// </summary>
        /// <param name="cpc"></param>
        /// <returns></returns>
        public async Task<ActionResult> CPCDelete(int id)
        {
            int result = await CpcDao.CPCDeleteAsync(id);
            if (result > 0)
            {
                return Content("<script>alert('删除成功');window.location.href='/Customization/GongGongShow'</script>");
               
            }
            else
            {
                return Content("<script>alert('删除失败');window.location.href='/Customization/GongGongShow'</script>");
            }
        }


        //一级机构分页
        public async Task<ActionResult> CFFKFenye(FenYe<CFFK> fenYe)
        {
            fenYe=await cFFKDao.CFFkSelectAsyns(fenYe);
            return Json(fenYe,JsonRequestBehavior.AllowGet);
        }

        //一级机构增加页面
        public ActionResult Leve1Insert()
        {
            return View();
        }

        //一级机构增加页面
        public async Task<ActionResult> LeveInsert(CFFK cFFK)
        {
            int count = await cFFKDao.CFFKInsert(cFFK);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //一级机构删除数据
        public async Task<ActionResult>CFFKDelete(int id)
        {
            int count=await cFFKDao.CFFKDelete(id);
            return Json(count,JsonRequestBehavior.AllowGet);
        }

        //一级机构修改页面
        public ActionResult Leve1Update()
        {
            return View();
        }

        //一级机构查询指定数据
        public async Task<ActionResult> Leve1DyidSelect(int id)
        {
            CFFK ck = await cFFKDao.CFFKDyidSelect(id);
            return Json(ck, JsonRequestBehavior.AllowGet);
        }

        //一级机构修改指定数据
        public async Task<ActionResult> CFFKUpdate(CFFK ck)
        {
            int coun = await cFFKDao.CFFKUpdate(ck);
            return Json(coun, JsonRequestBehavior.AllowGet); 
        }

        //跳转二级标签页面
        public ActionResult Level2()
        {
            return View();
        }

        //二级标签分页
        public async Task<ActionResult> CFSKFenye(FenYe<CFSK> fenYe)
        {
            fenYe = await cFSKDao.CFSkSelectAsyns(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }

        //二级机构删除
        public async Task<ActionResult> CFSKDelete(int id)
        {
            int count = await cFSKDao.CFSkDeleteAsyns(id);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //跳转二级机构增加页面
        public ActionResult Level2Insert()
        {
            return View();
        }

        //二级机构中查询一级机构编号与名称
        public async Task<ActionResult> CFFKselect()
        {
            IEnumerable<CFFK> list =await cFFKDao.CFFKSelect();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //增加二级机构
        public async Task<ActionResult> CFSKInsert(CFSK cs)
        {
            int count = await cFSKDao.CFSKInsertAsyns(cs);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //跳转二级机构修改页面
        public ActionResult Level2Update()
        {
            return View();
        }

        //查询指定的二级机构数据
        public async Task<ActionResult> CFSKDyidSelect(int id)
        {
            CFSK cs = await cFSKDao.CFSKDyidSelect(id);
            return Json(cs, JsonRequestBehavior.AllowGet);
        }

        //修改指定的二级机构数据
        public async Task<ActionResult> CFSKUpdate(CFSK cs)
        {
            int count=await cFSKDao.CFSKUpdate(cs);
            return Json(count,JsonRequestBehavior.AllowGet);
        }

        //跳转三级机构页面
        public ActionResult Level3()
        {
            return View();
        }

        //三级分页
        public async Task<ActionResult> CFTKFenye(FenYe<CFTK> fenYe)
        {
            fenYe = await cFTKDao.CFTkSelectAsyns(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);
        }

        //删除指定的三级数据
        public async Task<ActionResult> CFTKDelete(int id)
        {
            int count = await cFTKDao.CFTkDeleteAsyns(id);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //跳转三级增加页面
        public ActionResult Level3Insert()
        {
            return View();
        }

        //并联数据
        public async Task<ActionResult> CFTKLJInsetAsync()
        {
            List<CFSK> cf=cFFKDao.CFTKLJInsetAsync();
            return Json(cf, JsonRequestBehavior.AllowGet);
        }

        //三级增加数据
        public async Task<ActionResult> CFTKInsert(CFTK cf)
        {
            int count = await cFTKDao.CFTKInsert(cf);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //跳转三级修改页面
        public ActionResult Level3Update()
        {
            return View();
        }

        //查询指定的三级机构数据
        public async Task<ActionResult> CFTKDyidSelect(int id)
        {
            CFTK cs = await cFTKDao.CFTKDyidSelect(id);
            return Json(cs, JsonRequestBehavior.AllowGet);
        }

        //修改指定的三级机构数据
        public async Task<ActionResult> CFTKUpdate(CFTK cs)
        {
            int count = await cFTKDao.CFTKUpdate(cs);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cmkshi()
        {
            return View();
        }
        //CMK分页查询
        public async Task<ActionResult> CmkshiData(FenYe<CMK> fenYe)
        {
            fenYe = await CmkDao.CmkSelectAsync(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);

        }
        //CMK删除
        public async Task<ActionResult> Deletezhu(int id)
        {
            int result = await CmkDao.CmkDeleteAsync(id);
            if (result > 0)
            {
                return RedirectToAction("Cmkshi");
            }
            else
            {
                return RedirectToAction("Cmkshi");
            }
        }

        public ActionResult Cmzhu()
        {
            return View();
        }
        //CM分页查询
        public async Task<ActionResult> CmshiData(FenYe<CM> fenYe)
        {
            fenYe = await cmDAO.CmSelectAsync(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);

        }
        //CM分页删除
        public async Task<ActionResult> CmDelete(int id)
        {
            int sn = await cmDAO.CmDeleteAsync(id);
            if (sn > 0)
            {
                return RedirectToAction("Cmzhu");
            }
            else
            {
                return View();
            }
        }
        //CM添加
        public async Task<ActionResult> InsertCM()
        {
            return View();
        }
        public async Task<ActionResult> InsertFen(CM cm)
        {
            int result = await cmDAO.CmInsertAsync(cm);
            if (result > 0)
            {

                return RedirectToAction("Cmzhu");
            }
            else
            {
                return View(cm);
            }
        }

        //SDD分页查询
        public ActionResult SSDzhu()
        {
            return View();
        }
        //SSD查询所有
        public async Task<ActionResult> SSDselect()
        {
            IEnumerable<SSD> ssd =await sdDAO.SelectSSDAsync();
            return Json(ssd, JsonRequestBehavior.AllowGet);

        }
        //SDD分页查询
        public async Task<ActionResult> SSDzhuData(FenYe<SDD> fenYe)
        {
            fenYe = await sDDDao.SDDSelectAsync(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);

        }
        //SDD添加
        public async Task<ActionResult> InsertSSD()
        {
            return View();
        }
        public async Task<ActionResult> InsertzhuSSD(SDD sd)
        {
            int reslt = await sDDDao.InsertSDDAsync(sd);
            if (reslt > 0)
            {
                return RedirectToAction("SSDzhu");
            }
            else
            {
                return View(sd);
            }
        }
        //SDD删除
        public async Task<ActionResult> SSdDelect(int id)
        {
            int mm = await sDDDao.SDDDeleteAsync(id);
            return Json(mm, JsonRequestBehavior.AllowGet);
        }

    }
}