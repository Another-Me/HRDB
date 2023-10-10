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
    public class CPCDao
    {

        //数据库连接对象
        Program program = new Program();

        //公共属性分页查询
        public async Task<FenYe<CPC>> GongGongFenYe(FenYe<CPC> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@tableName", "CPC");
                dynamicParameters.Add("@keyName", "PbcId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_FenYe] @pageSize, @currentPage, @tableName, @keyName, @rows out";
                fenYe.List = await connection.QueryAsync<CPC>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        //公共属性删除
        public async Task<int> CPCDeleteAsync(int id)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $"delete cpc where PbcId={id}";
                return await sqlcon.ExecuteAsync(sql);
            }
        }
        //公共属性添加
        public async Task<int> CPCInsertAsync(CPC cpc)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $"insert into cpc(AttributeKind,AttributeName)values('{cpc.AttributeKind}','{cpc.AttributeName}')";
                return await sqlcon.ExecuteAsync(sql);
            }
        }

        #region 公共字段查询

        public async Task<IEnumerable<CPC>> ZhiChengSelecte()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))//查询职称名称
            {
                string sql = @"select * from dbo.CPC
                where AttributeKind='职称'";
                return await connection.QueryAsync<CPC>(sql);
            }
        }
        public async Task<IEnumerable<CPC>> GuoJiSelecte()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))//查询国籍名称
            {
                string sql = @"select * from dbo.CPC
                where AttributeKind='国籍'";
                return await connection.QueryAsync<CPC>(sql);
            }
        }
        public async Task<IEnumerable<CPC>> MinZuSelecte()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))//查询民族
            {
                string sql = @"select * from dbo.CPC
                where AttributeKind='民族'";
                return await connection.QueryAsync<CPC>(sql);
            }
        }
        public async Task<IEnumerable<CPC>> ZongJiaoSelecte()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))//查询宗教信仰名称
            {
                string sql = @"select * from dbo.CPC
                where AttributeKind='宗教信仰'";
                return await connection.QueryAsync<CPC>(sql);
            }
        }
        public async Task<IEnumerable<CPC>> ZZMianMaoSelecte()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))//查询政治面貌
            {
                string sql = @"select * from dbo.CPC
                where AttributeKind='政治面貌'";
                return await connection.QueryAsync<CPC>(sql);
            }
        }
        public async Task<IEnumerable<CPC>> JYNianXianSelecte()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))//查询教育年限
            {
                string sql = @"select * from dbo.CPC
                where AttributeKind='教育年限'";
                return await connection.QueryAsync<CPC>(sql);
            }
        }
        public async Task<IEnumerable<CPC>> XueLiSelecte()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))//查询学历
            {
                string sql = @"select * from dbo.CPC
                where AttributeKind='学历'";
                return await connection.QueryAsync<CPC>(sql);
            }
        }
        public async Task<IEnumerable<CPC>> ZhuanYeSelecte()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))//查询专业
            {
                string sql = @"select * from dbo.CPC
                where AttributeKind='专业'";
                return await connection.QueryAsync<CPC>(sql);
            }
        }
        public async Task<IEnumerable<CPC>> TeChangSelecte()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))//查询特长
            {
                string sql = @"select * from dbo.CPC
                where AttributeKind='特长'";
                return await connection.QueryAsync<CPC>(sql);
            }
        }
        public async Task<IEnumerable<CPC>> AiHaoSelecte()
        {
            using (SqlConnection connection = new SqlConnection(program.sss))//查询爱好
            {
                string sql = @"select * from dbo.CPC
                where AttributeKind='爱好'";
                return await connection.QueryAsync<CPC>(sql);
            }
        }

        #endregion
    }
}
