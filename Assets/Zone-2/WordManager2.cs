﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WordManager2 : MonoBehaviour {

    string readPath;

    public List<string> sentences;
    public List<string> words;

    public Text textlog;

    void Start()
    {
        readPath = Application.dataPath + "/Zone-2/zone-2-words.txt";

        ReadFile(readPath);
        AddToLog(); // adds to the onscreen log debug use only
    }

    private void ReadFile(string filePath)
    {
        //Problems with UWP resulted in this:??

        using (StreamReader reader = new StreamReader(new FileStream(readPath, FileMode.Open)))
        //StreamReader reader = new StreamReader(filePath);
        { 


            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] sentWord = line.Split(null);

                sentences.Add(line);
                words.AddRange(sentWord);

            }
            
            //reader.Close();
        }
    }

    private void AddToLog()
    {
        foreach (string line in sentences)
        {
            textlog.text += line + "\n";
        }
    }

}