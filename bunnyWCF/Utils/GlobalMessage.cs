using bunnyWCF.Utils.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bunnyWCF.Utils
{
    public class GlobalMessage
    {

        private readonly static GlobalMessage instance = new GlobalMessage();

        public static GlobalMessage Instance {
            get { return instance; }
        
        }

        public readonly MessageHelper ERROR = new MessageHelper() {Code="500",Message="Lo sentimos no pudimos completar el proceso" };
        public readonly MessageHelper OK = new MessageHelper() { Code = "200", Message = "Petición realizada con éxito." };
        public readonly MessageHelper EXIST = new MessageHelper() { Code = "201", Message = "Ya existe un registro" };
    }
}