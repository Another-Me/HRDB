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
    /// 面试表数据操作
    /// </summary>
    public class EIDao
    {
        Program program = new Program();
        /// <summary>
        /// 面试数据添加
        /// </summary>
        /// <param name="eMR"></param>
        /// <returns></returns>
        public async Task<int> AddEI(EI ei)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" insert into[dbo].[EI]
                    ( [HumanName], [InterviewAmount], [HumanMajorKindId], [HumanMajorKindName], [HumanMajorId], [HunmaMajorName], [ImageDegree], [NativeLanguageDegree], [ForeignLanguageDegree], [ResponseSpeedDegree], [EQDegree], [IQDegree], [MultiQualityDegree], [Register], [RegisteTime], [ResumeId], [Result], [InterviewComment], [InterviewStatus])
                values('{ei.HumanName}',{ei.InterviewAmount},{ei.HumanMajorKindId},'{ei.HumanMajorKindName}',{ei.HumanMajorId},'{ei.HunmaMajorName}','{ei.ImageDegree}','{ei.NativeLanguageDegree}','{ei.ForeignLanguageDegree}','{ei.ResponseSpeedDegree}','{ei.EQDegree}','{ei.IQDegree}','{ei.MultiQualityDegree}','{ei.Register}','{ei.RegisteTime}','{ei.ResumeId}','{ei.Result}','{ei.InterviewComment}',{ei.InterviewStatus})";
                return await sqlcon.ExecuteAsync(sql);
            }

        }

        /// <summary>
        /// 面试表分页查询
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        public async Task<FenYe<EI>> EIFenYe(FenYe<EI> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@tableName", "EI");
                dynamicParameters.Add("@keyName", "EinId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_FenYe] @pageSize, @currentPage, @tableName, @keyName, @rows out";
                fenYe.List = await connection.QueryAsync<EI>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        /// <summary>
        /// 面试表分页查询
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        public async Task<FenYe<EI>> EIFenYe2(FenYe<EI> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@where", fenYe.condition);
                dynamicParameters.Add("@tableName", "EI");
                dynamicParameters.Add("@keyName", "EinId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("@zongye", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_DyidFenye] @pageSize, @currentPage,@where, @tableName, @keyName, @rows out ,@zongye out";
                fenYe.List = await connection.QueryAsync<EI>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        /// <summary>
        /// 是否存在重复的面试资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EI> SelectEIByResumeId(int ResumeId)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from [dbo].[EI] where ResumeId={ResumeId}";
                return await connection.QueryFirstAsync<EI>(sql);
            }
        }

        /// <summary>
        /// 筛选指定的面试资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<EI> SelectEIById(int EinId)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from [dbo].[EI] where EinId={EinId}";
                return await connection.QueryFirstAsync<EI>(sql);
            }
        }
        /// <summary>
        /// 筛选后状态的更改
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public async Task<int> UpdateStatusEI(EI ei)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" update [dbo].[EI] set [CheckTime]='{ei.CheckTime}',[Checker]='{ei.Checker}',[CheckComment]='{ei.CheckComment}', [Result] = '{ei.CheckComment}',InterviewStatus=1 ,[CheckStatus]=1  where EinId = {ei.EinId} ";
                return await sqlcon.ExecuteAsync(sql);
            }

        }

    }
}
