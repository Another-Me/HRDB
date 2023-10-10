using Dapper;
using HRModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDao
{
    public class TCmDAO
    {
        Program program = new Program();//调用连接数据库
        //分页
        public async Task<FenYe<CM>> CmSelectAsync(FenYe<CM> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@tableName", "CM");
                dynamicParameters.Add("@keyName", "MakId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_FenYe] @pageSize, @currentPage, @tableName, @keyName, @rows out";
                fenYe.List = await connection.QueryAsync<CM>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        //删除
        public async Task<int> CmDeleteAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $" delete CM where MakId={id}";
                return await conn.ExecuteAsync(sql);
            }
        }
        public async Task<int> CmInsertAsync(CM cm)
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $"insert into cm(MajorKindId,MajorKindName)values('{cm.MajorKindId}','{cm.MajorKindName}')";
                return await conn.ExecuteAsync(sql);
            }
        }
    }
}
