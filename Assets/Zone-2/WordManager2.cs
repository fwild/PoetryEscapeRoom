using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WordManager2 : MonoBehaviour {

    public string readPath;
    public TextAsset textFile;

    public List<string> sentences;
    public List<string> words;

    public int totalCharacters;

    public Text textlog;
    
    void Start()
    {
        //readPath = Application.dataPath + "/Zone-2/zone-2-words.txt";

        //ReadFile(readPath);
        ////AddToLog(); // adds to the onscreen log debug use only

        //totalCharacters = 0;
        sentences = new List<string>();
        words = new List<string>();
        //readPath = Application.dataPath + "/Zone-2/zone-2-words.txt";
        //readPath = "zone-2-words.txt";

        //ReadFile(readPath);
        ReadFile2(textFile);
        //AddToLog(); // adds to the onscreen log debug use only

        totalCharacters = 0;
        Debug.Log("Awake script run - word manager created lists and read from file.");
        //textlog.text += "Awake script run - word manager created lists and read from file.\n";
    }

    /**
    public WordManager2()
    {
        sentences = new List<string>();
        words = new List<string>();
        readPath = Application.dataPath + "/Zone-2/zone-2-words.txt";

        ReadFile(readPath);
        //AddToLog(); // adds to the onscreen log debug use only

        totalCharacters = 0;
    }
    **/

    private void ReadFile2(TextAsset file)
    {
        
        string[] fileSentences = file.text.Split("\n"[0]);


        foreach (string sentence in fileSentences)
        {
            string[] sentenceSplit = sentence.Split(null);

            sentences.Add(sentence);
            words.AddRange(sentenceSplit);
            totalCharacters += sentence.Length;
        }
    }

    //private void ReadFile(string filePath)
    //{
    //    //Problems with UWP resulted in this:??

    //    using (StreamReader reader = new StreamReader(new FileStream(readPath, FileMode.Open)))
    //    //StreamReader reader = new StreamReader(filePath);
    //    { 


    //        while (!reader.EndOfStream)
    //        {
    //            string line = reader.ReadLine();
    //            string[] sentWord = line.Split(null);

    //            sentences.Add(line);
    //            totalCharacters += line.Length;
    //            words.AddRange(sentWord);

    //        }
            
    //        //reader.Close();
    //    }
    //}

    private void AddToLog()
    {
        foreach (string line in sentences)
        {
            textlog.text += line + "\n";
        }
    }

}