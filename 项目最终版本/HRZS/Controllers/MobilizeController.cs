using Dapper;
using HRDao;
using HRModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRZS.Controllers
{
    public class MobilizeController : Controller
    {
        Program program = new Program();
        MCDAO mcdao = new MCDAO();
        // GET: MC
        public ActionResult McHomepagez()
        {
            return View();
        }
        //MC查询
        public async Task<ActionResult> MCISelect()
        {
            IEnumerable<MCi> list = await mcdao.MCSelect();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //HFD查询
        public async Task<ActionResult> HFDcSelect()
        {
            IEnumerable<SS> list = await mcdao.SSselct();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //HFD分页查询
        public ActionResult MCSekect()
        {
            return View();
        }
        //HFD分页查询
        public async Task<ActionResult> MCSelectAsyns(FenYe<HF> fen)
        {
            fen = await mcdao.MCSelectAsync(fen);
            return Json(fen, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> MCTiaoSelect(MCi mc)
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $@"Select * from MC ";
                List<MCi> list = conn.Query<MCi>(sql).ToList();
                if (mc.FirstKindName != "" || mc.FirstKindName != null)
                {
                    list = list.Where(e => e.FirstKindName == mc.FirstKindName).ToList();
                }
                if (mc.SecondKindName != "" || mc.SecondKindName != null)
                {
                    list = list.Where(e => e.SecondKindName == mc.SecondKindName).ToList();
                }
                if (mc.ThirdKindName != "" || mc.ThirdKindName != null)
                {
                    list = list.Where(e => e.ThirdKindName == mc.ThirdKindName).ToList();
                }
                return Json(list);
            }
        }
        public ActionResult MCDDSelect()
        {
            return View();
        }
        //查询id
        public async Task<ActionResult> MCidSelect(string id)
        {
            HF cs = await mcdao.MCInsert(id);
            return Json(cs, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> MCipSelect(string id)
        {
            MCi cs = await mcdao.MCSLess(id);
            return Json(cs, JsonRequestBehavior.AllowGet);
        }
        //修改
        public async Task<ActionResult> MCDDxg(MCi mc)
        {
            int ck = await mcdao.MCUpdate(mc);
            return Json(ck, JsonRequestBehavior.AllowGet);
        }

        public MCDAO GetMcdao()
        {
            return mcdao;
        }

        //三级级联
        public async Task<ActionResult> MCjil()
        {
            List<CFTK> mc = mcdao.SelectLEVELAsync();
            return Json(mc, JsonRequestBehavior.AllowGet);
        }
        //二级级联
        public async Task<ActionResult> CMerjin()
        {
            List<CM> mc = mcdao.CMerji();
            return Json(mc, JsonRequestBehavior.AllowGet);
        }
        //调动登记
        public ActionResult XamineMc()
        {
            return View();
        }
        //MC分页
        public async Task<ActionResult> MCshiData(FenYe<MCi> fenYe)
        {
            fenYe = await mcdao.MCshiAsync(fenYe);
            return Json(fenYe, JsonRequestBehavior.AllowGet);

        }
        //调动审核
        public ActionResult MCShiTG()
        {
            return View();
        }
        //调动审核通过
        public async Task<ActionResult> MCshiTT(HFD mc)
        {
            int dd = await mcdao.MCshenUpdata(mc);
            return Json(dd, JsonRequestBehavior.AllowGet);

        }
        //调动查询
        public ActionResult MCSelectCX()
        {
            return View();
        }
        public async Task<ActionResult> MCISelectCX()
        {
            IEnumerable<MCi> list = await mcdao.MCSelectCX();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        //调动查询列表
        public ActionResult MCliebin()
        {
            return View();
        }
        //调动登记查看
        public ActionResult MCdjick()
        {
            return View();
        }
        
        //mc表增加数据
        public async Task<ActionResult> MCInsert(MCi mc)
        {
            int count=await mcdao.MCInsert(mc);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> MCIUpdate(MCi mc)
        {
            int cont=await mcdao.MCIUpdate(mc);
            return Json(cont, JsonRequestBehavior.AllowGet);
        }
    }
}