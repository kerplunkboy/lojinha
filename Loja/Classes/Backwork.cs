using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Backwork
{
    public abstract class CommonFunctions<T> where T : CommonFunctions<T>, new()
    {
        public void Gravar()
        { 
        }
    }
}
