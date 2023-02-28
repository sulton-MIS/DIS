using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Toyota.Common.Web.Platform;
using Toyota.Common.Database;
using AI070.Models;
using Toyota.Common.Credential;
using System.IO;
using System.Net;



namespace AI070.Controllers
{
    public class BaseController : PageController
    {
        public User UserHelper
        {
            get
            {

                User u = Lookup.Get<User>();
                return u;
            }
        }
        public UserInfo UserInfo
        {
            get
            {

                var userInfo = UserInfoRepository.Instance.GetUserInfo(UserHelper.Username);
                
                return userInfo;
            }
        }

        protected override void Startup()
        {
            ViewData["UserInfo"] = UserInfo;
            ViewData["MenuInfoList"] = MenuInfoRepository.Instance.GetMenuInfo(UserHelper.Username);
            base.Startup();
            
            //ViewData["UserPlantInfo"] = UserInfoRepository.Instance.GetUserPlantInfo(UserHelper.Username);
        }

        public List<AreaInfo> AreaInfo
        {
            get
            {
                var areaInfo = AreaInfoRepository.Instance.GetAreaInfo();

                return areaInfo;
            }
        }

        public MenuInfo MenuInfoList
        {
            get
            {
                var MenuInfo = MenuInfoRepository.Instance.GetMenuInfo(UserHelper.Username);

                return MenuInfo;
            }
        }

        //public string GetPathsOfAllDirectoriesAbove()
        //{
        //    return "";
        //}

    }

}
