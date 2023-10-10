using Dapper;
using HRModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace HRDao
{
    public class SSDao
    {
        Program program = new Program();
        //添加
        public async Task<int> InsertSSAsync(SS ss)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"insert into [dbo].[SS](StandardId, StandardName, Designer, Register,RegistTime,SalarySum, CheckStatus,Remark)" +
                    $"values('{ss.StandardId}','{ss.StandardName}','{ss.Designer}','{ss.Register}','{ss.RegistTime}','{ss.SalarySum}','{ss.CheckStatus}','{ss.Remark}')";
                return await connection.ExecuteAsync(sql);
            }
        }

        //分页查询
        public async Task<FenYe<SS>> SelectSSAsync(FenYe<SS> fenYe)
        {

            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@tableName", "SS");
                dynamicParameters.Add("@keyName", "SsdId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_FenYe] @pageSize, @currentPage, @tableName, @keyName, @rows out";
                fenYe.List = await connection.QueryAsync<SS>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }

        //精确查询
        public async Task<SS> SleseSSDyid(string ss)
        {
            using (SqlConnection connection = new SqlConnection(program.sss)) 
            {
                string sql = $"select * from [dbo].[SS] where [StandardId]='{ss}'";
                return await connection.QueryFirstAsync<SS>(sql);
            }
        }
        //查询所有数据
        public async Task<IEnumerable<SS>> SelectSSDAsync()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from [dbo].[SS] ";
                return await connection.QueryAsync<SS>(sql);
            }
        }
    

        //复核修改
        public async Task<int> SSDUpdate(SS ss)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"Update [dbo].[SS] set " +
                    $"StandardName='{ss.StandardName}', Designer='{ss.Designer}', Checker='{ss.Checker}', CheckTime='{ss.CheckTime}', CheckStatus='{ss.CheckStatus}', ChangeStatus='{ss.ChangeStatus}' where [StandardId]='{ss.StandardId}'";
                return await connection.ExecuteAsync(sql);
            }
        }

        //分页模糊查询
        public async Task<FenYe<SS>> UsersRoleFenye(FenYe<SS> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynParameters = new DynamicParameters();
                dynParameters.Add("pageSize", fenYe.PageSize);
                dynParameters.Add("currentPage", fenYe.CurrentPage);
                dynParameters.Add("where", fenYe.condition);
                dynParameters.Add("tableName", " [dbo].[SS]");
                dynParameters.Add("KeyName", "SsdId");
                dynParameters.Add("count", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynParameters.Add("zongye", direction: ParameterDirection.Output, dbType: DbType.Int32); 
                string sql = "exec [dbo].[proc_DyidFenye] @pageSize, @currentPage,@where, @tableName, @keyName, @count out,@zongye out";
                fenYe.List = await connection.QueryAsync<SS>(sql, dynParameters);
                fenYe.Rows = dynParameters.Get<int>("count");
                return fenYe;
            }
        }

        //薪资修改
        public async Task<int> SSUpdate(SS ss)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql=$"update [dbo].[SS] set StandardName='{ss.StandardName}', Designer='{ss.Designer}', Changer='{ss.Checker}', ChangeTime='{ss.ChangeTime}', SalarySum='{ss.SalarySum}', Remark='{ss.Remark}',ChangeStatus=3 where StandardId='{ss.StandardId}'";
                return await connection.ExecuteAsync(sql);
            }
        }
    }
}
        