# QASolution
This Program manages different question and answer files
The various subjects are categorized in a Tree with various subject sub nodes and the penultimate nodes are the acutal QA file names. 
The text shown on the tree are subjects/sub-subjects/QAFiles
The Name attribute of the various nodes will be created by the program in a way that the node name identifies the node's parent(s) 
as well as its position in parent subject/-subject. For example if aSubject Tree has Main Subjects Computers{A}, Histor{B}, Languages{C}
where the string in the {}s represents the computer assigned name.
If the Computer{A} has the following sub or 'division' sub-nodes: Computers{A}-> Languages{AA}, IDEs{AB}, ComputerScience{AC}; and the 
And the Computers{A}-> Languages{AA} has the following sub-nodes: Computers{A}-> Languages{AA}-> C#{AAA}, VB{AAB}, Fortrand{AAC}
And the Computers{A}-> Languages{AA}-> C#{AAA} nodes has the following penultimate subject nodes:
  Computers{A}-> Languages{AA}-> C#{AAA}-> Syntax{AAAA}, VisualStudioImplementation{AAAB}, CodeSnipits{AAAC}
Then there might be the following QAFiles under the Syntax{AAAA} node: Variables{AAAA1}, Classes{AAAA3}, Loops{AAAA4}, WindowsForms{AAAA37}



#NOTE:#
The QA File names differ from the subjec node names in that they contain a terminal digit. This digit is also assigned by the program
and it allows the files which contain the QAFileNameResult file and the file which contains the QACumulativeResults file to be able 
to locate specific QAFiles should they or their parents be moved to a new location for renaming purposes.
