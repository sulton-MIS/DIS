using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models.WP03007
{
	public class WP03007Repository
	{
        public MasterEmployee GetMasterEmployee(int ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<MasterEmployee>("WP03007/WP03007_GetMasterEamployee", new
            {
                ID
            }).FirstOrDefault();
            db.Close();
            return result;
        }

        public MasterExamSubject GetExamSubjectActive(int ID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<MasterExamSubject>("WP03007/WP03007_GetExamSubjectActive", new
            {
                ID
            }).FirstOrDefault();
            db.Close();
            return result;
        }

        public List<MasterExamSubject> GetListExamSubjectActive(int EMPLOYEID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<MasterExamSubject>("WP03007/WP03007_GetExamSubjectPerUser", new
            { EMPLOYEID }).ToList();
            db.Close();
            return result;
        }

        public List<MasterExamQuestion> GetExamQuestionActive(int SUBJECTID)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<MasterExamQuestion>("WP03007/WP03007_GetExamQuestionActive", new
            {
                SUBJECTID
            }).ToList();
            db.Close();
            return result;
        }

        public MasterExamScore GetExamScore(int EmployeeId)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<MasterExamScore>("WP03007/WP03007_GetExamScorePerUser", new
            {
                EmployeeId
            }).FirstOrDefault();
            db.Close();
            return result;
        }

        public void CreateExamScore(MasterExamScore data)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var d = db.Execute("WP03007/WP03007_CreateExamScore", new
            {
                data.EmployeeId,
                data.SubjectId,
                data.CompanyId,
                data.Answer,
                data.CorrectAmount,
                data.WrongAmount,
                data.NotAnswerAmount,
                data.PassGraduate,
                data.Score,
                data.Status,
                data.Timer,
                data.SubmitDate
            });
            db.Close();
        }
    }
}