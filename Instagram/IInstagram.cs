using InstaSharper.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram
{
    interface IInstagram
    {

          Task<IResult<InstaLoginResult>> Login();
   

    }
}
