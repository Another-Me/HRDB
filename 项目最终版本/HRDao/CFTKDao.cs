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
    public class CFTKDao
    {
        Program program=new Program();
        //分页查询
        public async Task<FenYe<CFTK>> CFTkSelectAsyns(FenYe<CFTK> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamic = new DynamicParameters();
                dynamic.Add("@pageSize", fenYe.PageSize);
                dynamic.Add("@currentPage", fenYe.CurrentPage);
                dynamic.Add("@tableName", "CFTK");
                dynamic.Add("@keyName", "FtkId");
                dynamic.Add("@count", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_FenYe] @pageSize, @currentPage, @tableName, @keyName, @count out";
                fenYe.List = await connection.QueryAsync<CFTK>(sql, dynamic);
                fenYe.Rows = dynamic.Get<int>("count");
                return fenYe;
            }
        }

        //三级机构删除
        public async Task<int> CFTkDeleteAsyns(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"delete from CFTK where FtkId={id}";
                return await connection.ExecuteAsync(sql);
            }
        }

        //三级机构增加
        public async Task<int> CFTKInsert(CFTK ct)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"insert into [dbo].[CFTK](FirstKindId, FirstKindName, SecondKindId, SecondKindName, ThirdKindId, ThirdKindName, ThirdKindSaleId, ThirdKindIsRetail)" +
                    $"values({ct.FirstKindId},'{ct.FirstKindName}',{ct.SecondKindId},'{ct.SecondKindName}',{ct.ThirdKindId},'{ct.ThirdKindName}',{ct.ThirdKindSaleId},'{ct.ThirdKindIsRetail}')";
                return await connection.ExecuteAsync(sql);
            }
        }

        //查询指定三级数据
        public async Task<CFTK> CFTKDyidSelect(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from CFTK where FtkId={id}";
                return await connection.QueryFirstAsync<CFTK>(sql);
            }
        }

        //三级机构修改
        public async Task<int> CFTKUpdate(CFTK ct)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"update [dbo].[CFTK] set FirstKindId={ct.FirstKindId}, FirstKindName='{ct.FirstKindName}', SecondKindId={ct.SecondKindId}, SecondKindName='{ct.SecondKindName}', ThirdKindId={ct.ThirdKindId}, ThirdKindName='{ct.ThirdKindName}', ThirdKindSaleId={ct.ThirdKindSaleId}, ThirdKindIsRetail='{ct.ThirdKindIsRetail}'  where FtkId={ct.FtkId}";
                return await connection.ExecuteAsync(sql);
            }
        }
        //机构级联
        public List<CFTK> SelectLEVELAsync()
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = "select*from [dbo].[CFFK]";
                List<CFTK> list = new List<CFTK>();

                list = conn.Query<CFTK>(sql).ToList();
                foreach (CFTK item in list)
                {
                    string sql2 = $@"select*from JLCX where b='{item.FirstKindName}'";
                    item.Chlidren = conn.Query<CFTK>(sql2).ToList();
                    foreach (CFTK item2 in item.Chlidren)
                    {
                        string sql3 = $@"select*from V_CFTK where b1='{item2.FirstKindName}'";
                        item2.Chlidren = conn.Query<CFTK>(sql3).ToList();

                    }
                }
                return list;
            }
        }
    }
}
