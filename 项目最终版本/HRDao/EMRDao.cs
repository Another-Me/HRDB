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
    /// 职位发布管理
    /// </summary>
    public class EMRDao
    {
        //数据库连接对象
        Program program = new Program();
        /// <summary>
        /// 职位发布数据添加
        /// </summary>
        /// <param name="eMR"></param>
        /// <returns></returns>
        public async Task<int> AddEMR(EMR emr)
        {
            DateTime dt = System.DateTime.Now;
           
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {

               string sql = $@"insert into EMR
                (FirstKindId, FirstKindName, SecondKindId, SecondKindName, ThirdKindId, ThirdKindName,
                EngageType,MajorKindId,MajorKindName,MajorId,MajorName,HumanAmount,Deadline,Register,RegistTime,MajorDescribe,EngageRequired)
               values('{emr.FirstKindId}','{emr.FirstKindName}','{emr.SecondKindId}','{emr.SecondKindName}','{emr.ThirdKindId}','{emr.ThirdKindName}','{emr.EngageType}','{emr.MajorKindId}','{emr.MajorKindName}','{emr.MajorId}','{emr.MajorName}','{emr.HumanAmount}','{emr.Deadline}','{emr.Register}','{dt}','{emr.MajorDescribe}','{emr.EngageRequired}')";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
        /// <summary>
        /// 职位发布数据修改
        /// </summary>
        /// <param name="eMR"></param>
        /// <returns></returns>
        public async Task<int> UpdateEMR(EMR emr)
        {
            DateTime dt = System.DateTime.Now;

            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@"update  EMR set 
                FirstKindId={emr.FirstKindId}, FirstKindName='{emr.FirstKindName}', SecondKindId={emr.SecondKindId}, SecondKindName='{emr.SecondKindName}', ThirdKindId={emr.ThirdKindId}, ThirdKindName='{emr.ThirdKindName}',
                EngageType='{emr.EngageType}',MajorKindId={emr.MajorKindId},MajorKindName='{emr.MajorKindName}',MajorId={emr.MajorId},MajorName='{emr.MajorName}',HumanAmount={emr.HumanAmount},
                Deadline='{emr.Deadline}',ChangeTime='{dt}',Register='{emr.Register}',MajorDescribe='{emr.MajorDescribe}',EngageRequired='{emr.EngageRequired}' where MreId={emr.MreId}";
                return await sqlcon.ExecuteAsync(sql);
            }

        }

        /// <summary>
        /// 职位发布分页查询
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        public async Task<FenYe<EMR>> ERMFenYe(FenYe<EMR> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@tableName", "EMR");
                dynamicParameters.Add("@keyName", "MreId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_FenYe] @pageSize, @currentPage, @tableName, @keyName, @rows out";
                fenYe.List = await connection.QueryAsync<EMR>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }

        /// <summary>
        /// 职位发布添加更改数据展示
        /// </summary>
        /// <returns></returns>
        public async Task<EMR> EMRSelecteById(int MreId)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))//查询职称名称
            {
                string sql = $@"select * from dbo.EMR where MreId = {MreId}";
                return await connection.QueryFirstAsync<EMR>(sql);
            }
        }
        /// <summary>
        /// 职位发布数据删除
        /// </summary>
        /// <param name="MreId"></param>
        /// <returns></returns>
        public async Task<int> EMRDeleteAsync(int MreId)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $"delete EMR where MreId={MreId}";
                return await sqlcon.ExecuteAsync(sql);
            }
        }
        /// <summary>
        /// 职位发布人数修改
        /// </summary>
        /// <param name="MreId"></param>
        /// <returns></returns>
        public async Task<int> Renshu(int MreId)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $"update EMR set HumanAmount=HumanAmount-1 where MreId={MreId}";
                return await sqlcon.ExecuteAsync(sql);
            }
        }


    }
}
