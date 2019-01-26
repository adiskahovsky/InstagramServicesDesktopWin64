using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogLibrary
{
    public class Log
    {
        private string _username;

        public string UserName
        {
           private get { return _username; }
            set { _username = value; }
        }


        private DateTime _date;

        public DateTime Date
        {
            private get { return _date; }
            set { _date = value; }
        }

        private string _method;

        public string Method
        {
            private get { return _method; }
            set { _method = value; }
        }


        private string _message;

        public string Message
        {
          private  get { return _message; }
            set { _message = value; }
        }

        public override string ToString()
        {
            return $"{_date} {_username} {_method} {_message} ";
        }

    }
}
