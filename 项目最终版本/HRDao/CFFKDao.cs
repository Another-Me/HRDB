using Dapper;
using HRModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HRDao
{
    public class CFFKDao
    {
        Program program = new Program();

        //分页查询
        public async Task<FenYe<CFFK>> CFFkSelectAsyns(FenYe<CFFK> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamic = new DynamicParameters();
                dynamic.Add("@pageSize", fenYe.PageSize);
                dynamic.Add("@currentPage", fenYe.CurrentPage);
                dynamic.Add("@tableName", "CFFK");
                dynamic.Add("@keyName", "FfkId");
                dynamic.Add("@count", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_FenYe] @pageSize, @currentPage, @tableName, @keyName, @count out";
                //string sql = "select * from Test";
                fenYe.List = await connection.QueryAsync<CFFK>(sql, dynamic);
                fenYe.Rows = dynamic.Get<int>("count");
                return fenYe;
                //await connection.QueryAsync<Test>(sql);
            }
        }

        //增加一级机构
        public async Task<int> CFFKInsert(CFFK ck)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"Insert into [dbo].[CFFK] (FirstKindId, FirstKindName, FirstKindSalaryId, FirstKindSaleId) values ({ck.FirstKindId},'{ck.FirstKindName}',{ck.FirstKindSalaryId},{ck.FirstKindSaleId})";
                return await connection.ExecuteAsync(sql);
            }
        }

        //删除指定的一级机构
        public async Task<int> CFFKDelete(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"delete from CFFK where FfkId={id}";
                return await connection.ExecuteAsync(sql);
            }
        }

        //查询指定的一级机构
        public async Task<CFFK> CFFKDyidSelect(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from CFFK where FfkId={id}";
                return await connection.QueryFirstAsync<CFFK>(sql);
            }
        }

        //修改一级机构指定数据
        public async Task<int> CFFKUpdate(CFFK ck)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"update [dbo].[CFFK] set  FirstKindName='{ck.FirstKindName}', FirstKindSalaryId={ck.FirstKindSalaryId}, FirstKindSaleId={ck.FirstKindSaleId} where FfkId={ck.FfkId}";
                return await connection.ExecuteAsync(sql);
            }
        }

        //查询一级机构编号和名称
        public async Task<IEnumerable<CFFK>> CFFKSelect()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from CFFK";
                return await connection.QueryAsync<CFFK>(sql);
            }
        }

        //查询并联数据
        public List<CFSK> CFTKLJInsetAsync()
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $"select * from CFFK";
                List<CFSK> cFTKLJs = new List<CFSK>();
                cFTKLJs = conn.Query<CFSK>(sql).ToList();
                foreach (CFSK cFTKLJ in cFTKLJs)
                {
                    string sqll = $"select*from JLCX WHERE b='{cFTKLJ.FirstKindName}'";
                    cFTKLJ.childern = (List<CFSK>)conn.Query<CFSK>(sqll);
                }
                return cFTKLJs;
            }
        }
    }
}
