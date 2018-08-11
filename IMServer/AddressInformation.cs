using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IMServer
{
    class AddressInformation
    {
        public TcpClient tcpClient { set; get; }
        public String name { set; get; }
        public int id { set; get; }

        public String ipAddress { get; set; }
        
    }
}
