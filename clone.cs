using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab16_OOP
{
    public interface ICloneable<T>
    {
        abstract public T Clone();
    }
}
