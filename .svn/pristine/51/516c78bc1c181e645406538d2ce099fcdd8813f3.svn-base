using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Xml;
using Toyota.Common.Web.Platform;
using AI070.Models;
using AI070.Models.Shared;
using AI070.Models.WP03004Master;

namespace AI070.Controllers
{
    public class WP03004Controller : PageController
    {

        ResultMessage rm = new ResultMessage();
        Message M = new Message();
        WP03004Repository R = new WP03004Repository();
        User U = new User();
        string username;
        string MESSAGE_TXT;
        string MESSAGE_TYPE;

        protected override void Startup()
        {
            try
            {
                Settings.Title = "Module Training";
                ViewData["Title"] = Settings.Title;
                GetDataHeader();
            }
            catch (Exception e)
            {
                Response.Redirect("authorized");
            }
        }

        public ActionResult GenerateMessage(string MSG_ID, string p_PARAM1, string p_PARAM2, string p_PARAM3, string p_PARAM4)
        {
            try
            {
                M.MSG_ID = MSG_ID;
                M.p_PARAM1 = p_PARAM1;
                M.p_PARAM2 = p_PARAM2;
                M.p_PARAM3 = p_PARAM3;
                M.p_PARAM4 = p_PARAM4;
                var res = M.getMessageTextWithFunctionSQL(M);
                MESSAGE_TXT = res[0].MSG_TEXT;
                MESSAGE_TYPE = res[0].MSG_TYPE;
            }
            catch (Exception M)
            {
                MESSAGE_TXT = M.Message.ToString();
                MESSAGE_TYPE = "Err";
            }
            return Json(new { MESSAGE_TXT, MESSAGE_TYPE }, JsonRequestBehavior.AllowGet);
        }

        #region Data Header
        public void GetDataHeader()
        {
            try
            {

            }
            catch (Exception M)
            {
                M.Message.ToString();
            }
        }
        #endregion

        #region Search Data
        public ActionResult Search_Data(
                                        int start,
                                        int display,
                                        String TITLE
                                        )
        {
            //Buat Paging//
            PagingModel_WP03004 pg = new PagingModel_WP03004(
                                                              R.getCountWP03004(TITLE),
                                                              start,
                                                              display
                                                            );

            //Munculin Data ke Grid//
            List<WP03004Master> List = R.getDataWP03004(pg.StartData, pg.EndData, TITLE).ToList();
            ViewData["DataWP03004"] = List;
            ViewData["PagingWP03004"] = pg;

            return PartialView("Datagrid_Data", pg.CountData);
        }
        #endregion

        #region Add
        [HttpGet]
        public virtual ActionResult Add()
        {
            ViewBag.form_type = "New";
            Settings.Title = "Add Data Module Training";
            ViewData["Title"] = Settings.Title;
            return PartialView("ADD");
        }
        #endregion

        #region Insert
        [ValidateInput(false)]
        [HttpPost]
        public virtual ActionResult Add(TrainingDTO trainingDTO)
            {
            string sts = null;
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;

                string FileName = Path.GetFileNameWithoutExtension(trainingDTO.File.FileName);

                //To Get File Extension  
                string FileExtension = Path.GetExtension(trainingDTO.File.FileName);

                //Add Current Date To Attached File Name  
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                String pathforSave = Path.Combine(Server.MapPath("~/Content/Upload/ModulTraining/"), FileName);

                trainingDTO.FilePath = "/Content/Upload/ModulTraining/" + FileName;

                var Exec = WP03004Repository.Insert(
                                                        trainingDTO.Title,
                                                        trainingDTO.Training_for,
                                                        trainingDTO.Description,
                                                        trainingDTO.FilePath,
                                                        Path.GetFileName(trainingDTO.FilePath),
                                                        trainingDTO.Content,
                                                        username);

                //To copy and save file into server.  
                trainingDTO.File.SaveAs(pathforSave);

                sts = Exec.STACK;
                message = Exec.LINE_STS;


            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }

            return Redirect(Request.UrlReferrer.ToString());

            //return PartialView("SearchCriteria");

        }
        #endregion

        #region Edit
        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            TrainingDTO data = WP03004Repository.GetDetailTraining(id);

            ViewBag.form_type = "Edit";
            Settings.Title = "Edit Data Module Training";
            ViewData["Title"] = Settings.Title;

            return PartialView("ADD", data);
        }
        #endregion

        #region Update Data
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Update(
            TrainingDTO trainingDTO)
        {

            if (Request.Files.Count > 0)
            {
                string g = "Test";
            }

            string stsRespon;
            var sts = new object();
            var message = new object();
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                string username = Lookup.Get<Toyota.Common.Credential.User>().Username;

                string FileName = Path.GetFileNameWithoutExtension(trainingDTO.File.FileName);

                //To Get File Extension  
                string FileExtension = Path.GetExtension(trainingDTO.File.FileName);

                //Add Current Date To Attached File Name  
                FileName = trainingDTO.Id + "-" + DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                String pathforSave = Path.Combine(Server.MapPath("~/Content/Upload/ModulTraining/"), FileName);

                trainingDTO.FilePath = "/Content/Upload/ModulTraining/" + FileName;

                var EXEC = R.Update_Data(
                                            trainingDTO.Id.ToString(),
                                            trainingDTO.Title,
                                            trainingDTO.Description,
                                            trainingDTO.FilePath,
                                            Path.GetFileName(trainingDTO.FilePath),
                                            trainingDTO.Content,
                                            username);

                trainingDTO.File.SaveAs(pathforSave);

                sts = EXEC[0].STACK;
                message = EXEC[0].LINE_STS;

            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        #endregion

        #region Delete Data
        public ActionResult Delete_Data(string DATA)
        {
            string stsRespon;
            var sts = new object();
            string message = null;
            username = Lookup.Get<Toyota.Common.Credential.User>().Username.ToString();

            try
            {
                var Datas = DATA.Split(',');
                for (int i = 0; i < Datas.Count(); i++)
                {
                    if (Datas[i] != "")
                    {
                        R.Delete_Data(Datas[i]);
                    }
                }

                sts = "TRUE";
                message = "Data has been successfully Deleted";
            }
            catch (Exception M)
            {
                sts = "false";
                message = M.Message.ToString();
            }
            return Json(new { sts, message }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Show Detail Training
        public ActionResult Show_Detail_Training(string id)
        {
            List<DetailTrainingModel> List = R.get_ShowDetailTraining(id).ToList();
            ViewData["DataWP03004"] = List;

            return PartialView("ModalForm");
        }
        #endregion
    }
}
