using System;
using System.Collections.Generic;
using System.Text;

namespace QADataModelLib
{
    public static class DelimitedStringMethods
    {

        public static string [] returnLastAndUpdate(string delString, char del)
        {
            var returnArr = new string[2]; 
            int posLastDelimiter = delString.LastIndexOf(del);
            returnArr[0] = delString.Substring(posLastDelimiter);
            returnArr[1] = delString.Substring(0, posLastDelimiter - 1);

            return returnArr;

        }

        public static string removeLastValue(string delString, char del)
        {

            int posLastDelimiter = delString.LastIndexOf(del);
            if(posLastDelimiter < 0) 
            {
                return "";
            }
            string updatedString = delString.Substring(0, posLastDelimiter);
            return updatedString;
        }
    }
}
