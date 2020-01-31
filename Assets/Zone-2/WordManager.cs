using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WordManager : MonoBehaviour {

    string readPath;

    public List<string> sentences;
    public List<String> words;

    public Text textlog;

	void Start () {
        readPath = Application.dataPath + "/Zone-2/zone-2-words.txt";

        readFile(readPath);
        addToLog();
	}

    private void readFile(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] sentWord = line.Split(null);

            sentences.Add(line);
            words.AddRange(sentWord);
            
        }

        reader.Close();
    }

    private void addToLog()
    {
        foreach (String line in sentences)
        {
            textlog.text += line + "\n";
        }
    }
    
}
