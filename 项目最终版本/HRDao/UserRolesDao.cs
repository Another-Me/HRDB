using Dapper;
using HRModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDao
{
    public class UserRolesDao
    {
        Program program = new Program();
        //用户角色表删除
        public async Task<int> UserRolesDelete(int id)
        {
            using (SqlConnection connection =new SqlConnection(program.sss))
            {
                string sql = $"delete  from [dbo].[UserRoles]where [UserID]='{id}'";
                return await connection.ExecuteAsync(sql);
            }
        }

        //用户角色增加
        public async Task<int> UserRolesInsert(UserRoles ur)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"insert [dbo].[UserRoles]( UserID, RolesID)values('{ur.UserID}','{ur.RolesID}')";
                return await connection.ExecuteAsync(sql);
            }
        }

        //用户角色修改
        public async Task<int> RolesUpdate(UserRoles ur)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"update [dbo].[UserRoles] set UserID='{ur.UserID}', RolesID='{ur.RolesID}' where [UserID]='{ur.UserID}'";
                return await connection.ExecuteAsync(sql);
            }
        }
    }
}
