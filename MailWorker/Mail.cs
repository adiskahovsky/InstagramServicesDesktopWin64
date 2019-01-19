using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AE.Net.Mail;
using HtmlAgilityPack;
using MailClient;

namespace MailWorker
{
    public class Mail
    {
        public Mail() { }

        public string GetMailText()
        {
            ImapClient ic = new ImapClient("imap.mail.ru", "alannaoglesuzf@mail.ru", "fAt1wkA8Ql", AuthMethods.Login, 993, true, true);
            var res = ic.SelectMailbox("INBOX");

            MailMessage[] mm = ic.GetMessages(ic.GetMessageCount() - 1, ic.GetMessageCount());

            MailMessage message = ic.GetMessage(mm[mm.Length - 1].Uid);
            StreamWriter file = new StreamWriter(@"D:\WorkSpaceC#\message.html");
            file.Write(message.Body);
            file.Close();

            Thread.Sleep(5000);
            HtmlWeb web = new HtmlWeb();

            HtmlDocument doc = web.Load(@"D:\WorkSpaceC#\message.html");

            var nodes = doc.DocumentNode.SelectNodes("//p/font");
            string result = nodes[0].InnerText;

            return result;//message.Body.ToString();
        }
    }
}