using Dapper;
using HRModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDao
{
    public class SsdDAO
    {
        Program program = new Program();

        //添加
        public async Task<int> InsertSSDAsync(SSD ssd)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"Insert into [dbo].[SSD]( StandardId, StandardName, ItemId, ItemName, Salary) values ('{ssd.StandardId}','{ssd.StandardName}','{ssd.ItemId}','{ssd.ItemName}','{ssd.Salary}')";
                return await connection.ExecuteAsync(sql);
            }
        }
        //删除
        public async Task<int> SSdDelectAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $" delete SSD where SdtId={id}";
                return await connection.ExecuteAsync(sql);
            }
        }

        //薪资标准复核查询数据(sdd)
        public async Task<IEnumerable<SSD>> SelectSSDDyid(string dd)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from [dbo].[SSD] where [StandardId]='{dd}'";
                return await connection.QueryAsync<SSD>(sql);
            }
        }

        //金额修改
        public async Task<int> SSDSalaryUpdate(int id, int uid)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"update [dbo].[SSD] set Salary='{uid}' where SdtId='{id}'";
                return await connection.ExecuteAsync(sql);
            }

        }

        //薪酬发放登记查询薪酬详细信息
        public async Task<IEnumerable<SSD>> SSDdetailed(string name)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from SSD where [StandardId]='{name}'";
                return await connection.QueryAsync<SSD>(sql);
            }
        }

        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="ssd"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SSD>> SelectSSDAsync()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $"select * from [dbo].[SSD] ";
                return await connection.QueryAsync<SSD>(sql);
            }
        }
    }
}
