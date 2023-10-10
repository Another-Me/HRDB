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

    /// <summary>
    /// 客户设置数据操作
    /// </summary>
    public class CMDao
    {

        //数据库连接对象
        Program program = new Program();

    
        /// <summary>
        /// 查询所有客户设置信息并分页
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        public async Task<FenYe<CM>> SelectCMAll(FenYe<CM> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@tableName", "dbo.CM");
                dynamicParameters.Add("@keyName", "MakId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_FenYe] @pageSize, @currentPage, @tableName, @keyName, @rows out";
                fenYe.List = await connection.QueryAsync<CM>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }

        /// <summary>
        /// 客户设置新增数据
        /// </summary>
        /// <param name="trees"></param>
        /// <returns></returns>
        public async Task<int> CMInsertAsync(CM cm)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $@"insert into dbo.CM (MajorId,MajorKindId,MajorKindName,MajorName) 
                            values ({cm.MajorId},{cm.MajorKindId},'{cm.MajorKindName}','{cm.MajorName}')";
                return await connection.ExecuteAsync(sql);
            }
        }
        /// <summary>
        /// 客户设置删除数据
        /// </summary>
        /// <param name="trees"></param>
        /// <returns></returns>
        public async Task<int> CMDeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $@"delete from [dbo].[CM] where MakId={id}";
                return await connection.ExecuteAsync(sql);
            }
        }

        public async Task<IEnumerable<MCi>> MCSelect()
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $@"Select * from MC ";
                return await conn.QueryAsync<MCi>(sql);
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
        public async Task<FenYe<HFD>> MCSelectAsync(FenYe<HFD> fenYe)
        {

            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynParameters = new DynamicParameters();
                dynParameters.Add("pageSize", fenYe.PageSize);
                dynParameters.Add("currentPage", fenYe.CurrentPage);
                dynParameters.Add("where", fenYe.Where);
                dynParameters.Add("tableName", " [dbo].[HFD]");
                dynParameters.Add("KeyName", "HfdId");
                dynParameters.Add("count", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynParameters.Add("zongye", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = "exec [dbo].[porc_fy] @pageSize, @currentPage,@where, @tableName, @keyName, @count out,@zongye out";
                fenYe.List = await connection.QueryAsync<HFD>(sql, dynParameters);
                fenYe.Rows = dynParameters.Get<int>("count");
                return fenYe;
            }
        }
        public async Task<int> MCUpdate(MCi mc)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $@"update [dbo].[MC] set [FirstKindName]='{mc.FirstKindName}',[SecondKindName]='{mc.SecondKindName}',[ThirdKindName]='{mc.ThirdKindName}',[MajorKindName]='{mc.MajorKindName}', [MajorName]='{mc.MajorName}',[NewFirstKindName]='{mc.NewFirstKindName}',[NewSecondKindName]='{mc.NewSecondKindName}',[NewThirdkindName]='{mc.NewThirdkindName}',
                [NewMajorKindName]='{mc.NewMajorKindName}',[NewMajorName]='{mc.NewMajorName}',HumanId={mc.HumanId},[HumanName]='{mc.HumanName}',[SalaryStandardName]='{mc.SalaryStandardName}',[SalarySum]='{mc.SalarySum}',
                [NewSalaryStandardName]='{mc.NewSalaryStandardName}',[NewSalarySum]='{mc.NewSalarySum}',[ChangeReason]='{mc.ChangeReason}',[Register]='{mc.Register}',[RegistTime]='{mc.RegistTime}' where [HumanId]={mc.HumanId}";
                return await connection.ExecuteAsync(sql);
            }
        }
        //id查询
        public async Task<MCi> MCInsert(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from [dbo].[MC] where [HumanId]={id}";
                return await connection.QueryFirstAsync<MCi>(sql);
            }
        }
        public async Task<MCi> MCSLess(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from [dbo].[MC] where [MchId]={id}";
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
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = "select * from CM";
                List<CM> list = new List<CM>();
                list = conn.Query<CM>(sql).ToList();
                foreach (CM c in list)
                {
                    string sql1 = $@"select *from Liangji where b='{c.MajorKindName}'";
                    c.Children = conn.Query<CM>(sql1).ToList();
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
        public async Task<int> MCshenUpdata(MCi mc)
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = $@"update [dbo].[MC] set FirstKindName='{mc.FirstKindName}',SecondKindName='{mc.SecondKindName}',ThirdKindName='{mc.ThirdKindName}',NewFirstKindName='{mc.NewFirstKindName}',NewSecondKindName='{mc.NewSecondKindName}',
                NewThirdKindName='{mc.NewThirdkindName}',NewMajorKindName='{mc.NewMajorKindName}',NewMajorName='{mc.NewMajorName}',NewSalaryStandardName='{mc.NewSalaryStandardName}',
                NewSalarySum='{mc.NewSalarySum}',CheckReason='{mc.CheckReason}',Checker='{mc.Checker}',CheckStatus='{mc.CheckStatus}' where MchId='{mc.MchId}' ";
                return await conn.ExecuteAsync(sql);
            }
        }

        //机构级联
        public List<CM> SelectCMLEVELAsync()
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = "select * from [dbo].[CMK]";
                List<CM> list = new List<CM>();

                list = conn.Query<CM>(sql).ToList();
                foreach (CM item in list)
                {
                    string sql2 = $@"select * from V_ZhiWei where a='{item.MajorKindId}'";
                    item.Chlidren = conn.Query<CM>(sql2).ToList();
                }
                return list;
            }
        }
    }
}
