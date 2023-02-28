/************************************************************************************************************
 * Program History :                                                                                        *
 *                                                                                                          *
 * Project Name     : TRAINING PLAINING & REGISTRATION ONLINE                                               *
 * Client Name      : PT. TMMIN (Toyota Manufacturing Motor Indonesia)                                      *
 * Function Id      : TMS040500W                                                                            *
 * Function Name    : Email Sending Batch                                                                   *
 * Function Group   : Registration Control                                                                  *
 * Program Id       : TMS040500B                                                                            *
 * Program Name     : Emai Sending Batch Model                                                              *
 * Program Type     : Model                                                                                 *
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

namespace AD021.Models.TMS040500B
{
    public class TMS040500B
    {
        public Int32 Process_ID { get; set; }
        public String Function_ID { get; set; }
        public String User_ID { get; set; }
        public String Username { get; set; }
        public String Result { get; set; }
        public String Param { get; set; }
        public String Email_to { get; set; }
        public String Email_cc { get; set; }
        public String Email_bcc { get; set; }
        public String Email_footer { get; set; }
        public String Email_subject { get; set; }
        public String Email_err_link { get; set; }
        public String Email_body { get; set; }
    }
}