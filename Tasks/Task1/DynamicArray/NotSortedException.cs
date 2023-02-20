using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    internal class NotSortedException : Exception
    {
        public NotSortedException()
        {
        }

        public NotSortedException(string message)
            : base(message)
        {
        }

        public NotSortedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
