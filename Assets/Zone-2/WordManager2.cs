using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WordManager2 : MonoBehaviour {
    
    public TextAsset file;

    //public List<string> sentences;
    public List<string> words;

    public int totalCharacters;

    public Text consoleLog;
    
    void Start()
    {
        //sentences = new List<string>();
        //words = new List<string>();

        totalCharacters = 0;

        ReadFile();

        //consoleLog.text += "WordManager - Start routine and ReadFile complete."; //Hololens in Unbody
        Debug.Log("WordManager - Start routine and ReadFile complete."); //VS debug
    }
   

    private void ReadFile()
    {
        string[] stringWords = file.text.Split(null);

        foreach (string word in stringWords)
        {
            words.Add(word);
            totalCharacters += word.Length;
        }

        //for (int i=0; i<stringWords.Length; i++)
        //{
        //    string s = stringWords[i];
            
        //    if (s.Length != 0)
        //    {
        //        words.Add(s);
        //        totalCharacters += s.Length;
        //    }
        //}

        //consoleLog.text += "WordManager - Finished reading in file to program."; //Hololens in Unbody
        Debug.Log("WordManager - Finished reading in file to program."); //VS debug 
    }
    
}