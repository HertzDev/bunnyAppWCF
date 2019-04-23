using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bunnyWCF.Utils
{
    public class Strings
    {
        private readonly static Strings instance = new Strings();
        public static Strings Instance
        {
            get { return instance; }
        }

        public readonly string MessageError = "Lo sentimos, no pudimos realizar el proceso.";
        public readonly string MessageOK = "Petición realizada con éxito.";


    }
}