using Core.Etilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message)//resulta mesajı gönder 
        {

        }
        public SuccessResult():base(true)
        {

        }
    }
}
