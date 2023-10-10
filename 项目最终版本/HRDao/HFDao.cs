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
    /// 人力资源档案
    /// </summary>
    public  class HFDao
    {
        Program program = new Program();
        /// <summary>
        /// 人力资源档案数据添加
        /// </summary>
        /// <param name="HF"></param>
        /// <returns></returns>
        public async Task<int> AddHF(HF hf)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                DateTime dt = System.DateTime.Now;
                string t = dt.ToString("yyyyMMddHHmmss");
                string a = "AA";
                string c = a + t;
                string sql = $@" insert into[dbo].[HF]
                    ( [HumanId], [FirstKindId], [FirstKindName], [SecondKindId], [SecondKindName], [ThirdKindId], [ThirdKindName], [HumanName], [HumanAddress], [HumanPostcode], [HumanProDesignation], [HumanMajorKindId], [HumanMajorKindName], [HumanMajorId], [HunmaMajorName], [HumanTelephone], [HumanMobilephone], [HumanBank], [HumanAccount], [HumanQQ], [HumanEmail], [HumanHobby], [HumanSpeciality], [HumanSex], [HumanReligion], [HumanParty], [HumanNationality], [HumanRace], [HumanBirthday], [HumanBirthplace], [HumanAge], [HumanEducatedDegree], [HumanEducatedYears], [HumanEducatedMajor], [HumanSocietySecurityId], [HumanIdCard], [Remark], [SalaryStandardId], [SalaryStandardName], [HumanFamilyMembership], [HumanPicture],[Register],[RegistTime],[HumanHistroyRecords],HumanFileStatus,CheckStatus)
                values('{c}',{hf.FirstKindId},'{hf.FirstKindName}',{hf.SecondKindId},'{hf.SecondKindName}',{hf.ThirdKindId},'{hf.ThirdKindName}','{hf.HumanName}','{hf.HumanAddress}','{hf.HumanPostcode}','{hf.HumanProDesignation}',{hf.HumanMajorKindId},'{hf.HumanMajorKindName}',{hf.HumanMajorId},'{hf.HunmaMajorName}','{hf.HumanTelephone}','{hf.HumanMobilephone}','{hf.HumanBank}','{hf.HumanAccount}','{hf.HumanQQ}','{hf.HumanEmail}','{hf.HumanHobby}','{hf.HumanSpeciality}','{hf.HumanSex}','{hf.HumanReligion}','{hf.HumanParty}','{hf.HumanNationality}','{hf.HumanRace}','{hf.HumanBirthday}','{hf.HumanBirthplace}',{hf.HumanAge},'{hf.HumanEducatedDegree}','{hf.HumanEducatedYears}','{hf.HumanEducatedMajor}',{hf.HumanSocietySecurityId},'{hf.HumanIdCard}','{hf.Remark}',{hf.SalaryStandardId},'{hf.SalaryStandardName}','{hf.HumanFamilyMembership}','{hf.HumanPicture}','{hf.Register}','{hf.RegistTime}','{hf.HumanHistroyRecords}',0,0)";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
        /// <summary>
        /// 人力资源档案数据复核
        /// </summary>
        /// <param name="HF"></param>
        /// <returns></returns>
        public async Task<int> UpdateHF(HF hf)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" update [dbo].[HF] set
                    [HumanName]='{hf.HumanName}', [HumanAddress]='{hf.HumanAddress}', [HumanPostcode]='{hf.HumanPostcode}', [HumanProDesignation]='{hf.HumanProDesignation}', [HumanTelephone]='{hf.HumanTelephone}', [HumanMobilephone]='{hf.HumanMobilephone}', [HumanBank]='{hf.HumanBank}', 
[HumanAccount]='{hf.HumanAccount}', [HumanQQ]='{hf.HumanQQ}', [HumanEmail]='{hf.HumanEmail}', [HumanHobby]='{hf.HumanHobby}', [HumanSpeciality]='{hf.HumanSpeciality}', [HumanSex]='{hf.HumanSex}', [HumanReligion]='{hf.HumanReligion}', 
[HumanParty]='{hf.HumanParty}', [HumanNationality]='{hf.HumanNationality}', [HumanRace]='{hf.HumanRace}', [HumanBirthday]='{hf.HumanBirthday}', [HumanBirthplace]='{hf.HumanBirthplace}', [HumanAge]={hf.HumanAge}, [HumanEducatedDegree]='{hf.HumanEducatedDegree}', 
[HumanEducatedYears]='{hf.HumanEducatedYears}', [HumanEducatedMajor]='{hf.HumanEducatedMajor}', [HumanSocietySecurityId]={hf.HumanSocietySecurityId}, [HumanIdCard]='{hf.HumanIdCard}', [Remark]='{hf.Remark}', [SalaryStandardId]={hf.SalaryStandardId}, 
[SalaryStandardName]='{hf.SalaryStandardName}', [HumanFamilyMembership]='{hf.HumanFamilyMembership}', [HumanPicture]='{hf.HumanPicture}',[HumanHistroyRecords]='{hf.HumanHistroyRecords}',AttachmentName='{hf.AttachmentName}',Checker='{hf.Checker}',CheckTime='{hf.CheckTime}',CheckStatus=1,HumanFileStatus=2
              where HufId ={hf.HufId}";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
        /// <summary>
        /// 人力资源档案数据更改
        /// </summary>
        /// <param name="HF"></param>
        /// <returns></returns>
        public async Task<int> UpdateHF2(HF hf)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" update [dbo].[HF] set
                    [HumanName]='{hf.HumanName}', [HumanAddress]='{hf.HumanAddress}', [HumanPostcode]='{hf.HumanPostcode}', [HumanProDesignation]='{hf.HumanProDesignation}', [HumanTelephone]='{hf.HumanTelephone}', [HumanMobilephone]='{hf.HumanMobilephone}', [HumanBank]='{hf.HumanBank}', 
[HumanAccount]='{hf.HumanAccount}', [HumanQQ]='{hf.HumanQQ}', [HumanEmail]='{hf.HumanEmail}', [HumanHobby]='{hf.HumanHobby}', [HumanSpeciality]='{hf.HumanSpeciality}', [HumanSex]='{hf.HumanSex}', [HumanReligion]='{hf.HumanReligion}', 
[HumanParty]='{hf.HumanParty}', [HumanNationality]='{hf.HumanNationality}', [HumanRace]='{hf.HumanRace}', [HumanBirthday]='{hf.HumanBirthday}', [HumanBirthplace]='{hf.HumanBirthplace}', [HumanAge]={hf.HumanAge}, [HumanEducatedDegree]='{hf.HumanEducatedDegree}', 
[HumanEducatedYears]='{hf.HumanEducatedYears}', [HumanEducatedMajor]='{hf.HumanEducatedMajor}', [HumanSocietySecurityId]={hf.HumanSocietySecurityId}, [HumanIdCard]='{hf.HumanIdCard}', [Remark]='{hf.Remark}', [SalaryStandardId]={hf.SalaryStandardId}, 
[SalaryStandardName]='{hf.SalaryStandardName}', [HumanFamilyMembership]='{hf.HumanFamilyMembership}', [HumanPicture]='{hf.HumanPicture}',[HumanHistroyRecords]='{hf.HumanHistroyRecords}',AttachmentName='{hf.AttachmentName}',Changer='{hf.Checker}',ChangeTime='{hf.RegistTime}',HumanFileStatus=1,FileChangAmount={hf.FileChangAmount}+1
              where HufId ={hf.HufId}";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
        /// <summary>
        /// 人力资源档案查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<HF> HFSelecteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                string sql = $@"select * from dbo.HF where HufId = {id}";
                return await connection.QueryFirstAsync<HF>(sql);
            }
        }
        /// <summary>
        /// 人力资源档案复核分页查询
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        public async Task<FenYe<HF>> HFFenYe(FenYe<HF> fenYe)
        {
            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@where", fenYe.condition);
                dynamicParameters.Add("@tableName", "HF");
                dynamicParameters.Add("@keyName", "HufId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("@zongye", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_DyidFenye] @pageSize, @currentPage,@where, @tableName, @keyName, @rows out ,@zongye out";
                fenYe.List = await connection.QueryAsync<HF>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        /// <summary>
        /// 已复核档案数据的查询分页展示（条件查询）
        /// </summary>
        /// <param name="fenYe"></param>
        /// <returns></returns>
        public async Task<FenYe<HF>> DanAnSelect(FenYe<HF> fenYe)
        {

            using (SqlConnection connection = new SqlConnection(program.sss))
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@pageSize", fenYe.PageSize);
                dynamicParameters.Add("@currentPage", fenYe.CurrentPage);
                dynamicParameters.Add("@where", fenYe.condition);
                dynamicParameters.Add("@tableName", "HF");
                dynamicParameters.Add("@keyName", "HufId");
                dynamicParameters.Add("@rows", direction: ParameterDirection.Output, dbType: DbType.Int32);
                dynamicParameters.Add("@zongye", direction: ParameterDirection.Output, dbType: DbType.Int32);
                string sql = @"exec [dbo].[proc_DyidFenye] @pageSize, @currentPage,@where, @tableName, @keyName, @rows out ,@zongye out";
                fenYe.List = await connection.QueryAsync<HF>(sql, dynamicParameters);
                fenYe.Rows = dynamicParameters.Get<int>("rows");
                return fenYe;
            }
        }
        /// <summary>
        /// 删除档案后状态的更改（删除）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public async Task<int> UpdateStatusHF(int HufId)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" update [dbo].[HF] set
                        [HumanFileStatus] = 3  where HufId = {HufId} ";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
        /// <summary>
        /// 恢复档案后状态的更改（恢复）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public async Task<int> UpdateStatusHF2(int HufId)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" update [dbo].[HF] set
                        [HumanFileStatus] = 2  where HufId = {HufId} ";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
        /// <summary>
        /// 永久档案（永久删除）
        /// </summary>
        /// <param name="er"></param>
        /// <returns></returns>
        public async Task<int> DeleteHF(int HufId)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" Delete [dbo].[HF] where HufId = {HufId} ";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
    }
}
