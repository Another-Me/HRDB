using Dapper;
using HRModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDao
{
    public class SGDao
    {
        Program program = new Program();
        //添加
        public async Task<int> SgInpsert(SG sg)
        {
            using (SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = $"insert [dbo].[SG](SalaryGrantId, SalaryStandardId, FirstKindId, FirstKindName, SecondKindId, SecondKindName, ThirdKindId, ThirdKindName, HumanAmount, SalaryStandardSum, SalaryPaidSum, Register, RegistTime)values" +
                    $"('{sg.SalaryGrantId}','{sg.SalaryStandardId}','{sg.FirstKindId}','{sg.FirstKindName}','{sg.SecondKindId}','{sg.SecondKindName}','{sg.ThirdKindId}','{sg.ThirdKindName}','{sg.HumanAmount}','{sg.SalaryStandardSum}','{sg.SalaryPaidSum}','{sg.Register}','{sg.RegistTime}')";
                return await conn.ExecuteAsync(sql);
            }
        }

        //查询SG数据
        public async Task<IEnumerable<SG>> SGSelect()
        {
            using (SqlConnection connection=new SqlConnection(program.sss))
            {
                string sql = "select  [SalaryGrantId],[SalaryStandardId],[FirstKindName],[SecondKindName], [ThirdKindName], HumanAmount ,sum([SalaryStandardSum]) as jine from [dbo].[SG] where[CheckStatus] is NULL group by [SalaryGrantId],[FirstKindName],[SecondKindName],[ThirdKindName],HumanAmount,[SalaryStandardId]";
                return await connection.QueryAsync<SG>(sql);
            }
        }

        //薪酬标准发放审核数据查询
        public async Task<SG> SgSelectWhere(int id)
        {
            using(SqlConnection connection =new SqlConnection(program.sss))
            {
                string sql = $"SELECT * FROM [dbo].[SG] WHERE [SalaryStandardId]='{id}'";
                return await connection.QueryFirstAsync<SG>(sql);
            }
        }

        //薪酬标准发放修改(sg)
        public async Task<int> sgUpdate(SG sg)
        {
            using (SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = $"update [dbo].[SG] set SalaryPaidSum='{sg.SalaryPaidSum}', Checker='{sg.Checker}', CheckTime='{sg.CheckTime}', CheckStatus='{sg.CheckStatus}' where [SgrId]='{sg.SgrId}'";
                return await conn.ExecuteAsync(sql);
            }
        }

        //分页模糊查询
        public async Task<FenYe<SG>> SGRoleFenye(FenYe<SG> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynParameters = new DynamicParameters();
                dynParameters.Add("pageSize", fenYe.PageSize);
                dynParameters.Add("currentPage", fenYe.CurrentPage);
                dynParameters.Add("where", fenYe.condition);
                dynParameters.Add("tableName", " [dbo].[SG]");
                dynParameters.Add("KeyName", "[SgrId]");
                dynParameters.Add("count", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynParameters.Add("zongye", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[proc_DyidFenye] @pageSize, @currentPage,@where, @tableName, @keyName, @count out,@zongye out";
                fenYe.List = await connection.QueryAsync<SG>(sql, dynParameters);
                fenYe.Rows = dynParameters.Get<int>("count");
                return fenYe;
            }
        }
    }
}
