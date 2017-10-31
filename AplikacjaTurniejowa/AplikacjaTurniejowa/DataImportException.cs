using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AplikacjaTurniejowa
{
    class DataImportException : Exception
    {
        public DataImportException()
        {
        }

    public DataImportException(string message)
        : base(message)
        {
        }

    public DataImportException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
