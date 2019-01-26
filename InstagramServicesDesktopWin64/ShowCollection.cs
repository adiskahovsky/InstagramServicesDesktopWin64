using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace InstagramServicesDesktopWin64
{
    class ShowCollection
    {
        static ShowCollection() { _curPos++; }
        static private int _curPos = 1;
        public string RowNumber { get { return _curPos.ToString(); } }
        public string Login { get; set; }
        public string Status { get; set; }
        public string Balance { get; set; }
        public string LikesRecieved { get; set; }
        public string SubscribeRecieved { get; set; }
        public string CommentsRecieved { get; set; }
        public string Subscribes { get; set; }
        public string UnSubscribes { get; set; }
        public string Comments { get; set; }
        public string Proxy { get; set; }
        public string Publications { get; set; }
        public string CurrentSubscribers { get; set; }
        public string Photo { get; set; }
        public string Accuracy { get; set; }
        private Color _color;
        public Color Color { get { return _color; } set { _color = value; } }
    }
}