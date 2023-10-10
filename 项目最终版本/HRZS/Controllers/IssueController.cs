using HRDao;
using HRModel;
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
    public class IssueController : Controller
    {
        HFcopyDao hfcopyDao=new HFcopyDao();
        SsdDAO sdDAO=new SsdDAO();  
        SGDao sgDao =new SGDao();
        SGDDao sgDDao=new SGDDao();
        // GET: Issue
        //发放登记页面-1
        public ActionResult checkin()
        {
            return View();
        }
        //发放登记页面-2
        public ActionResult checkout()
        {
            return View();
        }

        //查询页面2数据
        public async Task<ActionResult> HFcopySelect(string sql)
        {
            IEnumerable<HFcopy>list=await hfcopyDao.HFcopySelect(sql);
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        //发放登录页面-3
        public ActionResult checkots()
        {
            return View();
        }

        //查询人员金额
        public async Task<ActionResult> HFcopiesSelectCondition(int id,string name)
        {
            IEnumerable<HFcopy> list=await hfcopyDao.HFcopiesSelectCondition(id,name);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //薪酬发放登记查询薪酬详细信息
        public async Task<ActionResult> SSDdetailed(string name)
        {
            IEnumerable<SSD> list = await sdDAO.SSDdetailed(name);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //SG表增加
        public async Task<ActionResult> SgInpsert(SG sg)
        {
            int coiu = await sgDao.SgInpsert(sg);
            return Json(coiu, JsonRequestBehavior.AllowGet);
        }

        //SGD表增加
        public async Task<ActionResult> SgdInpsert(SGD sgd)
        {
            int coiu = await sgDDao.SgdInpsert(sgd);
            return Json(coiu, JsonRequestBehavior.AllowGet);

        }

        //hf查询结构
        public async Task<ActionResult> HFSelectCondition(int id,string name)
        {
            HF hf=await hfcopyDao.HFSelectCondition(id,name);
            return Json(hf, JsonRequestBehavior.AllowGet);
        }

        //薪酬发放登记复核
        public ActionResult Review()
        {
            return View();
        }

        //薪酬发放登记数据
        public async Task<ActionResult> SGSelect()
        {
            IEnumerable<SG> list= await sgDao.SGSelect();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //薪酬发放复核修改页面
        public ActionResult ReviewUpdate()
        {
            return View();
        }

        //薪酬发放复核查询修改SG数据
        public async Task<ActionResult> SgSelectWhere(int id)
        {
            SG list = await sgDao.SgSelectWhere(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //薪酬发放复核查询修改SGD数据
        public async Task<ActionResult> SgdWhereSelecct(int id)
        {
            IEnumerable<SGD> list = await sgDDao.SgdWhereSelecct(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //薪酬发放复核修改(SG)
        public async Task<ActionResult> sgUpdate(SG sg)
        {
            int count = await sgDao.sgUpdate(sg);
            return Json(count,JsonRequestBehavior.AllowGet);
        }

        //薪酬发放复核修改(CGD)
        public async Task<ActionResult> SgdUpdate(SGD sgd)
        {
            int count = await sgDDao.SgdUpdate(sgd);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //薪酬发放查询
        public ActionResult Issueinquiries()
        {
            return View();
        }

        //薪酬发放查询-2
        public ActionResult IssueSelcets()
        {
            return View();
        }

        //分页模糊查询
        public async Task<ActionResult> SGRoleFenye(FenYe<SG> fenYe)
        {
            FenYe<SG> sg = await sgDao.SGRoleFenye(fenYe);
            return Json(sg, JsonRequestBehavior.AllowGet);
        }

        //薪酬发放查询-3
        public ActionResult IssueDelete()
        {
            return View();
        }

        //薪酬发放详情(sgd)
        public async Task<ActionResult> SelectSgdDyid(string id)
        {
           IEnumerable<SGD> list=await sgDDao.SelectSgdDyid(id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}