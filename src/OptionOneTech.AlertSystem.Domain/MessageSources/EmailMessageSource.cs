using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionOneTech.AlertSystem.MessageSources
{
    public class EmailMessageSource
    {
        public string Hostname { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  
        public string Folder { get; set; }
        public bool DeleteAfterDownload { get; set; }
        public bool Active { get; set; }
    }
}
