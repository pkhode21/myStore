using idea_BLL.EntityMapper;
using idea_BLL.Model.User;
using idea_DAL.Emails;
using System;
using System.Collections.Generic;

namespace idea_DAL.UserOps
{
    #region Summary

    /*
    ------This class will handle user related activities----------------
    -------------1) Add New User - /user/register-----------------------
    -------------2) Login User - /user/login----------------------------
    -------------3) User/Email Verification - /user/verification--------
    -------------4) Forgot Password - /user/register--------------------
    -------------5) Reset Password - /user/register---------------------

    */

    #endregion Summary

    public class UserHandler
    {
        //user/register - Register New User
        public string AddNewUser(User newUserDetails)
        {
            using (myStore_databaseContext entities = new myStore_databaseContext())
            {
                using (var dbTransaction = entities.Database.BeginTransaction())
                {
                    try
                    {
                        //add user details
                        User objUser = new User();
                        objUser.UserFirstName = newUserDetails.UserFirstName;
                        objUser.UserLastName = newUserDetails.UserLastName;
                        objUser.UserEmailAddress = newUserDetails.UserEmailAddress;
                        objUser.UserPassword = newUserDetails.UserPassword;
                        objUser.IsAccountVerified = false;
                        objUser.LatestLoggedIn = DateTime.Now;
                        objUser.UserType = newUserDetails.UserType;
                        entities.Users.Add(newUserDetails);
                        entities.SaveChanges();

                        //generate verfication token for the user
                        UserToken objToken = new UserToken();
                        objToken.TokenID = Guid.NewGuid();
                        objToken.UserID = objUser.UserID;
                        objToken.TokenType = 1; //email verification token

                        entities.UserTokens.Add(objToken);
                        entities.SaveChanges();

                        //send verfication email.
                        EmailDetail objEmail = new EmailDetail();
                        objEmail.DisplayName = "myStore";
                        objEmail.RecipientEmail = newUserDetails.UserEmailAddress;
                        objEmail.MailSubjectLine = "Activate your account";
                        objEmail.MailPurpose = 2;
                        objEmail.RecipientsName = newUserDetails.UserFirstName;

                        bool flag = EmailHandler.SendEmail(objEmail);
                        if(flag)
                        {
                            return "Thanks For Signing Up! \nPlease check our message that we just sent to " + newUserDetails.UserEmailAddress + " \nPlease cross check your spam folder.";
                        }
                        else
                        {
                            return "Error..Please try again";
                        }
                        
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                        return "Error..Please try again";
                    }
                    finally
                    {
                        dbTransaction.Dispose();
                    }
                }
            }
        }
    }
}