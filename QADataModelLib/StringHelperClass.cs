using System;
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


        public static string returnNthItemInDelimitedString(string inputString, char del, int itemNumber)
        {
            string[] items = inputString.Split(del);
            string outputString = items[itemNumber];
            return outputString;
        }

        public static string replaceNthItemInDelimitedString(string inputString, char del, int itemNumber, string replacementString)
        {
            string[] items = inputString.Split(del);
            items[itemNumber] = replacementString;
            string outputString = "";
            for(int i =0; i<items.Length; i++)
            {
                outputString = outputString + items[i] + del;
            }
            outputString = outputString.Substring(0, outputString.Length - 1);
            return outputString;
        }

        public static string replaceNthItemInString(string inputString, char del, int itemNumber)
        {
            string[] itemsArray = inputString.Split(del);
            string returnString = "";
            for(int i=0; i<itemsArray.Length; i++)
            {
                if(i != itemNumber)
                {
                    returnString = returnString + itemsArray[i] + del;
                }
            }
            returnString = returnString.Substring(0, returnString.Length - 1);
            return returnString;
        }

        public static string removeNthItemFromDelimitedString(string inputString, char del, int itemNumber)
        {
            string returnStr = "";
            string[] itemsArray = inputString.Split(del);
            for(int i=0; i< itemsArray.Length; i++)
            {
                if(i!= itemNumber)
                {
                    returnStr = returnStr + itemsArray[i] + del;
                }
            }
            returnStr = returnStr.Substring(0, returnStr.Length - 1);

            return returnStr;

        }// End removeNthItemFromDelimitedString

    }// End StringHelperClass
}// End namespace QADataModelLib
