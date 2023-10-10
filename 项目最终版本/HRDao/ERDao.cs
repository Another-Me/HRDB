using Dapper;
using HRModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HRDao
{
    public class ERDao
    {
        //数据库连接对象
        Program program = new Program();
        /// <summary>
        /// 简历数据添加
        /// </summary>
        /// <param name="eMR"></param>
        /// <returns></returns>
        public async Task<int> AddER(ER er)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                DateTime dt = System.DateTime.Now;
                string sql = $@" insert into[dbo].[ER]
                    ([HumanName], [EngageType], [HumanAddress], [HumanPostcode], [HumanMajorKindId], [HumanMajorKindName], [HumanMajorId], [HunmaMajorName], [HumanTelephone], [HumanHomephone], [HumanMobilephone], [HumanEmail], [HumanHobby], [HumanSpeciality], [HumanSex], [HumanReligion], [HumanParty], [HumanNationality], [HumanRace], [HumanBirthday], [HumanAge], [HumanEducatedDegree], [HumanEducatedYears], [HumanEducatedMajor], [HumanCollege], [HumanIdcard], [HumanBirthplace], [DemandSalaryStandard], [HumanHistoryRecords], [Remark], [HumanPicture],[RegistTime],[InterviewStatus],MreId)
                values('{er.HumanName}','{er.EngageType}','{er.HumanAddress}','{er.HumanPostcode}',{er.HumanMajorKindId},'{er.HumanMajorKindName}',{er.HumanMajorId},'{er.HunmaMajorName}','{er.HumanTelephone}','{er.HumanHomephone}','{er.HumanMobilephone}','{er.HumanEmail}','{er.HumanHobby}','{er.HumanSpeciality}','{er.HumanSex}','{er.HumanReligion}','{er.HumanParty}','{er.HumanNationality}','{er.HumanRace}','{er.HumanBirthday}',{er.HumanAge},'{er.HumanEducatedDegree}','{er.HumanEducatedYears}','{er.HumanEducatedMajor}','{er.HumanCollege}','{er.HumanIdcard}','{er.HumanBirthplace}','{er.DemandSalaryStandard}','{er.HumanHistoryRecords}','{er.Remark}','{er.HumanPicture}','{dt}',0,{er.MreId})";
                return await sqlcon.ExecuteAsync(sql);
            }

        }

        /// <summary>
        /// 简历筛选成功后状态的更改（未面试）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public async Task<int> UpdateStatusER(int ResId)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" update [dbo].[ER] set
                        [InterviewStatus] = 1  where ResId = {ResId} ";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
        /// <summary>
        /// 面试筛选成功后状态的更改（已面试）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public async Task<int> UpdateStatusER7(int ResId)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" update [dbo].[ER] set
                        [InterviewStatus] = 7  where ResId = {ResId} ";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
        /// <summary>
        /// 面试后状态的更改（已面试）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public async Task<int> UpdateStatusER2(int ResId)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" update [dbo].[ER] set
                        [InterviewStatus] = 2  where ResId = {ResId} ";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
        /// <summary>
        /// 建档后状态的更改（已建档）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public async Task<int> UpdateStatusER5(int ResId)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" update [dbo].[ER] set
                        [InterviewStatus] = 5  where ResId = {ResId} ";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
        /// <summary>
        /// 通过面试后申请后状态的更改（通过申请）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public async Task<int> UpdateStatusER3(int ResId ,ER er)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" update [dbo].[ER] set
                        [PassCheckComment] = '{er.PassCheckComment}'  where ResId = {ResId} ";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
        /// <summary>
        /// 通过面试后申请后状态的更改（通过审批）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public async Task<int> UpdateStatusER4(int ResId, ER er)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" update [dbo].[ER] set
                        [PassPassComment] = '{er.PassPassComment}'  where ResId = {ResId} ";
                return await sqlcon.ExecuteAsync(sql);
            }

        }

        /// <summary>
        /// 简历数据的查询分页展示
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        public async Task<FenYe<ER>> JianLiSelect(FenYe<ER> fenYe)
        {

            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@where", fenYe.condition);
                dynamicParameters.Add("@tableName", "ER");
                dynamicParameters.Add("@keyName", "ResId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("@zongye", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_DyidFenye] @pageSize, @currentPage,@where, @tableName, @keyName, @rows out ,@zongye out";
                fenYe.List = await connection.QueryAsync<ER>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        /// <summary>
        /// 简历数据更改数据展示（传值）
        /// </summary>
        /// <returns></returns>
        public async Task<ER> ERSelecteById(int resId)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $@"select * from dbo.ER where ResId = {resId}";
                return await connection.QueryFirstAsync<ER>(sql);
            }
        }

        /// <summary>
        /// 简历的推荐（修改数据）
        /// </summary>
        /// <param name="eMR"></param>
        /// <returns></returns>
        public async Task<int> RecommendER(ER er)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                DateTime dt = System.DateTime.Now;
                string sql = $@" update [dbo].[ER] set
                    [HumanName]='{er.HumanName}', [EngageType]='{er.EngageType}', [HumanAddress]='{er.HumanAddress}', [HumanPostcode]='{er.HumanPostcode}',  [HumanTelephone]='{er.HumanTelephone}', [HumanHomephone]='{er.HumanHomephone}', [HumanMobilephone]='{er.HumanMobilephone}', [HumanEmail]='{er.HumanEmail}', 
                    [HumanHobby]='{er.HumanHobby}', [HumanSpeciality]='{er.HumanSpeciality}', [HumanSex]='{er.HumanSex}', [HumanReligion]='{er.HumanReligion}', [HumanParty]='{er.HumanParty}', [HumanNationality]='{er.HumanNationality}', [HumanRace]='{er.HumanRace}', [HumanBirthday]='{er.HumanBirthday}', 
                    [HumanAge]={er.HumanAge}, [HumanEducatedDegree]='{er.HumanEducatedDegree}', [HumanEducatedYears]='{er.HumanEducatedYears}', [HumanEducatedMajor]='{er.HumanEducatedMajor}', [HumanCollege]='{er.HumanCollege}', [HumanIdcard]='{er.HumanIdcard}', [HumanBirthplace]='{er.HumanBirthplace}', 
                    [DemandSalaryStandard]='{er.DemandSalaryStandard}', [HumanHistoryRecords]='{er.HumanHistoryRecords}', [Remark]='{er.Remark}', [HumanPicture]='{er.HumanPicture}',[RegistTime]='{er.RegistTime}',[Checker]='{er.Checker}',[CheckTime]='{dt}',[Recomandation]='{er.Recomandation}'
                    where ResId = {er.ResId}";
                return await sqlcon.ExecuteAsync(sql);
            }

        }

        /// <summary>
        /// 删除简历
        /// </summary>
        /// <returns></returns>
        public async Task<int> ERDeleteById(int resId)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $@"delete dbo.ER where ResId = {resId}";
                return await connection.ExecuteAsync(sql);
            }
        }
    }
}
