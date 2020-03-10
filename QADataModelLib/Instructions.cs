using System;
using System.Collections.Generic;
using System.Text;

namespace QADataModelLib
{
    public static class Instructions
    {
        private static string inst = "";
        public static string instructions
        {
            
        get
            {
                return inst;
            }
            set
            {
                inst = value;
            }
        
        }
    }// End Instructions class
}// End namespace QADataModelLib

