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
        //choosing the corresponding sentence
        if (position == 0) { speakerstext = "Welcome to the training session. Once you've cleaned and numbed the site, you can prepare the needle."; }
        else if (position == 1)
        {
            speakerstext = "Palpate the carotid artery with your left hand, covering the artery with your fingers. Insert the needle 0.5 to 1 centimeter laterally to the artery, aiming at a 45 angle to the vertical.";
            //Start Animation
            syringe.GetComponent<toggle>().start_animation();
            //alternatively
            //public toggle Syringe = new toggle();
        }
        else if (position == 2) 
        { syringe.GetComponent<toggle>().stop_animation(); 
          speakerstext = "Advance slowly, aspirating all the time, until you enter the vein.Enter 3 to 4 centimeters into the vein."; 
        }
        else if (position == 3) { speakerstext = "Remove the syringe, keeping the needle very still, and immediately put your thumb over the end of the needle. Great job, you sucessfully inserted the central line!"; }
        else if (position > 3)  {FinishSpeaking();}

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
        textToSpeech.StartSpeaking("Well done and see you soon!");
        //stop animation if it´s running
        if (syringe.GetComponent<toggle>().isActiveAndEnabled) 
        {
            syringe.GetComponent<toggle>().stop_animation(); 
        }
        //quit app
        Application.Quit();
        //to make sure it´s working
        Debug.Log("Game is exiting");
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
