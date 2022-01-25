using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Audio;

public class TextToSpeechLogic : MonoBehaviour
{
    ///initialiting the position of the spoken text
    int position = 0;
    int negationCounter = 0;
    string speakerstext = "spaceholder";

    /// initializing TextToSpeech-script | new should not be used in combination with a Monobehaviour
    public GameObject audioSource;

    /// Initialising the used objects
    public GameObject syringe;
    public GameObject sponge;
    public GameObject painkiller;

    /// <summary>
    /// Sets the specified text dependent on the position | should also be used for repeat [the current step] & continue, so the animations will be set awake again
    /// <param name="speakerstext">actual output.</param>
    /// </summary>
   
    public void GetText()
    {
        if (position < 8)
        {
            switch (position)
            {
                case 0: //cleaning and sterilising
                    speakerstext = "Welcome to the training lesson for inserting a central line into the internal jungular vein. At first, drape the insertion site and clean it using the cotton pad and some antiseptic solution.";
                    //show the animated sponge
                    sponge.GetComponent<Sponge>().StartAnimation();
                    break;

                case 1: //aplly local aneastetic
                    sponge.GetComponent<Sponge>().StopAnimation();
                    painkiller.GetComponent<PainKiller>().StartAnimation();
                    speakerstext = "Next, draw up 10 ml of lidocaine. Infiltrate local anesthetic all around the site by touching the skin five times with the tip of your needle. Work down toward the vein.";
                    break;

                case 2: //determine vein and show US-image
                    painkiller.GetComponent<PainKiller>().StopAnimation();
                    speakerstext = "Let´s determine the location of the vein. - Take the transducer and place it tranversally just below the apex of the sternocleidomastoid muscle triangle. - The internal jungular vein will appear as a dark elliptical shape."; //[...with the orientation marker of the transducer directed to the patient´s left at 9 o´clock position]]
                    //Show the ultrasound image

                    break;

                case 3: //Insertion
                    speakerstext = "Now take the needle and insert it 0.5 to 1 centimeter laterally to the artery, aiming at a 45 angle to the vertical. In men, aim for the right nipple; in women, aim for the iliac crest.Advance slowly, aspirating all the time, until you enter 3 to 4 centimeter into the vein. - Are you able to aspirate blood?";
                    syringe.GetComponent<Syringe>().StartAnimation();
                    break;

                case 4: //Negation - blood was not aspirated
                    syringe.GetComponent<Syringe>().StopAnimation();
                    speakerstext = "Withdraw the needle, re-enter at the same point, but aim slightly more medially. - Are you now able to aspirate blood?";
                    syringe.GetComponent<Syringe>().StartAnimation();
                    break;

                case 5: //Blood was aspirated > remove the syringe
                    negationCounter = 0;
                    syringe.GetComponent<Syringe>().StopAnimation();
                    speakerstext = "Great! Finally,Remove the syringe. "; //...keeping the needle very still, and immediately put your thumb over the end of the needle.
                    break;
                    /*
                case 6: //Here, The wire should be inserted
                    speakerstext = "";
                    break;
                    */
                case 6: //clear after insertion
                    speakerstext = "Clean the skin around the line using the cotton pad once more, dry, and cover it with occlusive dressings.";
                    sponge.GetComponent<Sponge>().StartAnimation();
                    break;

                case 7: FinishSpeaking();
                    break;
            }
        } else FinishSpeaking();

        GetTextToSpeechStartSpeaking();
    }

    /// <summary>
    /// calls the StartSpeaking function from TextToSpeech, which synthetizes the audio > also used for continue and repeat
    /// </summary>
    public void GetTextToSpeechStartSpeaking() 
    {
//initializing the TextToSpeech-Schript locally
        TextToSpeech textToSpeech = audioSource.GetComponent<TextToSpeech>();
        textToSpeech.StartSpeaking(speakerstext);
    }

    public void StartSpeaking()     //applicable for "start" and "restart training"
    {
        position = 0;
        negationCounter = 0;
        GetText();
    }

    public void FinishSpeaking()
    {
//stop all animations
        sponge.GetComponent<Sponge>().StopAnimation();
        syringe.GetComponent<Syringe>().StopAnimation();
        painkiller.GetComponent<PainKiller>().StopAnimation();

//initializing the TextToSpeech-Schript locally
        TextToSpeech textToSpeech = audioSource.GetComponent<TextToSpeech>();
//if the user made too many mistakes
        if (negationCounter >1 && (position == 3 || position == 4))
        {
             textToSpeech.StartSpeaking("Insertion failed. Please restart or quit the session.");        //GetComponent(TextToSpeech).StartSpeaking("Insertion failed. Please restart or quit the session.");
        }
//if user succeeded
        else textToSpeech.StartSpeaking("Well done, you succeeded!");
//to make sure that the app will quit, the position is being changed to a number > 8
        position = 7;
    }

    public void Next()
    {
//at position 3, skip the "failed insertion"-step
        if(position == 3)
        {
            position = 5;
        } 
        else if(position <=7) position++;

        GetText();
    }

    public void Back()
    {
        //check if it´s the first step > if not, go to the previous step, otherwise repeat the first step
        if (position > 0)
        {
            position--;
        }
        //check if it´s the "insertion-succeeded"-step. if it is this one, do not go to the "insertion failed"-step but to the previous one
        if (position <= 4 && position < 7)
        {
            negationCounter = 0;
            position=3;
        }
        GetText();
    }

    public void StopSpeaking()
    {
//initializing the TextToSpeech-Schript locally
        TextToSpeech textToSpeech = audioSource.GetComponent<TextToSpeech>();
        textToSpeech.StopSpeaking();
//stop all running animations
        sponge.GetComponent<Sponge>().StopAnimation();
        syringe.GetComponent<Syringe>().StopAnimation();
        painkiller.GetComponent<PainKiller>().StopAnimation();
    }

    public void AspirationFailed() //for the "no"-answer
    {
        negationCounter++;
        //aspiration failed for the first time
        if (position == 3 && negationCounter < 2)
        {
            position++;
            GetText();
        }
        //For the 2nd try, repeat the question - the animation is already running
        else if (position == 4 && negationCounter < 2)
        {
            GetTextToSpeechStartSpeaking();
        }
        //if the blood aspiration or the needle insertion fails two times, finish the training
        else if ((position == 3 || position == 4) && negationCounter >= 2)
        {
            FinishSpeaking();
        }
        //If "no" is not an appropriate answer at this moment, repeat the cuurent step until something else is being said
        else GetText();
    }

    public void Approved()
    {
        if(position == 3)
        { 
            position=5; 
        }
        else if(position == 4)
        {
            position++;
        }
//If "yes" is not an appropriate answer at this moment, repeat the current step until something else is being said
        GetText();
    }
}
