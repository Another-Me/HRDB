using Dapper;
using HRModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HRDao
{
    public class HFcopyDao
    {
        Program program = new Program();
        public async Task<IEnumerable<HFcopy>> HFcopySelect(String sql)
        {
            using (SqlConnection connection=new SqlConnection(program.sss))
            {
                string sqlStr = sql;
                return await connection.QueryAsync<HFcopy>(sqlStr);
            }
        }

        public async Task<IEnumerable<HFcopy>> HFcopiesSelectCondition(int id,string name)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = "";
                if (id == 1)
                {
                    sql = $"select ROW_NUMBER() OVER(ORDER BY hf.FirstKindName) as xuhao,[SalarySum],[HumanId],HumanName,SalaryStandardId from[dbo].[HF] where[FirstKindName] IS NOT NULL AND [SecondKindName] IS NULL and [ThirdKindName] IS NULL and[FirstKindName] = '{name}'";
                }
                if (id == 2)
                {
                    sql = $"select ROW_NUMBER() OVER(ORDER BY hf.[SecondKindName]) as xuhao,[SalarySum],[HumanId],HumanName,SalaryStandardId from[dbo].[HF] where[FirstKindName] IS NOT NULL AND [SecondKindName] IS NOT NULL and [ThirdKindName] IS NULL and[SecondKindName] = '{name}'";
                }
                if(id == 3)
                {
                    sql = $"select ROW_NUMBER() OVER(ORDER BY hf.[ThirdKindName]) as xuhao,[SalarySum],[HumanId],HumanName,SalaryStandardId from[dbo].[HF] where[FirstKindName] IS NOT NULL AND [SecondKindName] IS NOT NULL and [ThirdKindName] IS NOT NULL and[ThirdKindName] = '{name}'";
                }
                return await connection.QueryAsync<HFcopy>(sql);
            }
        }

        public async Task<HF> HFSelectCondition(int id, string name)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = "";
                if (id == 1)
                {
                    sql = $"select [FirstKindId],[FirstKindName] from [dbo].[HF] WHERE [FirstKindId] IS NOT NULL AND [SecondKindId] IS NULL and [ThirdKindId] IS NULL and [FirstKindName]='{name}' group by [FirstKindName], [FirstKindId]";
                }
                else if (id == 2)
                {
                    sql = $"select[FirstKindId],[FirstKindName],[SecondKindId],[SecondKindName] from[dbo].[HF] WHERE[FirstKindId] IS NOT NULL AND[SecondKindId] IS NOT NULL and[ThirdKindId] IS NULL and[SecondKindName] = '{name}' group by[FirstKindName], [FirstKindId],[SecondKindId],[SecondKindName]";
                }
                else if (id == 3)
                {
                    sql = $"select[FirstKindId],[FirstKindName],[SecondKindId],[SecondKindName],[ThirdKindId],[ThirdKindName] from[dbo].[HF] WHERE[FirstKindId] IS NOT NULL AND[SecondKindId] IS not NULL and[ThirdKindId] IS not NULL and[ThirdKindName]='{name}' group by[FirstKindId],[FirstKindName],[SecondKindId],[SecondKindName],[ThirdKindId],[ThirdKindName]";
                }
                return await connection.QueryFirstAsync<HF>(sql);
            }
        }
    }
}
