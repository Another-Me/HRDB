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
    /// 人力资源档案登记
    /// </summary>
    public class HFDDao
    {
        Program program = new Program();
        //级联
        public List<CFTK> SelectLEVELAsync()
        {
            using (SqlConnection conn = new SqlConnection(program.sss))
            {
                string sql = "select*from [dbo].[CFFK]";
                List<CFTK> list = new List<CFTK>();

                list = conn.Query<CFTK>(sql).ToList();
                foreach (CFTK item in list)
                {
                    string sql2 = $@"select*from JLCX where a='{item.FirstKindId}'";
                    item.Chlidren = conn.Query<CFTK>(sql2).ToList();
                    foreach (CFTK item2 in item.Chlidren)
                    {
                        string sql3 = $@"select*from V_CFTK where a1='{item2.FirstKindId}'";
                        item2.Chlidren = conn.Query<CFTK>(sql3).ToList();

                    }
                }
                return list;
            }
        }

        /// <summary>
        /// 人力资源档案数据更改添加
        /// </summary>
        /// <param name="HF"></param>
        /// <returns></returns>
        public async Task<int> AddHFD(HFD hfd)
        {
            using (SqlConnection sqlcon = new SqlConnection(program.sss))
            {
                string sql = $@" insert into[dbo].[HFD]
                 ([HumanId], [FirstKindId], [FirstKindName], [SecondKindId], [SecondKindName], [ThirdKindId], [ThirdKindName], [HumanName], [HumanAddress], [HumanPostcode], [HumanProDesignation], [HumanMajorKindId], [HumanMajorKindName], [HumanMajorId], [HunmaMajorName], [HumanTelephone], [HumanMobilephone], [HumanBank], [HumanAccount], [HumanQQ], [HumanEmail], [HumanHobby], [HumanSpeciality], [HumanSex], [HumanReligion], [HumanParty], [HumanNationality], [HumanRace], [HumanBirthday], [HumanBirthplace], [HumanAge], [HumanEducatedDegree], [HumanEducatedYears], [HumanEducatedMajor], [HumanSocietySecurityId], [HumanIdCard], [Remark], [SalaryStandardId], [SalaryStandardName], [HumanFamilyMembership], [HumanPicture],[Register],[RegistTime],[HumanHistroyRecords],Changer,ChangeTime)
                values('{hfd.HumanId}',{hfd.FirstKindId},'{hfd.FirstKindName}',{hfd.SecondKindId},'{hfd.SecondKindName}',{hfd.ThirdKindId},'{hfd.ThirdKindName}','{hfd.HumanName}','{hfd.HumanAddress}','{hfd.HumanPostcode}','{hfd.HumanProDesignation}',{hfd.HumanMajorKindId},'{hfd.HumanMajorKindName}',{hfd.HumanMajorId},'{hfd.HunmaMajorName}','{hfd.HumanTelephone}','{hfd.HumanMobilephone}','{hfd.HumanBank}','{hfd.HumanAccount}','{hfd.HumanQQ}','{hfd.HumanEmail}','{hfd.HumanHobby}','{hfd.HumanSpeciality}','{hfd.HumanSex}','{hfd.HumanReligion}','{hfd.HumanParty}','{hfd.HumanNationality}','{hfd.HumanRace}','{hfd.HumanBirthday}','{hfd.HumanBirthplace}',{hfd.HumanAge},'{hfd.HumanEducatedDegree}','{hfd.HumanEducatedYears}','{hfd.HumanEducatedMajor}',{hfd.HumanSocietySecurityId},'{hfd.HumanIdCard}','{hfd.Remark}',{hfd.SalaryStandardId},'{hfd.SalaryStandardName}','{hfd.HumanFamilyMembership}','{hfd.HumanPicture}','{hfd.Register}','{hfd.RegistTime}','{hfd.HumanHistroyRecords}','{hfd.Changer}','{hfd.ChangeTime}')";
                return await sqlcon.ExecuteAsync(sql);
            }

        }
    }
}
