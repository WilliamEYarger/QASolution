using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QADataModelLib
{
    public static class SubjectNodesListModel
    {

        private static string subjectNodesListPath =  @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\SubjectNodesList.txt";
        private static List<string> SubjectNodesList = new List<string>();

        public static List<string> getSubjectNodesList()
        {
            return SubjectNodesList;
        }
        public static void loadSubjectNodesList()
        {
            if (File.Exists(subjectNodesListPath))
            {
                // If the file length is not 0 open the file and read it into subjectNodesList
                var fil = new FileInfo(subjectNodesListPath);
                long length = fil.Length;
                if (length != 0)
                {

                    string[] lines = File.ReadAllLines(subjectNodesListPath);
                    SubjectNodesList = new List<string>(lines);
                }
            }
        }// End setSubjectNodesList


        public static string returnSubjectNodeName(string nodeTextValue)
        {
            // Get a copy of SubjectNodesList
            //List<string> copySubjectNodesList = AccessData.getSubjectNodesList();
            int subjectNodeIndexInt = SubjectNodesList.Count;
            string subjectNodeName = subjectNodeIndexInt.ToString();
            //AccessData.updateSubjectNodesList(subjectNodeName, nodeTextValue);
            SubjectNodesList.Add(subjectNodeName + "^" + nodeTextValue);

            return subjectNodeName;
        }// End returnSubjectNodeName


        public static void saveSubjectNodeList()
        {
            if (File.Exists(subjectNodesListPath))
            {
                File.Delete(subjectNodesListPath);
            }
            foreach (string line in SubjectNodesList)// a TODO - is this an error
            {
                string thisLine = line;
            }
            File.WriteAllLines(subjectNodesListPath, SubjectNodesList);

        }

        public static void changeSubjectNodeList(string nodeName, string oldNodeText, string newNodeText)
        {
            //List<string> newSubjectNodeList = new List<string>();
            string lineToReplace = nodeName + '^' + oldNodeText;
            string lineToSubstitute = nodeName + '^' + newNodeText;
            for (int i = 0; i < SubjectNodesList.Count; i++)
            {
                if (SubjectNodesList[i].Contains(lineToReplace))
                    SubjectNodesList[i] = lineToSubstitute;
            }
            
        }


        public static void updateSubjectNodesList(string subjectNodeName, string nodeTextValue)
        {
            SubjectNodesList.Add(subjectNodeName + "^" + nodeTextValue);
        }

        public static void reviseSubjectNodesList(List<string> newSubjectNodesList)
        {
            SubjectNodesList = new List<string>();
            SubjectNodesList = newSubjectNodesList;
            foreach (string line in SubjectNodesList)
            {
                string thisLine = line;
            }
        }// End reviseSubjectNodesList

    }// End SubjectNodesListModel
}// End QADataModelLib
