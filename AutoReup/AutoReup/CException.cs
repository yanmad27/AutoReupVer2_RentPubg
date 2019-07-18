using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReup
{
    class CException : ApplicationException
    {
        public CException(string message)
            : base(message)
        {

        }

        public class WrongIDPW : CException
        {
            public WrongIDPW(string message)
                : base(message)
            { }
        }

        public class F5Fail : CException
        {
            public F5Fail(string message)
                : base(message)
            { }
        }

        public class SteamGuardOn : CException
        {
            public SteamGuardOn(string message)
                : base(message)
            { }
        }

        public class ButtonSendMailNotVisible : CException
        {
            public ButtonSendMailNotVisible(string message)
                : base(message)
            { }
        }

        public class InputCodeNotVisible : CException
        {
            public InputCodeNotVisible(string message)
                : base(message)
            { }
        }

        public class InputNewPasswordNotVisible : CException
        {
            public InputNewPasswordNotVisible(string message)
                : base(message)
            { }
        }

        public class IPLoginError : CException
        {
            public IPLoginError(string message)
                : base(message)
            { }
        }

        public class IPMailError : CException
        {
            public IPMailError(string message)
                : base(message)
            { }
        }

        public class ChaBietBiGi : CException
        {
            public ChaBietBiGi(string message)
                : base(message)
            { }
        }

    }
}
