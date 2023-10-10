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
    public class SGDDao
    {
        Program program = new Program();
        //添加
        public async Task<int> SgdInpsert(SGD sgd)
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $"insert [dbo].[SGD](SalaryGrantId, HumanId, HumanName, BounsSum, SaleSum, DeductSum, SalaryStandardSum, SalaryPaidSum)values" +
                    $"('{sgd.SalaryGrantId}','{sgd.HumanId}','{sgd.HumanName}','{sgd.BounsSum}','{sgd.SaleSum}','{sgd.DeductSum}','{sgd.SalaryStandardSum}','{sgd.SalaryPaidSum}')";
                return await conn.ExecuteAsync(sql);
            }
        }

        //薪酬标准修改查询
        public async Task<IEnumerable<SGD>> SgdWhereSelecct(int id)
        {
            using (SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = $"SELECT * FROM [dbo].[SGD]WHERE [SalaryGrantId]='{id}'";
                return await conn.QueryAsync<SGD>(sql);
            }
        }

        //薪酬标准修改(sgd)
        public async Task<int> SgdUpdate(SGD gd)
        {
            using (SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = $"update [dbo].[SGD] set  BounsSum='{gd.BounsSum}', SaleSum='{gd.SaleSum}', DeductSum='{gd.DeductSum}', SalaryPaidSum='{gd.SalaryPaidSum}' where [GrdId]='{gd.GrdId}'";
                return await conn.ExecuteAsync(sql);
            }
        }

        //薪酬发放详情(sgd)
        public async Task<IEnumerable<SGD>> SelectSgdDyid(string id)
        {
            using (SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = $"select * from [dbo].[SGD] where [SalaryGrantId]='{id}'";
                return await conn.QueryAsync<SGD>(sql);
            }
        }
    }
}
