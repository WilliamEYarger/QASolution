
//------------------------------VARIABLES------------------------------//
//      List<string> subjectNodesList = new List<string>();
//      Dictionary<string, string> treeViewDictionary = new Dictionary<string, string>();
//      Dictionary<int, string> QANameScoreDictionary;
//      Dictionary<int, string[]> modifiedQA

//------------------------------GETTERS AND SETTERS-------------------//
//      string nodeName { get; set; }
//      string oldNodeText { get; set; }
//      string newNodeText { get; set; }
//      string parentsNodeName { get; set; }

//------------------------------METHODS-------------------------------//
//------------------------------PUBLIC--------------------------------//
//      void changeNodeTextValue(
//------------------------------PRIVATE-------------------------------//
//      void openFiles(
//      void convertQANameScoreDictionary(      
//      changeFiles(
//      
//      
//      
//      
//      

using System;
using System.Collections.Generic;
using System.Text;
using QADataModelLib;

namespace QADataModelLib
{
    public static class ChangeNodeTextValue
    {
        //------------------------------VARIABLES------------------------------//
        private static List<string> subjectNodesList = new List<string>();
        private static Dictionary<string, string> treeViewDictionary = new Dictionary<string, string>();
        private static Dictionary<int, string> QANameScoreDictionary;
        private static Dictionary<int, string[]> modifiedQANameScoreDictionary = new Dictionary<int, string[]>();



        //------------------------------GETTERS AND SETTERS-------------------//
        public static string nodeName { get; set; }
        public static string oldNodeText { get; set; }
        public static string newNodeText { get; set; }
        //public static string parentsNodeName { get; set; }



        //------------------------------METHODS-------------------------------//

        //------------------------------PUBLIC--------------------------------//


        /// <summary>
        /// The is the main procedure called to change a node's text value
        /// </summary>
        public static void changeNodeTextValue(char nodeType)
        {
            // a TODO - call all necessary methods to change the appropriate file type
            switch (nodeType)
            {
                //case 'S':
                //    // Will need to change TreeViewDictionary, SubjectsNodeList,QANameScores
                //    SubjectNodesListModel.changeSubjectNodeList(nodeName, newNodeText);
                //    //subjectNodesList = SubjectNodesListModel.getSubjectNodesList();
                        
                //    //changeSubjectNodeList();
                //    break;
                case 'D':
                    // Will need to change TreeViewDictionary, QANameScores

                    break;
                case 'Q':
                    // Will need to change TreeViewDictionary, QANameScores, and QACumulativeResults
                    break;
                default:
                    break;
            }
            //openFiles();
        }


        //------------------------------PRIVATE-------------------------------//

        private static void changeSubjectNodeList()
        {
            List<string> newSubjectNodeList = new List<string>();
            foreach(string line in subjectNodesList)
            {
                string[] nameText = line.Split('^');
                if (nameText[0] == nodeName)
                {
                    nameText[1] = newNodeText;
                }
                newSubjectNodeList.Add(nameText[0] + '^' + nameText[1]);
            }
            subjectNodesList = new List<string>();
            subjectNodesList = newSubjectNodeList;
            SubjectNodesListModel.reviseSubjectNodesList(subjectNodesList);


        }

        /// <summary>
        /// This procedure opens all files which will be needed
        /// </summary>
        private static void openFiles()
        {
            // 1. Open all files that need to be changed
            // Determine whether to open the SubjectNodesList.txt file
            if(nodeName.IndexOf('.') == -1)
            {
                // The node to be changed is a Subject node so open the SubjectNodesList.txt file
                subjectNodesList = SubjectNodesListModel.getSubjectNodesList();
            }
            changeFiles();
        }// End openFiles(


        private static void convertQANameScoreDictionary()
        {
            //  a todo TODO - convert '^' delimited string into a string[]
            foreach(KeyValuePair<int, string> kvp in QANameScoreDictionary)
            {
                int key = kvp.Key;
                string items = kvp.Value;
                string[] values = items.Split('^');
                modifiedQANameScoreDictionary.Add(key, values);
            }
        }// End convertQANameScoreDictionary

        private static void changeFiles()
        {
            // Determine if the file to be changed is a QA File
            if(oldNodeText.IndexOf("qa_") == 0){
                // This is a QA Node to be changed

                // change the value in the modifiedQANameScoreDictionary
                foreach (KeyValuePair<int, string[]> kvp in modifiedQANameScoreDictionary)
                {
                    int key = kvp.Key;
                    string[] values = kvp.Value;
                    if(values[0] == oldNodeText)
                    {
                        values[0] = newNodeText;
                    }
                }// Endforeach (KeyValuePair<int, string[]> kvp 
                // Convert the modifiedQANameScoreDictionary back to a QANameScoreDictionary
                QANameScoreDictionary = new Dictionary<int, string>();
                foreach (KeyValuePair<int, string[]> kvp in modifiedQANameScoreDictionary)
                {
                    int key = kvp.Key;
                    string[] values = kvp.Value;
                    string newValue = "";
                    for(int i=0; i<values.Length; i++)
                    {
                        newValue = newValue + values[i] + '^';
                    }
                    // Remove the last '^'
                    newValue = newValue.Remove(newValue.Length-1);
                    QANameScoreDictionary.Add(key, newValue);
                }

            }// End if(oldNodeText.IndexOf("qa_") == 0)

        }// End changeFiles



    }// End ChangeNodeTextValue Class



}// End QADataModelLib
