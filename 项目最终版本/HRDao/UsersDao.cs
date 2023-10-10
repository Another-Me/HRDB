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
    
    /// <summary>
    /// 用户数据操作
    /// </summary>
    public class UsersDao
    {
        //数据库连接对象
        Program program = new Program();

        /// <summary>
        /// 用户登录查询
        /// </summary>
        public async Task<IEnumerable<Users>> UsersSelectByIdAsync(string UName, string UPassWord)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $@"select * from [dbo].[User] where UName='{UName}'and UPassWord='{UPassWord}'";
                return await connection.QueryAsync<Users>(sql);
            }
        }

        //薪酬标准查询用户
        public async Task<IEnumerable<Users>> StandardSelectUser()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = "Select * from [dbo].[User]";
                return await connection.QueryAsync<Users>(sql);
            }
        }

        //用户表删除
        public async Task<int> DeleteUser(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"delete from [dbo].[User]  where[UId]='{id}'";
                return await connection.ExecuteAsync(sql);
            }
        }

        //用户增加
        public async Task<int> UserInsert(Users us)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"insert [dbo].[User]( UName, UTrueName, UPassWord)values('{us.UName}','{us.UTrueName}','{us.UPassWord}')";
                return await connection.ExecuteAsync(sql);
            }
        }

        //查询用户最新自增列
        public async Task<int> UserUidSelect()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = "select max ([UId]) from  [dbo].[User]";
                return await connection.QueryFirstAsync<int>(sql);
            }
        }

        //用户修改
        public async Task<int> UserUpdate(Users us)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"update  [dbo].[User] set UName='{us.UName}', UTrueName='{us.UTrueName}', UPassWord='{us.UPassWord}' where [UId]='{us.UId}'";
                return await connection.ExecuteAsync(sql);
            }
        }
    }
}
