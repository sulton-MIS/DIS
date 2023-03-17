using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Web.Platform;
using Toyota.Common.Database;
using AD021.Models;

namespace AD021.Models.TMS040200W
{
    public class TMS040200WRepository
    {
        #region Singleton
        private static TMS040200WRepository instance = null;
        public static TMS040200WRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TMS040200WRepository();
                }
                return instance;
            }
        }
        #endregion

        #region GetData
        public IEnumerable<TMS040200W> GetTrainingSchedule(string pTraining_Schedule,string pTraining_Topic)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<TMS040200W>("TMS040200W/TMS040200WgetScheduleTraining",
                new {TRAINING_SCH_ID = pTraining_Schedule,TRAINING_TOPIC_CD=pTraining_Topic });
            db.Close();
            return result;
        }
        public IEnumerable<TMS040200W> GetParticipant(string pTraining_Schedule,string pUser_Role)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<TMS040200W>("TMS040200W/TMS040200WgetParticipant",
                new { TrainingSchedule = pTraining_Schedule, USER_ROLE=pUser_Role });
            db.Close();
            return result;
        }
        public IEnumerable<TMS040200W> GetWaitingList(string pTraining_Schedule)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<TMS040200W>("TMS040200W/TMS040200WgetWaiting",
                new { TrainingSchedule = pTraining_Schedule });
            db.Close();
            return result;
        }
        public IEnumerable<TMS040200WHeader> GetHeaderData(string pTraining_TOPIC, string pTraining_Schedule)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<TMS040200WHeader>("TMS040200W/TMS040200WgetHeaderData",
                new { TRAINING_TOPIC_CD = pTraining_TOPIC, TRAINING_SCH_ID = pTraining_Schedule });
            db.Close();
            return result;
        }
        public IEnumerable<TMS040200W> GetUserData(string Noreg)
        {
            IDBContext db = DatabaseManager.Instance.GetContext();
            var result = db.Fetch<TMS040200W>("TMS040200W/TMS040200WgetDataUser", new { NOREG = Noreg });
            db.Close();
            return result;
        }
        #endregion

        #region Approval
        public String doUpdateParticipant(IEnumerable<TMS040200W> listData, int reject, IEnumerable<TMS040200W> listTrainer,int trainer_reject,string schedID,string topic_CD,string userLogin)
        {
            string result = "";
            var TrainingID = schedID;
            var TrainingSts = '4';
            var TrainingTopic = topic_CD;
            var PaxSts = "3";
            IDBContext db = DatabaseManager.Instance.GetContext();
            try
            {
                db.BeginTransaction();
                if (listData != null)
                {
                    foreach (TMS040200W data in listData)
                    {
                        dynamic args = new
                        {
                            TRAINING_SCH_ID = data.TRAINING_SCH_ID,
                            NOREG = data.NOREG,
                            PAX_STS = data.PAX_STS,
                            USERLOGIN = userLogin
                        };
                        db.Execute("TMS040200W/TMS040200WUpdateParticipant", args);
                    }
                }
                if (reject != 0)
                {
                    db.Execute("TMS040200W/TMS040200WUpdateWaitingList",
                           new { AFFECTED = reject, TRAINING_SCH_ID = TrainingID, TRAINING_TOPIC_CD = TrainingTopic, TRAINING_SCH_STS = TrainingSts, PAX_STS = PaxSts, USERLOGIN=userLogin });
                }
                else
                {
                    db.Execute("TMS040200W/TMS040200WChangeColorSch",
                        new { TRAINING_SCH_STS=TrainingSts, TRAINING_SCH_ID=TrainingID,TRAINING_TOPIC_CD=TrainingTopic,USERLOGIN = userLogin });
                }
                if (listTrainer != null)
                {
                    foreach (TMS040200W data in listTrainer)
                    {
                        TrainingID = data.TRAINING_SCH_ID;
                        TrainingTopic = data.TRAINING_TOPIC_CD;
                        dynamic args = new
                        {
                            TRAINING_SCH_ID = data.TRAINING_SCH_ID,
                            TRAINER_ID = data.TRAINER_ID,
                            TRAINING_BU_STS = data.TRAINER_BU_STS,
                            TRAINING_TIME = data.TRAINING_TIME,
                            TRAINING_DAY = data.TRAINING_DAY,
                            USERLOGIN = userLogin
                        };
                        db.Execute("TMS040200W/TMS040200WUpdateTrainer", args);
                    }
                    if (trainer_reject != 0)
                    {
                        db.Execute("TMS040200W/TMS040200WTrainerBackup", new {
                            AFFECTED = trainer_reject,
                            PAX_STS = PaxSts,
                            TRAINING_SCH_ID = TrainingID,
                            TRAINING_TOPIC_CD=TrainingTopic,
                            USERLOGIN = userLogin
                        });
                    }
                }
                db.CommitTransaction();
                result = "1";
            }
            catch (Exception e)
            {
                db.AbortTransaction();
                result = "0";
            }
            db.Close();
            return result;
        }
        public String doUpdateParticipantByDivMng(IEnumerable<TMS040200W> listData, int reject, IEnumerable<TMS040200W> listTrainer, int trainer_reject, string schedID, string topic_CD,string userlogin)
        {
            string result = "";
            var TrainingID = schedID;
            var TrainingSts = '5';
            var TrainingTopic = topic_CD;
            var PaxSts = "4";
            IDBContext db = DatabaseManager.Instance.GetContext();
            try
            {
                db.BeginTransaction();
                if (listData != null)
                {
                    foreach (TMS040200W data in listData)
                    {
                        dynamic args = new
                        {
                            TRAINING_SCH_ID = data.TRAINING_SCH_ID,
                            NOREG = data.NOREG,
                            PAX_STS = data.PAX_STS,
                            USERLOGIN = userlogin
                        };
                        db.Execute("TMS040200W/TMS040200WUpdateParticipant", args);
                    }
                }
                if (reject != 0)
                {
                    db.Execute("TMS040200W/TMS040200WUpdateWaitingListbyDivMgr",
                         new { AFFECTED = reject, TRAINING_SCH_ID = TrainingID, TRAINING_SCH_STS = TrainingSts, TRAINING_TOPIC_CD = TrainingTopic, PAX_STS=PaxSts, USERLOGIN=userlogin });
                }
                if (listTrainer != null)
                {
                    foreach (TMS040200W data in listTrainer)
                    {
                        TrainingID = data.TRAINING_SCH_ID;
                        dynamic args = new
                        {
                            TRAINING_SCH_ID = data.TRAINING_SCH_ID,
                            TRAINER_ID = data.TRAINER_ID,
                            TRAINING_BU_STS = data.TRAINER_BU_STS,
                            TRAINING_TIME = data.TRAINING_TIME,
                            TRAINING_DAY = data.TRAINING_DAY,
                            USERLOGIN = userlogin
                        };
                        db.Execute("TMS040200W/TMS040200WUpdateTrainer", args);
                    }
                    if (trainer_reject != 0)
                    {
                        db.Execute("TMS040200W/TMS040200WTrainerBackup", new
                        {
                            AFFECTED = trainer_reject,
                            PAX_STS = PaxSts,
                            TRAINING_SCH_ID = TrainingID,
                            TRAINING_TOPIC_CD=TrainingTopic
                        });
                    }
                    //db.Execute("TMS040200W/TMS040200WInsertTrainer",
                    //    new { TRAINING_SCH_ID = TrainingID });
                }
                db.CommitTransaction();
                result = "1";
            }
            catch (Exception e)
            {
                db.AbortTransaction();
                result = "0";
            }
            int check_participant = db.SingleOrDefault<int>("TMS040200W/TMS040200WcheckParticipant", new { TRAINING_SCH_ID = TrainingID });
            int check_reject = db.SingleOrDefault<int>("TMS040200W/TMS040200WcheckReject", new { TRAINING_SCH_ID = TrainingID });
            int check_trainer = db.SingleOrDefault<int>("TMS040200W/TMS040200WcheckTrainer", new { TRAINING_SCH_ID = TrainingID });
            int reject_trainer = db.SingleOrDefault<int>("TMS040200W/TMS040200WtrainerReject", new { TRAINING_SCH_ID = TrainingID });
            if (check_participant == 0)
            {
                if (check_reject == 0)
                {
                    db.Execute("TMS040200W/TMS040200WChangeColorSch",
                    new { TRAINING_SCH_STS = '7', TRAINING_SCH_ID = TrainingID, TRAINING_TOPIC_CD = TrainingTopic, USERLOGIN=userlogin });
                }
                else
                {
                    if (reject_trainer == 0)
                    {
                        db.Execute("TMS040200W/TMS040200WChangeColorSch",
                    new { TRAINING_SCH_STS = '7', TRAINING_SCH_ID = TrainingID, TRAINING_TOPIC_CD = TrainingTopic, USERLOGIN = userlogin });
                    }
                    else if (check_trainer == 0 && reject_trainer != 0)
                    {
                        db.Execute("TMS040200W/TMS040200WChangeColorSch",
                        new { TRAINING_SCH_STS = TrainingSts, TRAINING_SCH_ID = TrainingID, TRAINING_TOPIC_CD = TrainingTopic, USERLOGIN = userlogin });
                    }
                }
            }
            db.Close();
            return result;
        }

        public String doUpdateParticipantByPA(IEnumerable<TMS040200W> listData,string userlogin)
        {
            string result = "";
            var PaxSTS = "";
            var TrainingTopic = "";
            var TrainingID = "";
            IDBContext db = DatabaseManager.Instance.GetContext();
            try
            {
                db.BeginTransaction();
                foreach (TMS040200W data in listData)
                {
                    TrainingID = data.TRAINING_SCH_ID;
                    TrainingTopic = data.TRAINING_TOPIC_CD;
                    PaxSTS = data.PAX_STS;
                    var TrainingSts = "6";
                    dynamic args = new
                    {
                        TRAINING_SCH_ID = data.TRAINING_SCH_ID,
                        PAX_STS=data.PAX_STS,
                        USERLOGIN = userlogin
                    };
                    db.Execute("TMS040200W/TMS040200WUpdateParticipantByPA", args);
                    db.Execute("TMS040200W/TMS040200WUpdateTrainerByPA", args);
                    db.Execute("TMS040200W/TMS040200WChangeColorSch",
                       new { TRAINING_SCH_STS = TrainingSts, TRAINING_SCH_ID = TrainingID, TRAINING_TOPIC_CD = TrainingTopic, USERLOGIN=userlogin });
                    result = "1";
                    if (PaxSTS == "7")
                    {
                        var TrainingReject = "7";
                        db.Execute("TMS040200W/TMS040200WUpdateTrainerByPA",args);
                        db.Execute("TMS040200W/TMS040200WChangeColorSch",
                            new { TRAINING_SCH_STS = TrainingReject, TRAINING_SCH_ID = TrainingID, TRAINING_TOPIC_CD = TrainingTopic, USERLOGIN=userlogin });
                        result = "2";
                    }
                }
                db.CommitTransaction();
                if (result == "1")
                {
                    db.Execute("TMS040200W/TMS040200WInsertTrainer", new { TRAINING_SCH_ID = TrainingID, USERLOGIN = userlogin });
                }
               // result = "1";
            }
            catch (Exception e)
            {
                db.AbortTransaction();
                result = "0";
            }
            db.Close();
            return result;
        }
    }
        #endregion
}