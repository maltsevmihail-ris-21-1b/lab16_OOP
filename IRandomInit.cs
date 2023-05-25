using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab16_OOP
{
    public interface IRandomInit
    {
        static Random rnd = new Random();
        Engine RandomInit();
        string ToString();
    }
}
