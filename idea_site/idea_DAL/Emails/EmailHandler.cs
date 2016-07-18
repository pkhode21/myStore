using idea_BLL.EntityMapper;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace idea_DAL.Emails
{
    public static class EmailHandler
    {
        public static bool SendEmail(EmailDetail emailDetails, string attachment = null)
        {
            try
            {
                bool flag = false;
                string adminEmailId = ""; string adminPassword = "";

                emailDetails.ReplyToEmailAddress = emailDetails.ReplyToEmailAddress == null ? emailDetails.SenderEmailAddress : emailDetails.ReplyToEmailAddress;

                MailMessage mailObj = new MailMessage();
                switch (emailDetails.MailPurpose)
                {
                    case 1:
                        {
                            //reset password
                            mailObj.Subject = "Resest your password";
                            mailObj.Body = ComposePasswordReset(emailDetails.MailMessage);
                            adminEmailId = "reset_password@d-studio.co.in";
                            adminPassword = "Nowf6*08";
                            break;
                        }
                    case 2:
                        {
                            //verification mail
                            mailObj.Subject = "Welcome Email";

                            mailObj.Body = ComposeVerficationMailBody(emailDetails.MailMessage, "emailDetails.RecipientName");
                            emailDetails.SenderName = "dStudio";
                            adminEmailId = "welcome@d-studio.co.in";
                            adminPassword = "dNj4r_88";
                            break;
                        }
                    case 3:
                        {
                            //order summary email to customer/seller
                            mailObj.Subject = emailDetails.MailSubjectLine;
                            mailObj.Body = ComposeOrderEmailBody(emailDetails.OrderDetails);

                            adminEmailId = "jobs@d-studio.co.in";
                            adminPassword = "Tnc4w58^";
                            break;
                        }

                    default:
                        {
                            //other
                            mailObj.Subject = emailDetails.MailSubjectLine;
                            mailObj.Body = ComposeMessage(emailDetails.MailMessage);

                            adminEmailId = "support@d-studio.co.in";
                            adminPassword = "ePnu2?88";

                            break;
                        }
                }

                mailObj.IsBodyHtml = true;
                mailObj.Priority = System.Net.Mail.MailPriority.High;

                //TO
                  mailObj.To.Add(emailDetails.RecipientEmail);

                //CC
                if (emailDetails.CC != null)
                {
                    foreach (var emailId in emailDetails.CC)
                    {
                        //patch
                        if (emailId != null && emailId != "" && emailId != "null")
                        {
                            mailObj.CC.Add(emailId);
                        }
                    }
                }
                //Bcc

                if (emailDetails.Bcc != null)
                {
                    foreach (var emailId in emailDetails.Bcc)
                    {
                        mailObj.Bcc.Add(emailId);
                    }
                }

                //Add Attachment
                if (attachment != null)
                {
                    Attachment attachmentData = new Attachment(attachment, MediaTypeNames.Application.Pdf);
                    ContentDisposition disposition = attachmentData.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(attachment);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(attachment);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(attachment);
                    // Add the file attachment to this e-mail message.
                    mailObj.Attachments.Add(attachmentData); //Attachment 1
                    mailObj.Attachments.Dispose();
                }

                mailObj.ReplyToList.Add(emailDetails.ReplyToEmailAddress);
                //From
                mailObj.From = new MailAddress(adminEmailId, emailDetails.DisplayName);
                using (SmtpClient mailClient = new SmtpClient())
                {
                    mailClient.Host = "d-studio.co.in";
                    mailClient.Port = 587;
                    mailClient.EnableSsl = false;
                    mailClient.UseDefaultCredentials = true;
                    mailClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    //mailClient.Credentials = new NetworkCredential("chetan.gupta21@gmail.com", "livedlifeg");

                    mailClient.Credentials = new NetworkCredential(adminEmailId, adminPassword);
                    MailAddress msg = new MailAddress(emailDetails.ReplyToEmailAddress);
                    mailClient.Timeout = 500000;
                    mailClient.Send(mailObj);
                    flag = true;
                }

                return flag;
            }
            catch (Exception ex)
            {
                //ExceptionHandling.LogException(ex);
                return false;
            }
        }

        #region Private Members

        private static string ComposeMailBody(string msg)
        {
            StringBuilder mailBody = new StringBuilder();
            mailBody.Append("<div style='font-family:Verdana; font-size:12px;'>");
            mailBody.Append("Hari Om");
            mailBody.Append("<br/>");
            mailBody.Append("Jai SiyaRam");
            mailBody.Append("<br/>");
            mailBody.Append("<br/>");
            mailBody.Append(msg);
            mailBody.Append("<br/>");
            mailBody.Append("<a href='javascript:void(0)' title='Please click to accept the invitation' style='padding:16px 25px 16px 25px;  background-color:#449d44; color:#fff;text-align:center;text-decoration:none;font-family:verdana; border-radius:10px; font-size:16px;'>Accept </a>");
            mailBody.Append(" <a href='javascript:void(0)' title='Please click to ignore the invitation' style='padding:16px 25px 16px 25px;  margin-left:25px;background-color:#d9534f; color:#fff;text-align:center;text-decoration:none;font-family:verdana; border-radius:10px; font-size:16px;'>Ignore </a>");
            mailBody.Append("<span style='font-size:10px'>");
            mailBody.Append(" DISCLAIMER: This e-mail (including any attachments) may contain confidential, proprietary or legally privileged information. It is intended solely for the use of the addressee(s) and it should not be used by anyone who is not the original intended recipient. If you are not the intended recipient of this e-mail, please delete it, destroy all copies and inform the sender by return e-mail. Its unauthorized use, disclosure, storage or copying is strictly prohibited. This e-mail may contain viruses. You must do your own virus check before opening the e-mail or the attachments. dStudio is not liable for any damage sustained");
            mailBody.Append("</span");
            mailBody.Append("</div>");
            mailBody.Append("<br/>");
            mailBody.Append("<style type='text/css'>.btn {padding:10px;color:#fff;border-radius:10px;.btn:hover {opacity:0.5;}.primary {background: #f00;}</style>");
            mailBody.Append("Jai Shree Krishna");
            return mailBody.ToString();
        }

        private static string ComposeMessage(string msg)
        {
            StringBuilder mailBody = new StringBuilder();
            mailBody.Append("<div style='font-family:Kalinga,Verdana;font-size:14px; font-weight:normal;font-size:14px;'>");
            mailBody.Append("<table style='width: 600px; margin: 0 auto; color: #333; font-size:14px;'>");
            mailBody.Append("<tr><td>");
            mailBody.Append(msg);
            mailBody.Append("</td></tr>");

            //footer
            mailBody.Append("<tr><td>");
            mailBody.Append("<ul style='border-top:1.7px solid rgba(0,0,0,0.3)'>");
            mailBody.Append("<li><p>");
            mailBody.Append("<span style='font-size:10px'>");
            mailBody.Append(" DISCLAIMER: This e-mail (including any attachments) may contain confidential, proprietary or legally privileged information. It is intended solely for the use of the addressee(s) and it should not be used by anyone who is not the original intended recipient. If you are not the intended recipient of this e-mail, please delete it, destroy all copies and inform the sender by return e-mail. Its unauthorized use, disclosure, storage or copying is strictly prohibited. This e-mail may contain viruses. You must do your own virus check before opening the e-mail or the attachments. <b><a href='http://www.d-studio.co.in' title='dStudio'> dStudio </a> </b> is not liable for any damage sustained");
            mailBody.Append("</span>");
            mailBody.Append("</p></li>");
            //term 2
            mailBody.Append("<li><p>");
            mailBody.Append("<span style='font-size:11px'>");
            mailBody.Append("Please directly reply to email in case you like to speak to the concerned person");
            mailBody.Append("</span>");
            mailBody.Append("</p></li>");
            //term 3
            mailBody.Append("<li><p>");
            mailBody.Append("<span style='font-size:10px'>");
            mailBody.Append("In case of any fraud or phishing,please revert to complain@d-studio.co.in");
            mailBody.Append("</span>");
            mailBody.Append("</p></li>");
            mailBody.Append("</ul>");
            mailBody.Append("</td></tr>");

            mailBody.Append("<table>");
            return mailBody.ToString();
        }

        private static string ComposeVerficationMailBody(string tokenId, string receipientName)
        {
            StringBuilder mailBody = new StringBuilder();
            mailBody.Append("<div style='font-family:Kalinga,Verdana;font-size:14px; font-weight:normal;font-size:14px;'>");
            mailBody.Append("<table style='width: 600px; margin: 0 auto; color: #333; font-size:14px;'>");
            mailBody.Append("<tr><td>");
            mailBody.Append("<p style='border-bottom:1.7px solid #eee;'>");
            mailBody.Append("Dear " + receipientName + ",<br/>We would like to thank you for registering with us. You are just one step away to enter into dStudio. <br/> Please click the below link to verify your email address to activate your account and login to continue.");
            mailBody.Append("</td></tr>");
            mailBody.Append("<tr><td>");
            mailBody.Append("<a href='http://www.d-studio.co.in/account/verification/" + tokenId + "' title='Click to get started with dStudio' style='cursor: pointer; background: #5bc0de; color: #fff; display: inline-block; padding: 10px 20px; margin-bottom: 0; font-size: 14px; font-weight: 400; line-height: 1.42857143; text-align: center; white-space: nowrap; vertical-align: middle; border: 1px solid transparent; border-radius: 4px; margin-right:15px; text-decoration:none;'> Activate your account </a>");
            mailBody.Append("</td></tr>");
            mailBody.Append("<tr><td>");
            mailBody.Append("<tr><td>");
            mailBody.Append("<p style='background:#ff0;'>Please add us to your mail contact list to avoid being spammed.We assure that we will not be sending any undigesting emails.");
            mailBody.Append("</td></tr>");
            mailBody.Append("</td></tr>");
            mailBody.Append("<tr><td>");
            mailBody.Append("Thanks & Regards, <br/> dStudio <br/>");
            mailBody.Append("</td></tr>");

            //close table
            mailBody.Append("<tr><td>");
            mailBody.Append("</td></tr>");
            mailBody.Append("<table>");
            //footer

            //term 1
            mailBody.Append("<ul style='border-top:1.7px solid rgba(0,0,0,0.3)'>");
            mailBody.Append("<li><p>");
            mailBody.Append("<span style='font-size:10px'>");
            mailBody.Append(" DISCLAIMER:This e-mail (including any attachments) may contain confidential, proprietary or legally privileged information. It is intended solely for the use of the addressee(s) and it should not be used by anyone who is not the original intended recipient. If you are not the intended recipient of this e-mail, please delete it, destroy all copies and inform the sender by return e-mail. Its unauthorized use, disclosure, storage or copying is strictly prohibited. This e-mail may contain viruses. You must do your own virus check before opening the e-mail or the attachments. dStudio is not liable for any damage sustained");
            mailBody.Append("</span>");
            mailBody.Append("</p></li>");
            //term 2
            mailBody.Append("<li><p>");
            mailBody.Append("<span style='font-size:10px'>");
            mailBody.Append("Please donot forward this mail to anyone,as this mail is intended uniquely for you.");
            mailBody.Append("</span>");
            mailBody.Append("</p></li>");
            //term 3
            mailBody.Append("<li><p>");
            mailBody.Append("<span style='font-size:10px'>");
            mailBody.Append("By submitting your verification,we consider that you have read & accept our T&C.<a href='http://d-studio.co.in/privacy' title='Please read our privacy policies before activation'>Privacy</a><a href='http://d-studio.co.in/cookies' title='Please read our cookies policy before activation' style='margin-left:5px;'>Cookies</a>");
            mailBody.Append("</span>");
            mailBody.Append("</p></li>");
            //term 4
            mailBody.Append("<li><p>");
            mailBody.Append("<span style='font-size:10px'>");
            mailBody.Append("In case of any fraud or phishing,please revert to complain@d-studio.co.in");
            mailBody.Append("</span>");
            mailBody.Append("</p></li>");

            mailBody.Append("</ul>");

            mailBody.Append("</div>");
            return mailBody.ToString();
        }

        private static string ComposePasswordReset(string tokenId)
        {
            StringBuilder mailBody = new StringBuilder();
            mailBody.Append("<div style='font-family:Kalinga,Verdana;font-size:14px; font-weight:normal;font-size:14px;'>");
            mailBody.Append("<table style='width: 600px; margin: 0 auto; color: #333; font-size:14px;'>");
            mailBody.Append("<tr><td>");
            mailBody.Append("<p style='border-bottom:1.7px solid #eee;'>");
            mailBody.Append("Dear User,<br/>As per your request to reset your password,please use the below link to reset.");
            mailBody.Append("</td></tr>");
            mailBody.Append("<tr><td>");
            mailBody.Append("<a href='http://www.d-studio.co.in/password/reset/" + tokenId + "' title='Click to Change your password' style='cursor: pointer; background: #5bc0de; color: #fff; display: inline-block; padding: 10px 20px; margin-bottom: 0; font-size: 14px; font-weight: 400; line-height: 1.42857143; text-align: center; white-space: nowrap; vertical-align: middle; border: 1px solid transparent; border-radius: 4px; margin-right:15px; text-decoration:none;'> Reset Password </a>");
            mailBody.Append("</td></tr>");
            mailBody.Append("<tr><td>");
            mailBody.Append("</td></tr>");
            //footer
            mailBody.Append("<tr><td>");
            //term 1
            mailBody.Append("<ul style='border-top:1.7px solid rgba(0,0,0,0.3)'>");
            mailBody.Append("<li><p>");
            mailBody.Append("<span style='font-size:10px'>");
            mailBody.Append(" DISCLAIMER:This e-mail (including any attachments) may contain confidential, proprietary or legally privileged information. It is intended solely for the use of the addressee(s) and it should not be used by anyone who is not the original intended recipient. If you are not the intended recipient of this e-mail, please delete it, destroy all copies and inform the sender by return e-mail. Its unauthorized use, disclosure, storage or copying is strictly prohibited. This e-mail may contain viruses. You must do your own virus check before opening the e-mail or the attachments. dStudio is not liable for any damage sustained");
            mailBody.Append("</span>");
            mailBody.Append("</p></li>");
            //term 2
            mailBody.Append("<li><p>");
            mailBody.Append("<span style='font-size:10px'>");
            mailBody.Append("Please donot forward this mail to anyone,as each mail is intended uniquely for you.");
            mailBody.Append("</span>");
            mailBody.Append("</p></li>");
            //term 3
            mailBody.Append("<li><p>");
            mailBody.Append("<span style='font-size:10px'>");
            mailBody.Append("In case of any fraud or phishing,please revert to complain@d-studio.co.in");
            mailBody.Append("</span>");
            mailBody.Append("</p></li>");
            mailBody.Append("</ul>");
            mailBody.Append("</td></tr>");
            mailBody.Append("</table>");
            mailBody.Append("</div>");
            return mailBody.ToString();
        }

        private static string ComposeOrderEmailBody(OrderMapper order)
        {
            return "hello order";
        }

        #endregion Private Members
    }
}