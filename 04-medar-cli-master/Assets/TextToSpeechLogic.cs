using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Audio;

public class TextToSpeechLogic : MonoBehaviour
{
    //initialiting the position of the spoken text
    int position = 0;
    string speakerstext = "spaceholder";

    //initializing TextToSpeech-script
    TextToSpeech textToSpeech = new TextToSpeech();


    //include toggle into the script
    public GameObject syringe;

    /// Sets the specified text dependent on the position
    /// </summary>
    /// <param name="speakerstext">The text to speak.</param>
    /// 
    public void GetText()
    {
        // Find the Object with tag "syringe_" and get data from it
        syringe = GameObject.FindGameObjectWithTag("syringe_");
        //syringe_ toggle = syringe.GetComponent(typeof(toggle));

        //choosing the corresponding sentence
        if (position == 0) { speakerstext = "Welcome to the training session. Once you've cleaned and numbed the site, you can pick up the needle."; }
        else if (position == 1)
        {
            speakerstext = "palpate the carotid artery with your left hand, covering the artery with your fingers. Insert the needle 0.5–1 cm laterally to the artery, aiming at a 45°angle to the vertical.";
            //Start Animation
            //toggle = syringe.GetComponent<toggle>();

        }
        else if (position == 2) { speakerstext = "Advance slowly, aspirating all the time, until you enter the vein.Enter 3 - 4 cm into the vein."; }
        else if (position == 3) { speakerstext = "Remove the syringe, keeping the needle very still, and immediately put your thumb over the end of the needle. Great job, you sucessfully inserted the central line!"; }
        else if (position > 3)
        {
            speakerstext = "Well done and see you soon";
            //if animation is running, than stop it
            if (position != 1)
            {

            }
        }

        Speak();
    }

    /// <summary>
    /// calls the StartSpeaking function from TextToSpeech, which synthetizes the audio > also used for continue and repeat
    /// </summary>
    /// 
    public void Speak()
    {
        textToSpeech.StartSpeaking(speakerstext);
    }

    /// <summary>
    /// functions corresponding to the input > manage the position trough changing it
    /// </summary>
    /// 
    public void StartSpeaking()     //for "start" and "restart training"
    {
        position = 0;
        GetText();
    }

    public void FinishSpeaking()
    {
        position = 4;
        //stop animation

        GetText();
        //quit app
    }

    public void Next()
    {
        //check if it´s the last step > if not, go to the next step
        if (position <= 4)
        {
            position++;
            GetText();
        }
        else FinishSpeaking();
    }

    public void Back()
    {
        //check if it´s the first step > if not, go to the previous step, otherwise repeat the first step
        if (position > 0)
        {
            position--;
        }
        GetText();
    }

    /// <summary>
    /// Stops speaking
    /// </summary>
    /// 
    public void StopSpeaking()
    {
        textToSpeech.StopSpeaking();
    }
}
