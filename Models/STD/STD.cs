﻿/************************************************************************************************************
 * Program History :                                                                                        *
 *                                                                                                          *
 * Project Name     : TRAINING PLAINING & REGISTRATION ONLINE                                               *
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)                                      *
 * Function Id      : STD
 * Function Name    : STD Report
 * Function Group   : STD Report
 * Program Id       : GetReport
 * Program Name     : Get Function Name
 * Program Type     : Models
 * Description      : 
 * Environment      : .NET 4.0, ASP MVC 4.0
 * Author           : FID.Ine
 * Version          : 01.00.00
 * Creation Date    : 10/12/2015 19:48:00                                                                   *
 *                                                                                                          *
 * Update history		Re-fix date			Person in charge      Description								*
 * 1.0                  21/12/2015          FID.Riyanto           Add get message
 *                                                                                                          *
 * Copyright(C) 2016 - . All Rights Reserved                                                                *                              
 ************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Toyota.Common.Database;
using Toyota.Common.Web.Platform;

namespace AI070.Models.STD
{
    public class STDReport
    {
        public String FUNCTION_NM { get; set; }
        public String FUNCTION_ID { get; set; }
        public String MODULE_ID { get; set; }

        #region Singleton
        private static STDReport instance = null;
        public static STDReport Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new STDReport();
                }
                return instance;
            }
        }
        #endregion


        public String GetReport(string pFUNCTION_ID)
        {
            string functionName = "";
            IDBContext db = DatabaseManager.Instance.GetContext();
            try
            {
                functionName = db.SingleOrDefault<string>("STD/GetReport", new { FUNCTION_ID = pFUNCTION_ID });
            }
            catch (Exception e)
            {
            }
            db.Close();

            return functionName;
        }
    }

    public class STDMessage
    {
        public String MESSAGE_ID { get; set; }
        public String MESSAGE_TYPE { get; set; }
        public String MESSAGE_TEXT { get; set; }

        #region Singleton
        private static STDMessage instance = null;
        public static STDMessage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new STDMessage();
                }
                return instance;
            }
        }
        #endregion


        public IEnumerable<STDMessage> GetMessage(string p_MSG_ID)
        {
            IEnumerable<STDMessage> Message = null;
            IDBContext db = DatabaseManager.Instance.GetContext();
            try
            {
                Message = db.Fetch<STDMessage>("STD/GetMessage", new { MSG_ID = p_MSG_ID });
            }
            catch (Exception e)
            {
            }
            db.Close();

            return Message;
        }

        public string getTextMessage(string p_MSG_ID)
        {
            var message = STDMessage.Instance.GetMessage(p_MSG_ID);
            string msg = message.ToArray()[0].MESSAGE_ID + " : " + message.ToArray()[0].MESSAGE_TEXT;
            return msg;
        }
    }

    public class STDSystem
    {
        public String SysVal { get; set; }

        #region Singleton
        private static STDSystem instance = null;
        public static STDSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new STDSystem();
                }
                return instance;
            }
        }
        #endregion

        public String GetSystem(string sysCat, string sysSubCat, string sysCd)
        {
            String sysVal = "";
            IDBContext db = DatabaseManager.Instance.GetContext();
            try
            {
                sysVal = db.SingleOrDefault<string>("STD/GetSystem", new { SysCat = sysCat, SysSubCat = sysSubCat, SysCd = sysCd });
            }
            catch (Exception)
            {
            }
            db.Close();

            return sysVal;
        }
    }
    public class STDChecking
    {

        #region Singleton
        private static STDChecking instance = null;
        public static STDChecking Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new STDChecking();
                }
                return instance;
            }
        }
        #endregion

        public Boolean DuplicateChecking(string newCode, string sqlName)
        {
            int count = 0;
            IDBContext db = DatabaseManager.Instance.GetContext();
            try
            {
                dynamic args = new
                {
                    newCode = newCode
                };
                count = db.SingleOrDefault<int>(sqlName+"/DuplicateChecking", args);
                if (count > 0)
                    return true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                db.Close();
            }

            return false;
        }
        public Boolean ConcurrencyChecking(string oldChangedDate, string newChangedDate,out string message)
        {
            message = "";
            int count = 0;
            IDBContext db = DatabaseManager.Instance.GetContext();
            if (!oldChangedDate.Equals(newChangedDate, StringComparison.OrdinalIgnoreCase))
            {
                message = "MAI070STD050E";
                return true;
            }
            return false;
        }
    }

}