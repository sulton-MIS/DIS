/************************************************************************************************************
 * Program History :                                                                                        *
 *                                                                                                          *
 * Project Name     : TRAINING PLAINING & REGISTRATION ONLINE                                               *
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)                                      *
 * Function Id      : TMS040500W                                                                            *
 * Function Name    : Email Sending Batch                                                                   *
 * Function Group   : Registration Control                                                                  *
 * Program Id       : TMS040500BController                                                                  *
 * Program Name     : Emai Sending Batch Controller                                                         *
 * Program Type     : Controller                                                                            *
 * Description      :                                                                                       *
 * Environment      : .NET 4.0, ASP MVC 4.0                                                                 *
 * Author           : FID.Arri                                                                              *
 * Version          : 01.00.00                                                                              *
 * Creation Date    : 17/12/2015 11:51:40                                                                   *
 *                                                                                                          *
 * Update history		Re-fix date				Person in charge				Description					*
 *                                                                                                          *
 * Copyright(C) 2015 - Fujitsu Indonesia. All Rights Reserved                                               *                          
 ************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toyota.Common.Web.Platform;
using AD021.Models;
using AD021.Models.AD021000100W;
using AD021.Models.TMS040200W;
using AD021.Models.TMS040500B;

namespace AD021.Controllers
{
    public class TMS040500BController : PageController
    {
        public String Name { get { return "TMS040500B"; } }
        protected override void Startup()
        {
            Settings.Title = "Email Sending Batch";
            Settings.ControllerName = "TMS040500B";
        }

        #region Singleton
        private static TMS040500BController instance = null;
        public static TMS040500BController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TMS040500BController();
                }
                return instance;
            }
        }
        #endregion

        public String ForgetPassword(IEnumerable<AD021000100W> UserData) {
            String result = "";
            foreach (AD021000100W data in UserData)
            {
                result = TMS040500BRepository.Instance.EmailForgetPassword(data.USER_ID, data.USER_PASS, data.EMAIL, data.USER_NAME);
            }
            return result;
        }

        public String InvitationEmail(string schedID, string topicCD)
        {
            string result = "";
            string training_topic = topicCD;
            string training_schedule = schedID;
            var training_data = TMS040500BRepository.Instance.getTrainingData(training_topic, training_schedule);
            if (training_data.ToArray().Length != 0)
            {
                ViewData["Training"] = training_data;
                result = TMS040500BRepository.Instance.InvitationEmailforTrainer(training_data);
                result = TMS040500BRepository.Instance.InvitationEmailforParticipantMgr(training_data);
            }
            return result;
        }

        public String ConfirmationEmail(string schedID, string topicCD)
        {
            string result = "";
            string training_topic = topicCD;
            string training_schedule = schedID;
            var training_data = TMS040500BRepository.Instance.getTrainingData(training_topic, training_schedule);
            if (training_data.ToArray().Length != 0)
            {
                ViewData["Training"] = training_data;
                result = TMS040500BRepository.Instance.EmailConfirmation(training_data);
            }
            return result;
        }
    }
}
