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
    public class CFSKDao
    {
        Program program = new Program();

        //分页查询
        public async Task<FenYe<CFSK>> CFSkSelectAsyns(FenYe<CFSK> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamic = new DynamicParameters();
                dynamic.Add("@pageSize", fenYe.PageSize);
                dynamic.Add("@currentPage", fenYe.CurrentPage);
                dynamic.Add("@tableName", "CFSK");
                dynamic.Add("@keyName", "FskId");
                dynamic.Add("@count", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_FenYe] @pageSize, @currentPage, @tableName, @keyName, @count out";
                fenYe.List = await connection.QueryAsync<CFSK>(sql, dynamic);
                fenYe.Rows = dynamic.Get<int>("count");
                return fenYe;
            }
        }

        //二级机构删除
        public async Task<int> CFSkDeleteAsyns(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"delete from CFSK where FskId={id}";
                return await connection.ExecuteAsync(sql);
            }
        }

        //二级机构增加
        public async Task<int> CFSKInsertAsyns(CFSK ck)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"Insert into [dbo].[CFSK] (FirstKindId, FirstKindName, SecondKindId, SecondKindName, SecondSalaryId, SecondSaleId)values({ck.FirstKindId},'{ck.FirstKindName}',{ck.SecondKindId},'{ck.SecondKindName}',{ck.SecondSalaryId},{ck.SecondSaleId})";
                return await connection.ExecuteAsync(sql);
            }
        }

        //查询指定的二级机构数据
        public async Task<CFSK> CFSKDyidSelect(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from [dbo].[CFSK] where [FskId]={id}";
                return await connection.QueryFirstAsync<CFSK>(sql);
            }
        }

        //修改指定的二级机构数据
        public async Task<int> CFSKUpdate(CFSK cs)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"update [dbo].[CFSK] set FirstKindId={cs.FirstKindId}, FirstKindName='{cs.FirstKindName}', SecondKindId={cs.SecondKindId}, SecondKindName='{cs.SecondKindName}', SecondSalaryId={cs.SecondSalaryId}, SecondSaleId={cs.SecondSaleId}  where FskId={cs.FskId}";
                return await connection.ExecuteAsync(sql);
            }
        }
    }
}
