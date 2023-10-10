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
    public class PermissionsController : Controller
    {
        // GET: Permissions
        RolesDao rolesDao=new RolesDao();
        UsersDao usersDao=new UsersDao();
        UserRolesDao userRolesDao=new UserRolesDao();
        JurisdictionDao jurisdictionDao=new JurisdictionDao();
        RolesJurisdictionDao roles=new RolesJurisdictionDao();

        //用户管理页面
        public ActionResult Usermanagement()
        {
            return View();
        }

        //查询用户数据
        public async Task<ActionResult> RolesUserSelect()
        {
            IEnumerable<RolesUser> select =await rolesDao.RolesUserSelect();
            return Json(select,JsonRequestBehavior.AllowGet);
        }

        //用户数据删除
        public async Task<ActionResult> DeleteUser(int id)
        {
            int count=await usersDao.DeleteUser(id);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //用户角色关系删除
        public async Task<ActionResult> UserRolesDelete(int id)
        {
            int count=await userRolesDao.UserRolesDelete(id);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //用户管理增加页面
        public ActionResult UsermanagementInsert()
        {
            return View();
        }

        //查询角色
        public async Task<ActionResult> RolesSelect()
        {
            IEnumerable<Roles> list= await rolesDao.RolesSelect();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //用户角色关系增加
        public async Task<ActionResult> UserRolesInsert(UserRoles ur)
        {
            int count=await userRolesDao.UserRolesInsert(ur);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //用户增加
        public async Task<ActionResult> UserInsert(Users us)
        {
            int count = await usersDao.UserInsert(us);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //查询用户最新的自增id
        public async Task<ActionResult> UserUidselect()
        {
            int count=await usersDao.UserUidSelect();
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //用户管理修改页面
        public ActionResult UsermanagementUpdate()
        {
            return View();
        }

        //用户角色查询
        public async Task<ActionResult> RolesUserDyid(int id)
        {
            RolesUser ru=await rolesDao.RolesUserDyid(id);
            return Json(ru, JsonRequestBehavior.AllowGet);
        }

        //用户修改
        public async Task<ActionResult> UserUpdate(Users us)
        {
            int ru = await usersDao.UserUpdate(us);
            return Json(ru, JsonRequestBehavior.AllowGet);
        }

        //用户角色修改
        public async Task<ActionResult> RolesUpdate(UserRoles ur)
        {
            int ru = await userRolesDao.RolesUpdate(ur);
            return Json(ru, JsonRequestBehavior.AllowGet);
        }

        //权限管理
        public ActionResult Role()
        {
            return View();
        }

        //权限增加页面
        public ActionResult RoleInsert()
        {
            return View();
        }

        //权限增加
        public async Task<ActionResult> RolesInsert(Roles rs)
        {
            int count=await rolesDao.RolesInsert(rs);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //权限删除
        public async Task<ActionResult> RolesDelete(int id)
        {
            int count= await rolesDao.RolesDelete(id);
            return Json(count,JsonRequestBehavior.AllowGet);
        }

        //权限修改查询
        public async Task<ActionResult> JurisdictionList()
        {
            List<Jurisdiction> list = jurisdictionDao.JurisdictionList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //查询角色权限id
        public async Task<ActionResult> selectRolesJurisdiction(int id)
        {
            List<int> list=await roles.selectRolesJurisdiction(id);
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        //删除指定的角色权限
        public async Task<ActionResult> deleteRolesJurisdiction(int id)
        {
            int count = await roles.deleteRolesJurisdiction(id);
            return Json(count, JsonRequestBehavior.AllowGet);
        }

        //增加指定的角色权限
        public async Task<ActionResult> insertRolesJurisdiction(RolesJurisdiction rj)
        {
            int count=await roles.insertRolesJurisdiction(rj);
            return Json(count, JsonRequestBehavior.AllowGet);
        }
    }
}