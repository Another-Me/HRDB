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
    public class RolesJurisdictionDao
    {
        Program program = new Program();
        public async Task<List<int>> selectRolesJurisdiction(int id)
        {
            using (SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = $"SELECT [JuriID] FROM [dbo].[RolesJurisdiction] where RolesID={id}";
                var resu = await conn.QueryAsync<int>(sql);
                return resu.ToList();
            }
        }

        //删除指定的角色权限
        public async Task<int> deleteRolesJurisdiction(int id)
        {
            using (SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = $"delete from[dbo].[RolesJurisdiction] where [RolesID]='{id}'";
                return await conn.ExecuteAsync(sql);
            }
        }

        //增加指定的角色权限
        public async Task<int> insertRolesJurisdiction(RolesJurisdiction rj)
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $"insert [dbo].[RolesJurisdiction](RolesID, JuriID)values('{rj.RolesID}','{rj.JuriID}')";
                return await conn.ExecuteAsync(sql);
            }
        }
    }
}
