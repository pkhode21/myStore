using idea_BLL.Model.User;
using idea_DAL.UserOps;
using System;
using System.Web.Mvc;

namespace idea_UX.Controllers.Utility
{
    #region Description

    /*
    ------This controller will handle all the user account/registration activities-------
    ------1)New User Registration-------------
    ------2)Email Verification----------------
    ------3)Forgot Password--------------------
    ------4)Reset New Password-----------------
    */

    #endregion Description

    public class RegistrationController : Controller
    {
        public String Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                UserHandler dalObj = new UserHandler();
                var message = dalObj.AddNewUser(newUser);
                return message;
            }
            else
            {
                return "Error..Please try again";

            }
        }


        public String VerifiyEmail()
        {
            return "";
        }

        public String ForgotPassword()
        {
            return "";
        }

        public String ResetPassword()
        {
            return "";
        }

        
    }
}