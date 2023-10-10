using Dapper;
using HRModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HRDao
{
    public class CMKDao
    {
        //数据库连接对象
        Program program = new Program();

        /// <summary>
        /// 查询所有职位分类信息
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CMK>> SelecteCMK()
        {
            using (SqlConnection con = new SqlConnection(program.sss))
            {
                string sql = $"select * from dbo.CMK";
                return await con.QueryAsync<CMK>(sql);
            }
        }
        public async Task<FenYe<CMK>> CmkSelectAsync(FenYe<CMK> fenYe)
        {

            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@tableName", "CMK");
                dynamicParameters.Add("@keyName", "MfkId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_FenYe] @pageSize, @currentPage, @tableName, @keyName, @rows out";
                fenYe.List = await connection.QueryAsync<CMK>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        //删除
        public async Task<int> CmkDeleteAsync(int id)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $"delete cmk where MfkId={id}";
                return await sqlcon.ExecuteAsync(sql);
            }
        }
    }
}
