using System;

namespace PruebaV5.Core.Exceptions
{
    public class BussinesException : Exception
    {
        public BussinesException()
        {

        }

        public BussinesException(string message) : base(message)
        {

        }
    }
}
