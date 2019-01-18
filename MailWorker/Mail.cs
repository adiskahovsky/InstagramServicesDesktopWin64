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


        public Mail()
        {
            /*
            var mailRepository = new MailRepository(
                           "imap.mail.ru",
                           993,
                           true,
                           "alannaoglesuzf@mail.ru",
                           "fAt1wkA8Ql"
                       );

            mailRepository.GetMails("Instagram", "inbox");
            

            HttpRequest danni = new HttpRequest();
            danni.Cookies = new CookieStorage();
            danni.UserAgent = Http.FirefoxUserAgent();
            danni.AddHeader("","");
            

            tcpc = new System.Net.Sockets.TcpClient("imap.gmail.com", 993);

            ssl = new System.Net.Security.SslStream(tcpc.GetStream());
            ssl.AuthenticateAsClient("imap.gmail.com");
            

            ImapClient ic = new ImapClient("imap.mail.ru", "alannaoglesuzf@mail.ru", "fAt1wkA8Ql", AuthMethods.Login, 993, true, true);
            var res = ic.SelectMailbox("INBOX");

            MailMessage[] mm = ic.GetMessages(0, 5);

            MailMessage message = ic.GetMessage(mm[3].Uid);

*/

        }
        public string GetMailText()
        {

            ImapClient ic = new ImapClient("imap.mail.ru", "alannaoglesuzf@mail.ru", "fAt1wkA8Ql", AuthMethods.Login, 993, true, true);
            var res = ic.SelectMailbox("INBOX");

            MailMessage[] mm = ic.GetMessages(ic.GetMessageCount() - 1, ic.GetMessageCount());

            MailMessage message = ic.GetMessage(mm[mm.Length-1].Uid);
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
    }
}
