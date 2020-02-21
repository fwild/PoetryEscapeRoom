using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WordManager2 : MonoBehaviour {
    
    public TextAsset file;

    //public List<string> sentences;
    public List<string> words;
    public float[] wordOffsets = new float[] {01.229f, 01.388f, 01.575f, 01.672f, 01.945f, 02.385f, 02.494f, 02.783f, 03.056f, 03.308f, 03.674f, 03.776f, 04.199f, 04.427f, 05.693f, 05.864f, 05.986f, 06.116f, 06.433f, 06.775f, 06.946f, 07.141f, 07.459f, 08.130f, 08.269f, 08.521f, 08.635f, 09.074f, 09.176f, 09.416f, 10.958f, 11.080f, 11.337f, 11.447f, 11.723f, 11.890f, 12.126f, 12.973f, 13.082f, 13.408f, 13.567f, 14.096f, 14.222f, 14.360f, 14.478f, 15.854f, 15.980f, 16.395f, 16.537f, 16.781f, 17.062f, 17.192f, 17.550f, 18.104f, 18.490f, 19.451f, 19.614f, 19.703f, 19.911f, 20.004f, 20.069f, 20.383f, 20.509f, 20.667f, 21.131f, 21.461f, 21.575f, 21.774f, 22.556f, 22.800f, 22.987f, 23.333f, 23.512f, 23.658f, 23.915f, 24.012f, 24.252f, 25.127f, 25.347f, 25.449f, 25.758f, 25.949f, 26.108f, 26.409f, 26.580f, 26.804f, 27.374f, 27.504f, 27.955f, 28.082f, 28.204f, 28.261f, 28.659f, 30.176f, 30.380f, 30.508f, 30.819f, 30.993f, 31.146f, 31.693f, 31.805f, 32.060f, 32.530f, 32.739f, 32.938f, 33.041f, 33.176f, 34.496f, 34.654f, 34.792f, 34.935f, 35.134f, 36.334f, 36.502f, 36.635f, 36.753f, 36.931f, 37.079f, 38.708f, 38.984f, 39.254f, 39.351f, 39.464f, 39.673f, 39.755f, 39.867f, 40.250f, 40.332f, 40.480f, 41.859f, 41.950f, 42.129f, 42.400f, 42.584f, 43.012f, 43.130f, 43.232f, 43.487f, 43.829f, 43.977f, 44.871f, 45.019f, 45.075f, 45.305f, 45.703f, 45.795f, 46.050f, 46.224f, 46.326f, 46.510f, 46.668f, 47.061f, 47.164f, 47.307f, 47.741f, 47.884f, 47.996f, 49.073f, 49.201f, 49.298f, 49.456f, 50.835f, 50.983f, 51.105f, 51.269f, 51.723f, 52.004f, 53.638f, 53.883f, 54.026f, 54.256f, 55.481f, 55.742f, 55.854f, 56.022f, 56.130f, 56.783f, 56.931f, 57.314f, 57.493f, 58.698f, 58.846f, 59.086f, 59.188f, 59.413f, 59.918f, 60.174f, 60.296f, 60.587f, 60.934f, 61.144f, 62.017f, 62.201f, 62.379f, 62.696f, 63.038f, 64.600f, 64.800f, 65.050f, 65.417f, 65.479f, 65.953f, 66.030f, 66.188f, 66.505f, 66.643f, 67.112f, 67.485f, 67.904f, 68.190f, 68.501f, 68.690f, 68.787f, 69.073f, 69.262f, 69.625f, 71.345f, 71.468f, 71.585f, 71.749f, 71.999f, 73.183f, 73.342f, 73.439f, 73.597f, 73.888f, 75.226f, 75.435f, 75.537f, 75.910f, 76.594f, 77.038f, 77.238f, 77.626f, 78.734f, 78.866f, 78.963f, 79.183f, 79.556f, 79.627f, 79.928f, 81.133f, 81.307f, 81.399f, 81.608f, 81.802f, 81.899f, 82.068f, 82.359f, 83.794f, 83.921f, 84.064f, 84.177f, 84.422f, 84.549f, 84.973f, 85.535f, 85.764f, 86.362f, 86.694f, 86.913f, 87.261f, 87.531f, 87.970f, 89.185f, 89.323f, 89.415f, 89.609f, 89.977f, 90.069f, 91.626f, 91.805f, 92.040f, 92.377f, 93.995f, 94.113f, 94.215f, 94.491f, 94.828f, 94.930f, 95.144f, 96.778f, 96.890f, 97.059f, 97.340f, 98.626f, 98.831f, 98.984f, 99.152f, 99.208f};

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
        Debug.Log("wordOFfsets.size: " + wordOffsets.Length);
        Debug.Log("words.wordscount: " + words.Count);
    }
   

    private void ReadFile()
    {
        string[] stringWords = file.text.Split(null);

        //foreach (string word in stringWords)
        //{
        //    words.Add(word);
        //    totalCharacters += word.Length;
        //}

        for (int i = 0; i < stringWords.Length; i++)
        {
            string s = stringWords[i];

            if (s.Length != 0)
            {
                words.Add(s);
                totalCharacters += s.Length;
            }
        }

        //consoleLog.text += "WordManager - Finished reading in file to program."; //Hololens in Unbody
        Debug.Log("WordManager - Finished reading in file to program."); //VS debug 
    }
    
}