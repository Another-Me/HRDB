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
    public class SDDDao
    {
        Program program = new Program();
        public async Task<FenYe<SDD>> SDDSelectAsync(FenYe<SDD> fenYe)
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@tableName", "SDD");
                dynamicParameters.Add("@keyName", "ItemId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_FenYe] @pageSize, @currentPage, @tableName, @keyName, @rows out";
                fenYe.List = await conn.QueryAsync<SDD>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }

        //删除
        public async Task<int> SDDDeleteAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $" delete SDD where ItemId={id}";
                return await conn.ExecuteAsync(sql);
            }
        }

        //添加
        public async Task<int> InsertSDDAsync(SDD ssd)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"Insert into [dbo].[SDD] ([ItemName])values('{ssd.ItemName}')";
                return await connection.ExecuteAsync(sql);
            }
        }

        //SDD普通查询
        public async Task<IEnumerable<SDD>> SDDselect()
        {
            using (SqlConnection connection=new SqlConnection(program.sss))
            {
                string sql = "select * from SDD";
                return await connection.QueryAsync<SDD>(sql);
            }
        }


        //金额修改
        public async Task<int> SSDSalaryUpdate(int id, int uid)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"update [dbo].[SSD] set Salary='{uid}' where SdtId='{id}'";
                return await connection.ExecuteAsync(sql);
            }

        }

    }
}
