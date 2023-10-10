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
    public class RolesDao
    {
        Program program = new Program();

        public async Task<IEnumerable<RolesUser>> RolesUserSelect()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = "select * from [dbo].[UserS]";
                return await connection.QueryAsync<RolesUser>(sql);
            }
        }

        //角色查询
        public async Task<IEnumerable<Roles>> RolesSelect()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = "select * from [dbo].[Roles]";
                return await connection.QueryAsync<Roles>(sql);
            }
        }

        //角色用户查询
        public async Task<RolesUser> RolesUserDyid(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"SELECT  u.UId, u.UName, u.UTrueName, u.UPassWord, r.RolesID, r.RolesName, r.RolesInstruction, r.RolesIf FROM dbo.UserRoles AS ur INNER JOIN dbo.[User] AS u ON u.UId = ur.UserID INNER JOIN dbo.Roles AS r ON ur.RolesID = r.RolesID where u.UId={id}";
                return await connection.QueryFirstAsync<RolesUser>(sql);
            }
        }

        //角色增加
        public async Task<int> RolesInsert(Roles rs)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"insert [dbo].[Roles](RolesName, RolesInstruction, RolesIf)values('{rs.RolesName}','{rs.RolesInstruction}','{rs.RolesIf}')";
                return await connection.ExecuteAsync(sql);
            }
        }

        //角色删除
        public async Task<int> RolesDelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"delete from [dbo].[Roles] where [RolesID]='{id}'";
                return await connection.ExecuteAsync(sql);
            }
        }
    }
}
