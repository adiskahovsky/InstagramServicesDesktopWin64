using InstaSharper.API;
using InstaSharper.Classes;
using MailWorker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram
{
    public interface IInstagram
    {
        IInstaApi InstaApi { get; }
        Mail mail { get; set; }

        Task<IResult<InstaLoginResult>> Login();
    }
}