using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıç 
    public interface IResult
    {
        public bool Success { get; }
        public string Message { get; }
    }
}
