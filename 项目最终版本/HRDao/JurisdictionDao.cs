using Dapper;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDao
{
    public class JurisdictionDao
    {
        Program program = new Program();

        public List<Jurisdiction> JurisdictionList()
        {
            using (SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = "select * from [dbo].[Jurisdiction] where [pidd]=0";
                List<Jurisdiction> list = new List<Jurisdiction>();
                list= conn.Query<Jurisdiction>(sql).ToList();
                foreach (var item in list)
                {
                    string sql1 = $"select * from [dbo].[Jurisdiction] where [pidd]={item.JuriID}";
                    item.children = conn.Query<Jurisdiction>(sql1).ToList();
                    foreach (var iten1 in item.children)
                    {
                        string sql2 = $"select * from [dbo].[Jurisdiction] where [pidd]={iten1.JuriID}";
                        iten1.children = conn.Query<Jurisdiction>(sql2).ToList();
                    }
                }
                return list;
            }
        }

        public List<Jurisdiction> SelectJurisdiction(int id)
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $"select j.* from [dbo].[User] as u INNER JOIN [dbo].[UserRoles] as ur on u.[UId]=ur.[UserID] INNER JOIN [dbo].[RolesJurisdiction] as rj on ur.RolesID=rj.RolesID RIGHT  JOIN [dbo].[Jurisdiction] as j on rj.JuriID=j.JuriID where ur.UserID={id} and j.pidd=0";
                List<Jurisdiction> list = new List<Jurisdiction>();
                list = conn.Query<Jurisdiction>(sql).ToList();
                foreach (var item in list)
                {
                    string sql1 = $"select j.* from [dbo].[User] as u INNER JOIN [dbo].[UserRoles] as ur on u.[UId]=ur.[UserID] INNER JOIN [dbo].[RolesJurisdiction] as rj on ur.RolesID=rj.RolesID RIGHT  JOIN [dbo].[Jurisdiction] as j on rj.JuriID=j.JuriID where ur.UserID={id} and j.pidd={item.JuriID}";
                    item.children = conn.Query<Jurisdiction>(sql1).ToList();
                    foreach (var iten1 in item.children)
                    {
                        string sql2 = $"select j.* from [dbo].[User] as u INNER JOIN [dbo].[UserRoles] as ur on u.[UId]=ur.[UserID] INNER JOIN [dbo].[RolesJurisdiction] as rj on ur.RolesID=rj.RolesID RIGHT  JOIN [dbo].[Jurisdiction] as j on rj.JuriID=j.JuriID where ur.UserID={id} and j.pidd={iten1.JuriID}";
                        iten1.children = conn.Query<Jurisdiction>(sql2).ToList();
                    }
                }
                return list;
            }
        }
    }
}
