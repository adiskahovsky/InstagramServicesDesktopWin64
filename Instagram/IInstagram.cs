using InstaSharper.API;
using InstaSharper.Classes;
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

        Task<IResult<InstaLoginResult>> Login();
   

    }
}
