using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpLibrary
{
    public class Numbers
    {
        public int FirstCountingNumber() 
        { return 1; }
    }

    public interface ICanAddNumbers
    {
        int Add(int a, int b);
    }
}
