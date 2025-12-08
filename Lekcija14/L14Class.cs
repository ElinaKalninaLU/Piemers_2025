using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lekcija14
{
    public class L14Class
    {
        public void executeSimpleThread()
        {
            Console.WriteLine("Runing a seperate thread");
        }

        public void executeThreadwithParam(Object p)
        {
            if (p != null && p is String)
            {
                String s = (String)p;
                Console.WriteLine("Runing a seperate thread: " + s);
            }
        }

    }
}
