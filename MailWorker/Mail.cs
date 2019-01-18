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
        ImapClient ic;
      
        public Mail(string login,string password)
        {

             ic = new ImapClient("imap.mail.ru", login, password, AuthMethods.Login, 993, true, true);
        }
        public string GetMailText(DateTime dt)
        {

           
            var res = ic.SelectMailbox("INBOX");

            MailMessage[] mm = ic.GetMessages(ic.GetMessageCount() - 1, ic.GetMessageCount());

            if (mm[mm.Length-1].Date > dt)
            {

                MailMessage message = ic.GetMessage(mm[mm.Length - 1].Uid);
                StreamWriter file = new StreamWriter(@"D:\WorkSpaceC#\message.html");
                file.Write(message.Body);
                file.Close();

                Thread.Sleep(5000);
                HtmlAgilityPack.HtmlWeb web = new HtmlWeb();

                HtmlAgilityPack.HtmlDocument doc = web.Load(@"D:\WorkSpaceC#\message.html");

                var nodes = doc.DocumentNode.SelectNodes("//p/font");
                string result = nodes[0].InnerText;

                return result;//message.Body.ToString();
            }
            else
            {
                Thread.Sleep(5000);
                return GetMailText(dt);
            }
        }




    }
}
