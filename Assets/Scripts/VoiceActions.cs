using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceActions : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, string> actions = new Dictionary<string, string>();

    void Start()
    {
        actions.Add("Help", "Help");
        actions.Add("Dad", "Dad");
        actions.Add("Please", "Please");

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        //actions[speech.text].Invoke();
    }
}
