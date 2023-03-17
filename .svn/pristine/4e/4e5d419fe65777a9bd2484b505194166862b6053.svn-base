using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AI070.Models.WP03007
{
    public class MasterEmployee
    {
        public int Id { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Name { get; set; }
    }

    public class MasterExamSubject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PassingScore { get; set; }
        public short ExamDuration { get; set; }
        public System.DateTime ExamPeriodStart { get; set; }
        public System.DateTime ExamPeriodEnd { get; set; }
        public short MaxRemedial { get; set; }
        public int Remedial { get; set; }
        public string ExamType { get; set; }
        public int TOTAL_PUBLISHED { get; set; }
    }

    public class MasterExamQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string AnswerChoice_A { get; set; }
        public string AnswerChoice_B { get; set; }
        public string AnswerChoice_C { get; set; }
        public string AnswerChoice_D { get; set; }
        public string AnswerChoice_E { get; set; }
        public string AnswerUserChoose { get; set; }
        public string ImagePath { get; set; }
    }

    public class ExamAnswerDTO
    {
        public int Id { get; set; }
        public int No { get; set; }
        public string AnswerUserChoose { get; set; }
    }

    public partial class MasterExamScore
    {
        public int Id { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string Answer { get; set; }
        public int CorrectAmount { get; set; }
        public int WrongAmount { get; set; }
        public int NotAnswerAmount { get; set; }
        public Nullable<short> Remedial { get; set; }
        public int Score { get; set; }
        public int PassGraduate { get; set; }
        public Nullable<int> Timer { get; set; }
        public Nullable<System.DateTime> SubmitDate { get; set; }
        public string Status { get; set; }
    }
}