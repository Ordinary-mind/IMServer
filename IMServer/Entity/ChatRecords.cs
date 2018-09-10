using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMServer.Entity
{
    class ChatRecords
    {
        public string RecordId { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public DateTime SendTime { get; set; }
        public string Content { get; set; }
    }
}
