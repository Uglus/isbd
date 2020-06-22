using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    [Serializable]
    public class Leader
    {
        public DateTime Date { get; set; }
        public int UserName { get; set; }
        public int Points { get; set; }
    }
}
