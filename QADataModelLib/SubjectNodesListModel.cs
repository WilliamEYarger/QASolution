//--------------------VARIABLES--------------------//
//      string subjectNodesListPath 
//      List<string> SubjectNodesList




using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QADataModelLib
{
    public static class SubjectNodesListModel
    {
        //--------------------VARIABLES--------------------//
        private static string subjectNodesListPath =  @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\SubjectNodesList.txt";
        private static List<string> SubjectNodesList = new List<string>();

        public static List<string> getSubjectNodesList()
        {
            return SubjectNodesList;
        }

        /// <summary>
        /// Called by the Dashboard when the application loads
        /// </summary>
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

        /// <summary>
        /// Called by QATreeform when a new subecjt node is created
        /// </summary>
        /// <param name="nodeTextValue"></param>
        /// <returns></returns>
        public static string returnSubjectNodeName(string nodeTextValue)
        {
            // Use the number of items in the SubjectNodesList to create the name for the new Subject node to be added
            int subjectNodeIndexInt = SubjectNodesList.Count;
            string subjectNodeName = subjectNodeIndexInt.ToString();
            // Add this new node's name and text to SubjectNodesList
            SubjectNodesList.Add(subjectNodeName + "^" + nodeTextValue);
            return subjectNodeName;
        }// End returnSubjectNodeName


        /// <summary>
        /// Called by the Dashboard when the application closes
        /// </summary>
        public static void saveSubjectNodeList()
        {
            if (File.Exists(subjectNodesListPath))
            {
                File.Delete(subjectNodesListPath);
            }
            foreach (string line in SubjectNodesList)
            {
                string thisLine = line;
            }
            File.WriteAllLines(subjectNodesListPath, SubjectNodesList);

        }// End saveSubjectNodeList(


        /// <summary>
        /// Called by SubjectTreeViewModel's renameNode( method when the node to be
        /// renamed is a Subject node
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="oldNodeText"></param>
        /// <param name="newNodeText"></param>
        public static void changeSubjectNodeList(string nodeName, string oldNodeText, string newNodeText)
        {
            string lineToReplace = nodeName + '^' + oldNodeText;
            string lineToSubstitute = nodeName + '^' + newNodeText;
            for (int i = 0; i < SubjectNodesList.Count; i++)
            {
                if (SubjectNodesList[i].Contains(lineToReplace))
                    SubjectNodesList[i] = lineToSubstitute;
            }
        }// End changeSubjectNodeList


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
