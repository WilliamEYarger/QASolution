
//------------------------------VARIABLE DEFINITIONS---------------------------
//------------------------------FILE PATHS--------------------------------------------------//
//      string accessoryFilesPath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\";
//      string treeViewDictionaryPath = accessoryFilesPath + "TreeViewDictionary.txt";
//      string nodeChildDictionaryPath = accessoryFilesPath + "NodeChildDictionary.txt";
//      string qASubjectTreeViewPath = accessoryFilesPath + "QASubjectTreeView.bin";
//      string qaNameScoreFilePath = accessoryFilesPath + "QAFileNameScores.txt"
//------------------------------DATA STORAGE OBJECTS----------------------------------------//
//      Dictionary<string, string> TreeViewDictionary
//      Dictionary<string, int> nodeChildrenDictionary
//      Dictionary<Int32, string> QANameScoreDictionary
//------------------------------PROPERTIES--------------------------------------------------// 
//      Int32 currentMaxQAFileID {
//      bool filesChanged {
//------------------------------GETTERS AND SETTERS-----------------------------------------//
//      Dictionary<Int32, string> getQANameScoreDictionary(
//      setQANameScoreDictionary(
//      Dictionary<string, string> getTreeViewDictionary(
//      setTreeViewDictionary(
//------------------------------METHODS CALLED BY THE QATreeForm----------------------------//
//      string returnParentChain(
//      string returnDivisionNodeName(
//      void updateNodeChildrenDictionary(
//      Boolean AddNode(
//      void saveNodeChildrenDictionary(
//      Int32 returnQAFileName(
//      addQANodeToQANamesDictionary(
//      void  loadNodeChildrenDictionary(
//      Boolean doesNodeHaveChildren(
//      void renameNode(
//------------------------------METHODS CALLED BY ChangeNodeTextValue----------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using QADataModelLib;


namespace QADataModelLib
{
    public static class SubjectTreeViewModel


    {
        

        

        /// <summary>
        /// It true if the TreeView and its associated accessory files were changed
        /// </summary>
        public static bool filesChanged { get; set; } = false;


        //------------------------------GETTERS AND SETTERS-----------------------------------------//








        //------------------------------METHODS CALLED BY THE QATreeForm----------------------------//





        /// <summary>
        /// This method determines gets the current largest value of an ID in the QAFileDataTable
        /// which is uploaded from the QAFileNameScores.txt  in the AccessoryFiles folder
        /// </summary>
        /// <returns> the new maximum value for a QAFile ID integer</returns>
        public static Int32 returnQAFileName()
        {
            Int32 newQAFileIDNumber = QAFileNameScoresModel.currentMaxQAFileID;
            newQAFileIDNumber++;
            QAFileNameScoresModel.currentMaxQAFileID = newQAFileIDNumber;
            return newQAFileIDNumber;
        }// End returnQAFileName



        /// <summary>
        /// Called by QATreeForm's renameNodeButton_Click( method
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="oldNodeText"></param>
        /// <param name="newNodeText"></param>
        /// <param name="nodeLevel"></param>
        public static void renameNode(string nodeName, string oldNodeText, string newNodeText, int nodeLevel)
        {
            // Create a character 'nodeType' to refelect the type of node being re-texted
            char nodeType;
           // ChangeNodeTextValue.nodeName = nodeName;
            //ChangeNodeTextValue.oldNodeText = oldNodeText;
            //ChangeNodeTextValue.newNodeText = newNodeText;
            // Get Char representing node type
            if (nodeLevel == 0)
            {
                //nodeType = 'S';
                SubjectNodesListModel.changeSubjectNodeList(nodeName, oldNodeText, newNodeText);
                TreeViewDictionaryModel.reTextNode(nodeName, newNodeText);
                // TODO - Change QANameScoresFile
                QAFileNameScoresModel.reTextNameScores(nodeName, oldNodeText, newNodeText);
            }
            else if(oldNodeText.IndexOf("qa_") == 0)
            {
                //nodeType = 'Q';
            }
            else
            {
                //nodeType = 'D';
                TreeViewDictionaryModel.reTextNode(nodeName, newNodeText);
                QAFileNameScoresModel.reTextNameScores(nodeName, oldNodeText, newNodeText);
            }
            //ChangeNodeTextValue.changeNodeTextValue(nodeType);
        }

        //----------------------METHODS that will be transferrec to ChangeNodeGTextValue.cs------------------//




    }// End SubjectTreeViewModel



}// End QADataModelLib
