//------------------------------PROPERTIES--------------------------------------------------// 
//      Int32 currentMaxQAFileID {
//------------------------------FILE PATHS--------------------------------------------------//
//       string accessoryFilesPath
//       string qASubjectTreeViewPath
//       string qaNameScoreFilePath
//       string qaCumulativeResultsPath
//------------------------------DATA STRUCTURES---------------------------------------------//
//       Dictionary<Int32, string> QANameScoreDictionary
//       DataTable qaCumulativeResultsTable 
//------------------------------GETTERS AND SETTERS---------------------------------------//
//       Dictionary<string, int> getNodeChildrenDictionary(
//       Dictionary<Int32, string> getQANameScoreDictionary(
//       string getQASubjectTreePath
//------------------------------FILE LOADER METHODS---------------------------------------//
//       public static void openAllFiles(
//       private static void loadNodeChildrenDictionary(
//       private static void loadQANameScoreDictionary
//       private static void loadQACumulativeResultFile(
//------------------------------FILE SAVER METHODS----------------------------------------//
//       public static void  saveAllFiles(
//       private static void saveNodeChildrenDictionary(
//       private static void saveQAFileNameScoresFile(
//       private static void saveQACumulativeResultsFile(
//------------------------------OTHER METHODS---------------------------------------------//
//       void updateQANameScoreDictionary
//       
//       
//       




using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Linq;

namespace QADataModelLib
{

    /// <summary>
    /// This class creates and saves add data structures used by the project
    /// All data structures will be created with the project opens 
    /// and saved when the project closes
    /// The class also manages the construction and deconstruction of all
    /// data structures into appropriate text file format
    /// It uses classic Variables with getters and setters rather than properties
    /// </summary>
    public static class AccessData



    {

        //------------------------------FILE PATHS--------------------------------------------------//
        private static string accessoryFilesPath = @"C:\Users\Bill Yarger\OneDrive\Documents\Learning\_CSharpQAFiles\AccessoryFiles\";
        public static string qaCumulativeResultsPath = accessoryFilesPath + "QACumulativeResults.txt";

        //------------------------------DATA STRUCTURES---------------------------------------------//


        //private static Dictionary<Int32, string> QANameScoreDictionary = new Dictionary<int, string>();


        private static DataTable qaCumulativeResultsTable = new DataTable();

 

        
        //------------------------------FILE LOADER METHODS---------------------------------------//

            public static void openAllFiles()
        {
            
            //loadQANameScoreDictionary();
            loadQACumulativeResultFile();
        }// End openAllFiles


       

       
        
        private static void loadQACumulativeResultFile()
        {
            if (File.Exists(qaCumulativeResultsPath))
            {

                qaCumulativeResultsTable.Columns.Add("File Name", typeof(string));
                qaCumulativeResultsTable.Columns.Add("File Text", typeof(string));
                qaCumulativeResultsTable.Columns.Add("Date Taken", typeof(string));
                qaCumulativeResultsTable.Columns.Add("% Correct", typeof(string));
                qaCumulativeResultsTable.Columns.Add("Incorrect Answers", typeof(string));
                string[] lines = File.ReadAllLines(qaCumulativeResultsPath);
                string[] values;
                for (int i = 0; i < lines.Length; i++)
                {
                    values = lines[i].ToString().Split('^');
                    string[] row = new string[values.Length];

                    for (int j = 0; j < values.Length; j++)
                    {
                        row[j] = values[j].Trim();
                    }
                    qaCumulativeResultsTable.Rows.Add(row);
                }

            }
        }


        //------------------------------FILE SAVER METHODS----------------------------------------//

        public static void  saveAllFiles()
        {
            //saveQAFileNameScoresFile();
            saveQACumulativeResultsFile();

        }// End saveAllFiles

        


        

        private static void saveQACumulativeResultsFile()
        {
            if (File.Exists(qaCumulativeResultsPath))
            {
                File.Delete(qaCumulativeResultsPath);
            }
            StringBuilder sb = new StringBuilder();

            foreach (DataRow row in qaCumulativeResultsTable.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).
                                            ToArray();
                sb.AppendLine(string.Join("^", fields));
            }

            File.WriteAllText(qaCumulativeResultsPath, sb.ToString());
        }

 


    }// End AccessData class

}// End QADataModelLib
