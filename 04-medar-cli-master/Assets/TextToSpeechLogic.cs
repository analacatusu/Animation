using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using Microsoft.MixedReality.Toolkit.Audio;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class TextToSpeechLogic : MonoBehaviour
{
    public string[] keywords = new string[] { "start", "finish", "pause", "continue", "next step", "back", "repeat", "restart training" };
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public float speed = 1;

    //create as many target Objects as you need for manipulation
    public GameObject target1;
    //public GameObject target2;
    //public Animation AnimationTarget1;
    //public Animation AnimationTarget2;

    protected PhraseRecognizer recognizer;
    protected string word = "right";

    TextToSpeech textToSpeech = new TextToSpeech();
    //Sample Sentences
    private string[] sentence = {   "clean and drape the insertion site. Infiltrate local anesthetic all around the site, working down toward the vein.",
                              //Insertion
                                    "palpate the carotid artery with your left hand, covering the artery with your fingers. Insert the needle 0.5–1 cm laterally to the artery, aiming at a 45°angle to the vertical",
                                    "Advance slowly, aspirating all the time, until you enter the vein. Enter 3-4 cm into the vein.",
                                    //"did you aspirate blood after entering 3-4cm?,
                                    //" withdraw, re-enter at the same point, but aim slightly more medially",
                                    "Remove the syringe, keeping the needle very still, and immediately put your thumb over the end of the needle.",
                                    "Great job, you did it!"
                               };

    private void Start()
    {
        if (keywords != null)
        {
            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
            Debug.Log(recognizer.IsRunning);
        }

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
    }

    private void Update()
    {
        switch (word)
        {
            case "start":
                textToSpeech.StartSpeaking(sentence[1]);
                break;
            case "finish":
                break;
            case "pause":
                break;
            case "continue":
                break;
            case "next step":
                break;
            case "back":
                break;
            case "repeat":
                break;
            case "restart training":
                break;
        }

    }
    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}