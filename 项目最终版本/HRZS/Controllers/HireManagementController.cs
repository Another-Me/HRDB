using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRDao;
using HRModel;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace HRZS.Controllers
{
    public class HireManagementController : Controller
    {
        // GET: HireManagement

        EMRDao eMRDao = new EMRDao ();

        /// <summary>
        /// 录用申请展示列表
        /// </summary>
        /// <returns></returns>
        public ActionResult HireApplyFor()
        {
            return View();
        }
        /// <summary>
        /// 面试申请数据填写
        /// </summary>
        /// <returns></returns>
        public ActionResult ApplyForShow()
        {
            return View();
        }
        /// <summary>
        /// 录用审核展示列表
        /// </summary>
        /// <returns></returns>
        public ActionResult HireAudit()
        {
            return View();
        }
        /// <summary>
        /// 录用审核数据填写
        /// </summary>
        /// <returns></returns>
        public ActionResult HireAuditShow()
        {
            return View();
        }
        /// <summary>
        /// 录用结果查询
        /// </summary>
        /// <returns></returns>
        public ActionResult HireShow()
        {
            
            return View();
        }
        /// <summary>
        /// 录用结果查询详细信息
        /// </summary>
        /// <returns></returns>
        public ActionResult HireMessageShow()
        {
            return View();
        }
        //根据邮箱发送短信
        public ActionResult Marn(string uEmail)
        {
            // 配置SMTP客户端
            SmtpClient smtpClient = new SmtpClient("smtp.qq.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("674736750@qq.com", "jramdvfiiqhobbcj"), // 使用QQ邮箱账号和授权码
                EnableSsl = true, // 使用SSL加密连接
            };

            // 创建邮件消息
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("674736750@qq.com"), // 发件人地址
                Subject = "审批结果 ",
                Body = "恭喜你被我公司成功录用",
            };

            // 添加收件人
            mailMessage.To.Add(uEmail); // 收件人地址

            try
            {
                // 发送邮件
                smtpClient.Send(mailMessage);
                Console.WriteLine("邮件发送成功！");
            }
            catch (Exception ex)
            {
                Console.WriteLine("邮件发送失败：" + ex.Message);
            }
            return View();
        }
        /// <summary>
        /// 审批结束后将减少一名发布职位的人数
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> RenShu(int id)
        {
            int Result = await eMRDao.Renshu(id);
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
    }
}