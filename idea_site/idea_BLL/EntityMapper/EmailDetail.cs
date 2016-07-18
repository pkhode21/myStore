using System.Collections.Generic;

namespace idea_BLL.EntityMapper
{
    public class EmailDetail
    {
        public string RecipientEmail { get; set; }

        public IEnumerable<string> CC { get; set; }

        public IEnumerable<string> Bcc { get; set; }

        public string MailSubjectLine { get; set; }

        public string MailMessage { get; set; }

        public string SenderName { get; set; }

        public string DisplayName { get; set; }

        public string SenderEmailAddress { get; set; }

        public string ReplyToEmailAddress { get; set; }

        public string RecipientsName { get; set; }

        public int MailPurpose { get; set; }

        public OrderMapper OrderDetails { get; set; }
    }
}