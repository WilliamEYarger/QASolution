# QASolution
This Program manages different question and answer files
The various subjects are categorized in a Tree with various subject sub nodes and the penultimate nodes are the acutal QA file names. 
The text shown on the tree are subjects/sub-subjects/QAFiles
The Name attribute of the various nodes will be created by the program in a way that the node name identifies the node's parent(s) 
as well as its position in parent subject/-subject. For example if aSubject Tree has Main Subjects Computers{0}, Histor{1}, Languages{2}
where the string in the {}s represents the computer assigned name.
If the Computer{0} has the following sub or 'division' sub-nodes: Computers{0}-> Languages{0.0}, IDEs{0.1}, ComputerScience{0.2}; and the 
And the Computers{0}-> Languages{0.0} has the following sub-nodes: Computers{0}-> Languages{0.0}-> C#{0.0.0}, VB{0.0.1}, Fortrand{0.0.2}
And the Computers{0}-> Languages{0.0}-> C#{0.0.0} nodes has the following penultimate subject nodes:
  Computers{0}-> Languages{0.0}-> C#{0.0.0}-> Syntax{0.0.0.0}, VisualStudioImplementation{0.0.0.1}, CodeSnipits{0.0.0.2}
Then there might be the following QAFiles under the Syntax{0.0.0.0} node: Variables{0.0.0.0.0q}, Classes{0.0.0.0.1q}, Loops{0.0.0.0.2q}, WindowsForms{0.0.0.0.28q}



#NOTE
The QA File names differ from the subjec node names in that they contain a terminal letter. The digit assigned to the terminal QAFile name, however is determined by 
its position in the QAFileNameDataGridView

#Rename Branch#
Rather than containing the code to rename a node this branch moves all model files related to the various input/output files into separate classes foe each file.
