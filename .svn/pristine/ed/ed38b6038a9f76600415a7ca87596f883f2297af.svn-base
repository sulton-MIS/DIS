/************************************************************************************************************
 * Program History :                                                                                        *
 *                                                                                                          *
 * Project Name     : TRAINING PLAINING & REGISTRATION ONLINE                                               *
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)                                      *
 * Function Id      : TMS040500W                                                                            *
 * Function Name    : Email Sending Batch                                                                   *
 * Function Group   : Registration Control                                                                  *
 * Program Id       : TMS040500BRepository                                                                  *
 * Program Name     : Emai Sending Batch Repository                                                         *
 * Program Type     : Model                                                                                 *
 * Description      :                                                                                       *
 * Environment      : .NET 4.0, ASP MVC 4.0                                                                 *
 * Author           : FID.Arri                                                                              *
 * Version          : 01.00.00                                                                              *
 * Creation Date    : 17/12/2015 11:51:40                                                                   *
 *                                                                                                          *
 * Update history		Re-fix date				Person in charge				Description					*
 *       0.1             29/12/2015             Witan                       Add Confirmation Email          *
 *       0.2             06/01/2016             FID.Arri                    Add Invitation Email for        *
 *                                                                          Trainer & Participant           *
 *                                                                                                          *
 * Copyright(C) 2015 - Fujitsu Indonesia. All Rights Reserved                                               *                          
 ************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using Toyota.Common.Web.Platform;
using Toyota.Common.Database;
using AD021.Models;
using AD021.Models.TMS040500B;
using AD021.Models.AD021000100W;

namespace AD021.Models.TMS040500B
{
    public class TMS040500BRepository
    {
        #region Singleton
        private static TMS040500BRepository instance = null;
        public static TMS040500BRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TMS040500BRepository();
                }
                return instance;
            }
        }
        #endregion

        #region ForgetPassword
        public String EmailForgetPassword(string userID, string password, string email, string username)
        {
            string result = "";
            string NullableData = null;
            IDBContext db = DatabaseManager.Instance.GetContext();
            var process_id = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetProcessID");
            var sequence = 1;
            try
            {
                db.BeginTransaction();
                dynamic args = new
                {
                    pid = process_id,
                    seq = sequence,
                    func = "TMS040500B",
                    uid = userID.ToString(),
                    result = "Success",
                    param = password.ToString() + "|" + username.ToString(),
                    aTO = "sayidiman.rukhiatna@id.fujitsu.com",
                    aCC = NullableData,
                    aBCC = NullableData,
                    aFOOT = "<br /><br /><br />Best Regards,<br />TPRO Administrator",
                    aSUBJ = "[TPRO] Forget Password",
                    aFULL = NullableData,
                    aEMAIL = NullableData,
                    aTEXT = "Dear Mr/Mrs/Ms. {0},<br /><br /> Here is your password: <strong>{1}</strong><br />"
                            + "Click here to re-login: <a href='http://10.165.8.68:4144/AD021000100W'>[Click Here]</a><br /><br />"
                            + "Please be careful when sharing these login details with others."
                };
                db.Execute("TMS040500B/TMS040500BSendForgetPassword", args);
                db.CommitTransaction();
                result = "Success";
            }
            catch (Exception e)
            {
                db.AbortTransaction();
                result = e.Message.ToString();
            }
            finally
            {
                db.Close();
            }
            return result;
        }
        #endregion

        #region getTrainingData
        public IEnumerable<TMS040500BTrainingData> getTrainingData(string training_topic, string training_schedule)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            IEnumerable<TMS040500BTrainingData> result = db.Fetch<TMS040500BTrainingData>("TMS040500B/TMS040500BgetTrainingData",
                new { TRAINING_TOPIC_CD = training_topic,TRAINING_SCH_ID=training_schedule});
            db.Close();
            return result;
        }
        #endregion

        #region getTrainerData
        public IEnumerable<TMS040500BTrainerData> getTrainerData(string training_schedule_id)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            IEnumerable<TMS040500BTrainerData> result = db.Fetch<TMS040500BTrainerData>("TMS040500B/TMS040500BgetTrainerData",
                new { TRAINING_SCH_ID = training_schedule_id });
            db.Close();
            return result;
        }
        #endregion

        #region getDivisionOfTrainee
        public IEnumerable<TMS040500BDivisionOfTrainee> getParticipantDivisionManager(string training_schedule_id)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            IEnumerable<TMS040500BDivisionOfTrainee> result = db.Fetch<TMS040500BDivisionOfTrainee>("TMS040500B/TMS040500BgetDivisionOfTrainee",
                new { TRAINING_SCH_ID = training_schedule_id });
            db.Close();
            return result;
        }
        #endregion

        #region ConfirmationEmail
        public string EmailConfirmation(IEnumerable<TMS040500BTrainingData> TrainingData)
        {
            string result="";
            string NullableData = null;
            var TrainingTopic = "";
            var TrainingShift = "";
            var location="";
            DateTime Sch_Fr = DateTime.Now;
            DateTime Sch_To = DateTime.Now;
            IDBContext db = DatabaseManager.Instance.GetContext();
            var DivMgr = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetDivMgr");
            foreach (TMS040500BTrainingData data in TrainingData)
            {
                TrainingTopic = data.TRAINING_TOPIC_NM;
                TrainingShift = data.TRAINING_SHIFT_NAME;
                location = data.LOCATION;
                Sch_Fr = data.TRAINING_SCH_FR;
                Sch_To = data.TRAINING_SCH_TO;
            }
            var process_id = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetProcessID");
            var sequence = 1;

            try
            {
                db.BeginTransaction();
                dynamic args = new
                {
                    pid = process_id,
                    seq = sequence,
                    func = "TMS040500B",
                    uid = DivMgr.ToString(),
                    result = "Success",
                    aTO = "taufika.utama@id.fujitsu.com",
                    param = TrainingTopic + "|" + location + "|" + TrainingShift + "|" + (Sch_Fr != Sch_To ? Sch_Fr.DayOfWeek + ", " + Sch_Fr.ToString("dd MMM yyyy") + " - " + Sch_To.DayOfWeek + ", " +Sch_To.ToString("dd MMM yyyy") : Sch_Fr.DayOfWeek + ", " + Sch_Fr.ToString("dd MMM yyyy")),
                    aCC = NullableData,
                    aBCC = NullableData,
                    aFOOT = "<br /><br /><br />Best Regards,<br />TPRO Administrator",
                    aSUBJ = "[TPRO] Approval Confirmation",
                    aFULL = NullableData,
                    aEMAIL = NullableData,
                    aTEXT = "<br />Dear Mr/Mrs/Ms. {0},<br /><br /> <strong>Kanban Approval Request</strong> <br /> Training Topic : {1} <br />"
                            +"Training Schedule: {4} <br /> Location - Shift: {2} - {3} <br /><br /> "
                            + "Click 'Respond' to Approve/Reject participant your division<br /> <a href='http://10.165.8.68:4140/TMS040100W'>[Respond]</a>"
                };
                db.Execute("TMS040500B/TMS040500BSendConfirmationEmail",args);
                db.CommitTransaction();
                result = "Success";
            }
            catch (Exception e)
            {
                db.AbortTransaction();
                result = e.Message.ToString();
            }
            finally
            {
                db.Close();
            }
            return result;
        }
        #endregion

        #region InvitationEmail
        public string InvitationEmailforTrainer(IEnumerable<TMS040500BTrainingData> TrainingData)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            
            string result = "";
            string NullableData = null;
            TMS040500BTrainingData dataList = new TMS040500BTrainingData();
            
            foreach (TMS040500BTrainingData data in TrainingData)
            {
                dataList.TRAINING_SCH_ID = data.TRAINING_SCH_ID;
                dataList.REG_PERIOD_ID = data.REG_PERIOD_ID;
                dataList.TRAINING_TYPE_ID = data.TRAINING_TYPE_ID;
                dataList.TRAINING_TOPIC_SEQ = data.TRAINING_TOPIC_SEQ;
                dataList.TRAINING_TOPIC_CD = data.TRAINING_TOPIC_CD;
                dataList.TRAINING_TOPIC_NM = data.TRAINING_TOPIC_NM;
                dataList.TRAINING_SCH_FR = data.TRAINING_SCH_FR;
                dataList.TRAINING_SCH_TO = data.TRAINING_SCH_TO;
                dataList.TRAINING_SHIFT = data.TRAINING_SHIFT;
                dataList.PASSING_POSTSCORE = data.PASSING_POSTSCORE;
                dataList.PASSING_ATTENDANCE = data.PASSING_ATTENDANCE;
                dataList.LOCATION = data.LOCATION;
                dataList.ROOM = data.ROOM;
                dataList.KANBAN_MONTH = data.KANBAN_MONTH;
                dataList.TRAINING_ADMIN = data.TRAINING_ADMIN;
                dataList.TRAINING_SCH_STS = data.TRAINING_SCH_STS;
            }

            var KanbanNo = dataList.TRAINING_TOPIC_CD + "/" + dataList.TRAINING_SCH_ID + "/" + "TIIN" + "/" + dataList.KANBAN_MONTH + "/" + dataList.TRAINING_SCH_FR.ToString("yyyy");
            var LocationEmailSend = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetSystemMaster", 
                new { SYS_CAT = "MASTER" , SYS_SUB_CAT = "SENDING_EMAIL", SYS_CD = "LOCATION_SENDING_EMAIL" });
            var LocTimeEmailSend = LocationEmailSend + ", " + DateTime.Now.ToString("dd MMMM yyyy");
            var emailMsgHeader = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetSystemMaster",
                new { SYS_CAT = "MASTER", SYS_SUB_CAT = "SENDING_EMAIL", SYS_CD = "MSG_HEADER_INV_TRAINER" });
            var emailMsgOpening = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetSystemMaster",
                new { SYS_CAT = "MASTER", SYS_SUB_CAT = "SENDING_EMAIL", SYS_CD = "MSG_OPENING_INV_TRAINER" });
            var emailMsgContent = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetSystemMaster",
                new { SYS_CAT = "MASTER", SYS_SUB_CAT = "SENDING_EMAIL", SYS_CD = "MSG_CONTENT_INV_TRAINER" });
            var emailMsgFooter = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetSystemMaster",
                new { SYS_CAT = "MASTER", SYS_SUB_CAT = "SENDING_EMAIL", SYS_CD = "MSG_FOOTER_INV_TRAINER" });

            IEnumerable<TMS040500BTrainerData> TrainerData = this.getTrainerData(dataList.TRAINING_SCH_ID);

            var process_id = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetProcessID");
            var sequence = 1;

            try
            {
                db.BeginTransaction();
                foreach (TMS040500BTrainerData item in TrainerData)
                {
                    var DivMgr = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetDivMgr");
                    dynamic args = new
                    {
                        pid = process_id,
                        seq = sequence,
                        func = "TMS040500B",
                        uid = DivMgr,
                        result = "Success",
                        aTO = "taufika.utama@id.fujitsu.com",
                        param = KanbanNo + "|" + LocTimeEmailSend + "|" + item.DIVISION + " / " + item.DEPARTEMENT + "|" + dataList.TRAINING_TOPIC_NM + "|" + item.TRAINER_ID + "|" + item.NAME + "|" + item.TRAINING_DATE.DayOfWeek + ", " + item.TRAINING_DATE.ToString("dd MMM yyyy") + "|" + (item.TRAINING_TIME == "AM" ? "08:00 - 12:00 WIB" : "13:00 - 17:00 WIB") + "|" + dataList.ROOM + ", " + dataList.LOCATION,
                        aCC = NullableData,
                        aBCC = NullableData,
                        aFOOT = "<br /><br /><br />Best Regards,<br />TPRO Administrator",
                        aSUBJ = "[TPRO] Undangan Permohonan Mengajar " + dataList.TRAINING_TOPIC_NM + " - " + dataList.TRAINING_SCH_FR.ToString("dd MMM yyyy"),
                        aFULL = NullableData,
                        aEMAIL = NullableData,
                        aTEXT = emailMsgHeader + emailMsgOpening + emailMsgContent + emailMsgFooter
                    };
                    db.Execute("TMS040500B/TMS040500BSendConfirmationEmail", args);
                    sequence += 1;
                }
                
                db.CommitTransaction();
                result = "Success";
            }
            catch (Exception e)
            {
                db.AbortTransaction();
                result = e.Message.ToString();
            }
            finally
            {
                db.Close();
            }
            return result;
        }

        public string InvitationEmailforParticipantMgr(IEnumerable<TMS040500BTrainingData> TrainingData)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();

            string result = "";
            string NullableData = null;
            TMS040500BTrainingData dataList = new TMS040500BTrainingData();

            foreach (TMS040500BTrainingData data in TrainingData)
            {
                dataList.TRAINING_SCH_ID = data.TRAINING_SCH_ID;
                dataList.REG_PERIOD_ID = data.REG_PERIOD_ID;
                dataList.TRAINING_TYPE_ID = data.TRAINING_TYPE_ID;
                dataList.TRAINING_TOPIC_SEQ = data.TRAINING_TOPIC_SEQ;
                dataList.TRAINING_TOPIC_CD = data.TRAINING_TOPIC_CD;
                dataList.TRAINING_TOPIC_NM = data.TRAINING_TOPIC_NM;
                dataList.TRAINING_SCH_FR = data.TRAINING_SCH_FR;
                dataList.TRAINING_SCH_TO = data.TRAINING_SCH_TO;
                dataList.TRAINING_SHIFT = data.TRAINING_SHIFT;
                dataList.PASSING_POSTSCORE = data.PASSING_POSTSCORE;
                dataList.PASSING_ATTENDANCE = data.PASSING_ATTENDANCE;
                dataList.LOCATION = data.LOCATION;
                dataList.ROOM = data.ROOM;
                dataList.KANBAN_MONTH = data.KANBAN_MONTH;
                dataList.TRAINING_ADMIN = data.TRAINING_ADMIN;
                dataList.TRAINING_SCH_STS = data.TRAINING_SCH_STS;
            }

            var KanbanNo = dataList.TRAINING_TOPIC_CD + "/" + dataList.TRAINING_SCH_ID + "/" + "TIIN" + "/" + dataList.KANBAN_MONTH + "/" + dataList.TRAINING_SCH_FR.ToString("yyyy");
            var LocationEmailSend = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetSystemMaster",
                new { SYS_CAT = "MASTER", SYS_SUB_CAT = "SENDING_EMAIL", SYS_CD = "LOCATION_SENDING_EMAIL" });
            var LocTimeEmailSend = LocationEmailSend + ", " + DateTime.Now.ToString("dd MMMM yyyy");
            var emailMsgHeader = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetSystemMaster",
                new { SYS_CAT = "MASTER", SYS_SUB_CAT = "SENDING_EMAIL", SYS_CD = "MSG_HEADER_INV_PARTMGR" });
            var emailMsgOpening = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetSystemMaster",
                new { SYS_CAT = "MASTER", SYS_SUB_CAT = "SENDING_EMAIL", SYS_CD = "MSG_OPENING_INV_PARTMGR" });
            var emailMsgContent = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetSystemMaster",
                new { SYS_CAT = "MASTER", SYS_SUB_CAT = "SENDING_EMAIL", SYS_CD = "MSG_CONTENT_INV_PARTMGR" });
            var emailMsgFooter = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetSystemMaster",
                new { SYS_CAT = "MASTER", SYS_SUB_CAT = "SENDING_EMAIL", SYS_CD = "MSG_FOOTER_INV_PARTMGR" });

            IEnumerable<TMS040500BDivisionOfTrainee> DivisionData = this.getParticipantDivisionManager(dataList.TRAINING_SCH_ID);
            

            var process_id = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetProcessID");
            var sequence = 1;

            try
            {
                db.BeginTransaction();
                foreach (TMS040500BDivisionOfTrainee item in DivisionData)
                {
                    var DivMgr = db.SingleOrDefault<string>("TMS040500B/TMS040500BgetDivMgr");
                    var DivTraineeData = db.Fetch<TMS040500BListTrainee>("TMS040500B/TMS040500BgetTraineeData", 
                        new{ TRAINING_SCH_ID = item.TRAINING_SCH_ID, DIVISION = item.DIVISION, DEPARTMENT = item.DEPARTEMENT });
                    var ListDivTraineeDataHTML = "";
                    foreach (TMS040500BListTrainee data in DivTraineeData)
                    {
                        string DivTraineeDataHTML = "<tr><td style=\"text-align:center;\">" + data.ROW_NUM + "</td><td style=\"text-align:center;\">" + data.NOREG + "</td><td>" + data.NAME + "</td><td>" + data.DIVISION + "</td><td>" + data.DEPARTEMENT + "</td></tr>";
                        ListDivTraineeDataHTML += DivTraineeDataHTML;
                    }
                    dynamic args = new
                    {
                        pid = process_id,
                        seq = sequence,
                        func = "TMS040500B",
                        uid = DivMgr,
                        result = "Success",
                        aTO = "taufika.utama@id.fujitsu.com",
                        param = KanbanNo + "|" + LocTimeEmailSend + "|" + item.DIVISION + " / " + item.DEPARTEMENT + "|" + dataList.TRAINING_TOPIC_NM + "|" + (dataList.TRAINING_SCH_FR != dataList.TRAINING_SCH_TO ? dataList.TRAINING_SCH_FR.DayOfWeek + ", " + dataList.TRAINING_SCH_FR.ToString("dd MMM yyyy") + " - " + dataList.TRAINING_SCH_TO.DayOfWeek + ", " + dataList.TRAINING_SCH_TO.ToString("dd MMM yyyy") : dataList.TRAINING_SCH_FR.DayOfWeek + ", " + dataList.TRAINING_SCH_FR.ToString("dd MMM yyyy")) + "|" + "08:00 - 17:00 WIB" + "|" + dataList.ROOM + ", " + dataList.LOCATION + "|" + ListDivTraineeDataHTML,
                        aCC = NullableData,
                        aBCC = NullableData,
                        aFOOT = "<br /><br /><br />Best Regards,<br />TPRO Administrator",
                        aSUBJ = "[TPRO] Undangan Mengikuti Training " + dataList.TRAINING_TOPIC_NM + " - " + dataList.TRAINING_SCH_FR.ToString("dd MMM yyyy"),
                        aFULL = NullableData,
                        aEMAIL = NullableData,
                        aTEXT = emailMsgHeader + emailMsgOpening + emailMsgContent + emailMsgFooter
                    };
                    db.Execute("TMS040500B/TMS040500BSendConfirmationEmail", args);
                    sequence += 1;
                }
                db.CommitTransaction();
                result = "Success";
            }
            catch (Exception e)
            {
                db.AbortTransaction();
                result = e.Message.ToString();
            }
            finally
            {
                db.Close();
            }
            return result;
        }
        #endregion
    }
}