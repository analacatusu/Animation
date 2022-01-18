using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit.Audio;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class TextToSpeechCode : MonoBehaviour
{
    TextToSpeech textToSpeech = new TextToSpeech();

    //initializing of the sentence position > i changes the position in the sentence[]-array > selects the sentence
    private int i = new int();

    //Sample Sentences
    private string[] sentence = {   "clean and drape the insertion site. Infiltrate local anesthetic all around the site, working down toward the vein.",
                                     //Insertion
                                    "palpate the carotid artery with your left hand, covering the artery with your fingers.",
                                    "Insert the needle 0.5–1 cm laterally to the artery, aiming at a 45°angle to the vertical",
                                    "Advance slowly, aspirating all the time, until you enter the vein. Enter 3-4 cm into the vein.",
                                    //"did you aspirate blood after entering 3-4cm?,
                                    //" withdraw, re-enter at the same point, but aim slightly more medially",
                                    "Remove the syringe, keeping the needle very still, and immediately put your thumb over the end of the needle.",
                                    "Great job, you did it!"
                               };
    public void StartTraining()
    {
        i = 0;
        textToSpeech.StartSpeaking("clean and drape the insertion site. Infiltrate local anesthetic all around the site, working down toward the vein.");
    }

    public void Finish()
    {
        i = 0;
        textToSpeech.StopSpeaking();
    }

    //Pauses the application
    public void Pause()
    {
        textToSpeech.StopSpeaking();
    }
    
    public void NextStep()
    {

    }
    public void Back()
    {

    }
}
