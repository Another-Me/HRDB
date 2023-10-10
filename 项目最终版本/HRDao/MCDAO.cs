using Dapper;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDao
{
    public class MCDAO
    {
        Program program=new Program();
        public async Task<IEnumerable<MCi>> MCSelect()
        {
            using(SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $@"Select * from MC ";
                return await conn.QueryAsync<MCi>(sql);
            }
        }

        //查询ss表的id，名称，金额
        public async Task<IEnumerable<SS>> SSselct()
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $@"select * from [dbo].[SS]";
                return await conn.QueryAsync<SS>(sql);
            }
        }

        public async Task<IEnumerable<HFD>> HFDnSelect()
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $@"Select * from HFD ";
                return await conn.QueryAsync<HFD>(sql);
            }
        }


        public async Task<IEnumerable<MCi>> MCSelectCX()
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $@"Select * from MC ";
                return await conn.QueryAsync<MCi>(sql);
            }
        }
        //HFD分页
        public async Task<FenYe<HF>> MCSelectAsync(FenYe<HF> fenYe)
        {

            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynParameters = new DynamicParameters();
                dynParameters.Add("pageSize", fenYe.PageSize);
                dynParameters.Add("currentPage", fenYe.CurrentPage);
                dynParameters.Add("where", fenYe.Where);
                dynParameters.Add("tableName", " [dbo].[HF]");
                dynParameters.Add("KeyName", "[HufId]");
                dynParameters.Add("count", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynParameters.Add("zongye", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[porc_fy] @pageSize, @currentPage,@where, @tableName, @keyName, @count out,@zongye out";
                fenYe.List = await connection.QueryAsync<HF>(sql, dynParameters);
                fenYe.Rows = dynParameters.Get<int>("count");
                return fenYe;
            }
        }
        public async Task<int> MCUpdate(MCi mc)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $@"insert into[dbo].[MC](HumanId,HumanName,FirstKindName,SecondKindName,ThirdKindName,MajorKindName,MajorName,SalaryStandardName,SalarySum,NewFirstKindId,NewFirstKindName,
                NewSecondKindId,NewSecondKindName,NewThirdKindId,NewThirdkindName,NewMajorKindId,NewMajorKindName,NewMajorId,NewMajorName,NewSalaryStandardId,NewSalaryStandardName,NewSalarySum,
                ChangeReason,CheckStatus,Register,RegistTime)values('{mc.HumanId}','{mc.HumanName}','{mc.FirstKindName}','{mc.SecondKindName}','{mc.ThirdKindName}','{mc.MajorKindName}','{mc.MajorName}','{mc.SalaryStandardName}',
                '{mc.SalarySum}','{mc.NewFirstKindId}','{mc.NewFirstKindName}','{mc.NewSecondKindId}','{mc.NewSecondKindName}','{mc.NewThirdKindId}','{mc.NewThirdkindName}','{mc.NewMajorKindId}','{mc.NewMajorKindName}','{mc.NewMajorId}','{mc.NewMajorName}','{mc.NewSalaryStandardId}','{mc.NewSalaryStandardName}','{mc.NewSalarySum}','{mc.ChangeReason}','1','{mc.Register}','{mc.RegistTime}')";
                return await connection.ExecuteAsync(sql);
            }
        }
        //id查询
        public async Task<HF> MCInsert(string id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from [dbo].[HF] where [HumanId]='{id}'";
                return await connection.QueryFirstAsync<HF>(sql);
            }
        }
        public async Task<MCi> MCSLess(string id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from [dbo].[MC] where [HumanId]='{id}'";
                return await connection.QueryFirstAsync<MCi>(sql);
            }
        }


        //三级级联
        public List<CFTK> SelectLEVELAsync()
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = "select*from [dbo].[CFFK]";
                List<CFTK> list = new List<CFTK>();

                list = conn.Query<CFTK>(sql).ToList();
                foreach (CFTK item in list)
                {
                    string sql2 = $@"select*from JIlian where b='{item.FirstKindName}'";
                    item.children = conn.Query<CFTK>(sql2).ToList();
                    foreach (CFTK item2 in item.children)
                    {
                        string sql3 = $@"select*from V_CFTK where b1='{item2.FirstKindName}'";
                        item2.children = conn.Query<CFTK>(sql3).ToList();

                    }
                }
                return list;
            }
        }
        
        //二级级联
        public List<CM> CMerji()
        {
            using(SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = "select * from CM";
                List<CM> list = new List<CM>();
                list=conn.Query<CM>(sql).ToList();
                foreach(CM c in list)
                {
                    string sql1 = $@"select *from Liangji where b='{c.MajorKindName}'";
                    c.Children= conn.Query<CM>(sql1).ToList();
                } 
                return list;
            }
          
        }
        //MC分页
        public async Task<FenYe<MCi>> MCshiAsync(FenYe<MCi> fenYe)
        {

            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynParameters = new DynamicParameters();
                dynParameters.Add("pageSize", fenYe.PageSize);
                dynParameters.Add("currentPage", fenYe.CurrentPage);
                dynParameters.Add("where", fenYe.Where);
                dynParameters.Add("tableName", " [dbo].[MC]");
                dynParameters.Add("KeyName", "MchId");
                dynParameters.Add("count", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynParameters.Add("zongye", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[porc_fy] @pageSize, @currentPage,@where, @tableName, @keyName, @count out,@zongye out";
                fenYe.List = await connection.QueryAsync<MCi>(sql, dynParameters);
                fenYe.Rows = dynParameters.Get<int>("count");
                return fenYe;
            }
        }
        public async Task<int> MCshenUpdata(HFD hfd)
        {
            using(SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = $@"Update [dbo].[HF] set FirstKindName='{hfd.FirstKindName}',FirstKindId='{hfd.FirstKindId}',SecondKindName='{hfd.SecondKindName}',SecondKindId='{hfd.SecondKindId}',ThirdKindName='{hfd.ThirdKindName}',ThirdKindName='{hfd.ThirdKindName}',
                HumanMajorKindName='{hfd.HumanMajorKindName}',HunmaMajorName='{hfd.HunmaMajorName}',SalaryStandardName='{hfd.SalaryStandardName}',
                SalarySum='{hfd.SalarySum}',Checker='{hfd.Checker}',CheckTime='{hfd.CheckTime}' where HumanId='{hfd.HumanId}'";
                return await conn.ExecuteAsync(sql);
            }
        }
       
       //mc表数据增加
       public async Task<int>  MCInsert(MCi mc)
        {
            using (SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = $"insert [dbo].[MC]([FirstKindId], [FirstKindName], [SecondKindId], [SecondKindName], [ThirdKindId], [ThirdKindName], [MajorKindId], [MajorKindName], [MajorId], [MajorName], [NewFirstKindId], [NewFirstKindName], [NewSecondKindId], [NewSecondKindName], [NewThirdKindId], [NewThirdkindName], [NewMajorKindId], [NewMajorKindName], [NewMajorId], [NewMajorName], " +
                    $"[HumanId], [HumanName], [SalaryStandardId], [SalaryStandardName], [SalarySum], [NewSalaryStandardId], [NewSalaryStandardName], [NewSalarySum], [ChangeReason], [Register], [RegistTime]) " +
                    $"values('{mc.FirstKindId}','{mc.FirstKindName}','{mc.SecondKindId}','{mc.SecondKindName}','{mc.ThirdKindId}','{mc.ThirdKindName}','{mc.MajorKindId}','{mc.MajorKindName}','{mc.MajorId}','{mc.MajorName}','{mc.NewFirstKindId}','{mc.NewFirstKindName}','{mc.NewSecondKindId}','{mc.NewSecondKindName}','{mc.NewThirdKindId}','{mc.NewThirdkindName}','{mc.NewMajorKindId}','{mc.NewMajorKindName}','{mc.NewMajorId}','{mc.NewMajorName}'," +
                    $"'{mc.HumanId}','{mc.HumanName}','{mc.SalaryStandardId}','{mc.SalaryStandardName}','{mc.SalarySum}','{mc.NewSalaryStandardId}','{mc.NewSalaryStandardName}','{mc.NewSalarySum}','{mc.ChangeReason}','{mc.Register}','{mc.RegistTime}')";
                return await conn.ExecuteAsync(sql);
            }
        }

        //mc表修改
        public async Task<int> MCIUpdate(MCi mc)
        {
            using (SqlConnection conn=new SqlConnection(program.sss))
            {
                string sql = $"update [dbo].[MC] set [FirstKindId]='{mc.FirstKindId}', [FirstKindName]='{mc.FirstKindName}', [SecondKindId]='{mc.SecondKindId}', [SecondKindName]='{mc.SecondKindName}', [ThirdKindId]='{mc.ThirdKindId}', " +
                    $"[ThirdKindName]='{mc.ThirdKindName}', [MajorKindId]='{mc.MajorKindId}', [MajorKindName]='{mc.MajorKindName}', [MajorId]='{mc.MajorId}', [MajorName]='{mc.MajorName}', [NewFirstKindId]='{mc.NewFirstKindId}', [NewFirstKindName]='{mc.NewFirstKindName}', " +
                    $"[NewSecondKindId]='{mc.NewSecondKindId}', [NewSecondKindName]='{mc.NewSecondKindName}', [NewThirdKindId]='{mc.NewThirdKindId}', [NewThirdkindName]='{mc.NewThirdkindName}', [NewMajorKindId]='{mc.NewMajorKindId}', [NewMajorKindName]='{mc.NewMajorKindName}', " +
                    $"[NewMajorId]='{mc.NewMajorId}', [NewMajorName]='{mc.NewMajorName}', [HumanId]='{mc.HumanId}', [HumanName]='{mc.HumanName}', [SalaryStandardId]='{mc.SalaryStandardId}', [SalaryStandardName]='{mc.SalaryStandardName}', [SalarySum]='{mc.SalarySum}', [NewSalaryStandardId]='{mc.NewSalaryStandardId}', " +
                    $"[NewSalaryStandardName]='{mc.NewSalaryStandardName}', [NewSalarySum]='{mc.NewSalarySum}', [ChangeReason]='{mc.ChangeReason}', [CheckReason]='{mc.CheckReason}', [CheckStatus]='{mc.CheckStatus}', [Register]='{mc.Register}', [Checker]='{mc.Checker}', [RegistTime]='{mc.RegistTime}', [CheckTime]='{mc.CheckTime}' " +
                    $"where [MchId]='{mc.MchId}'";
                return await conn.ExecuteAsync(sql);
            }
        }
    }
}