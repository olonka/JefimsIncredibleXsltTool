﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JefimsMagicalXsltSyntaxConcoctions.SyntaxSugars
{
    public class VariableSugar : ISyntaxSugar
    {
        public int Priority
        {
            get
            {
                return 1;
            }
        }

        public string PureXsltToXsltWithSugar(string pureXslt)
        {
            var regexPattern = @"<xsl:variable[ \t\r\n]+name=""([^\""]+)""[ \t\r\n]+select=""([^\""]+)""[ \t\r\n]+/>";
            var replace = "#var $1=$2";
            return new Regex(regexPattern).Replace(pureXslt, replace);
        }

        public string XsltWithSugarToPureXslt(string xsltWithSugar)
        {
            var regexPattern = @"#var[ \t]+([a-zA-Z0-9]+)[ \t]*=[ \t]*([^\r\n]*)";
            var replace = @"<xsl:variable name=""$1"" select=""$2"" />";
            return new Regex(regexPattern).Replace(xsltWithSugar, replace);
        }
    }
}
