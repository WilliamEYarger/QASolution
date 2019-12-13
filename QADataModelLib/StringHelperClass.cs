﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QADataModelLib
{
    public static class StringHelperClass
    {
        /// <summary>
        /// Receives a 'del' delinited string and returns a string[]
        /// whenre [0] = the front of the string and
        /// [1] = the string after the last delimeter
        /// </summary>
        /// <param name="delimitedString"></param>
        /// <param name="del"></param>
        /// <returns></returns>
        public static string[] getLastDelimitedValue(string delimitedString, char del)
        {

            string[] returnArray = new string[2];
            int posLast = delimitedString.LastIndexOf(del);
            if(posLast != -1)
            {
                returnArray[0] = delimitedString.Substring(0, posLast);
                returnArray[1] = delimitedString.Substring(posLast + 1);
            }
            else
            {
                returnArray[0] = "";
                returnArray[1] = delimitedString;
            }

            return returnArray;
        }


    }// End StringHelperClass
}// End namespace QADataModelLib
