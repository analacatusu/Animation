using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Audio;
using UnityEditor;

public class TextToSpeechLogic : MonoBehaviour
{
    ///initialiting the position of the spoken text
    int position = 0;
    int negationCounter = 0;
    string speakerstext = "spaceholder";

    /// initializing TextToSpeech-script | new should not be used in combination with a Monobehaviour
    public GameObject audioSource;

    /// Object initialisation
    public GameObject syringe;
    public GameObject sponge;
    public GameObject painkiller;
    public GameObject heart;
    public GameObject needleTip; //for activating needle tracking
    public GameObject wire;
    public GameObject dillator;
    public GameObject catheter;
    public GameObject ultrasoundProbe;
    public GameObject needle;

    //initialize US-images
    //public GameObject usImage1;
    //public GameObject usImage2;

    /// <summary>
    /// Sets the specified text dependent on the position | should also be used for repeat [the current step] & continue, so the animations will be set awake again
    /// <param name="speakerstext">actual output.</param>
    /// </summary>

    public void GetText()
    {
        if (position < 15)
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

                case 2: //take US probe
                    painkiller.GetComponent<PainKiller>().StopAnimation();
                    speakerstext = "Until the anaestethics starts to work, always determine the location of the vein with ultrasound to avoid complications.";
                    speakerstext = "Now take the ultrasound probe and follow the movements that are shown to you";
                    ultrasoundProbe.GetComponent<Ultrasound>().StartAnimation();
                    break;

                case 3: //show US video
                    ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
                    speakerstext = "Watch the following video to understand what you are expected to see";
                    // Additional text if we do not use the sound from the video:
                    // ...The internal jungular vein will appear as a dark elliptical shape. It is located lateral and superficial to the carotic artery. You can convince yourself further by compression testing. The vein will compress and the artery will remain plump and pulsatile.";
                    //Show the ultrasound video
                    break;

                case 4: //Insertion
                    heart.GetComponent<Heart>().Appear();
                    speakerstext = "Now take the needle and insert it 0.5 to 1 centimeter laterally to the artery, aiming at a 45 angle to the vertical. In men, aim for the right nipple; in women, aim for the iliac crest. Advance slowly, aspirating all the time, until you enter 3 to 4 centimeter into the vein. - Are you able to aspirate dark, venous blood?";
                    syringe.GetComponent<Syringe>().StartAnimation();
                    break;

                case 5: //Negation - blood was not aspirated
                    syringe.GetComponent<Syringe>().StopAnimation();
                    speakerstext = "Withdraw the needle, re-enter at the same point, but aim slightly more medially. - Are you now able to aspirate blood?";
                    syringe.GetComponent<Syringe>().StartAnimation();
                    break;

                case 6://aspiration was successfull > check with ultrasound
                    //negationCounter = 0;
                    syringe.GetComponent<Syringe>().StopAnimation();
                    //heart.GetComponent<Heart>().Disappear();
                    speakerstext = "Great! Let´s check how the insertion of the tip of the needle into the vein looks like using ultrasound.";
                    speakerstext = "Take again the ultrasound probe.";
                    //ultrasound probe animation
                    ultrasoundProbe.GetComponent<Ultrasound>().StartAnimation();
                    break;

                case 7: // show US video and images
                    negationCounter = 0;
                    ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
                    speakerstext = "Watch the following video to see check whether you can correctly identify the tip of the needle with ultrasound.";
                    //show ultrasound-video

                    //show ultrasound-image
                    break;

                case 8: //Blood was aspirated > remove the syringe
                    speakerstext = "Once the needle is in the lumen of the jugular vein and you were able to aspirate dark venous blood, very carefully remove the syringe from the needle, keeping it very still.";
                    break;

                case 9: //insert wire
                    speakerstext = "If you are using the compass pressure transducer, you can feed the wire trough it, so you don´t have to remove the syringe. Take the wire and insert it into the end of the needle, advance at least 20 centimeters, but only until the colormark on the wire reaches the skin. The wire should advance smoothly. Keep one hand on the wire at all times, until it is removed.";
                    needle.GetComponent<Needle>().Appear();
                    wire.GetComponent<Wire>().StartAnimation();
                    break;

                case 10: //check the wire position with ultrasound
                    speakerstext = "Now let´s confirm the placement of the wire. Take the ultrasound probe again";
                    wire.GetComponent<Wire>().StopAnimation();
                    needle.GetComponent<Needle>().Disappear();
                    //ultrasound probe animation
                    ultrasoundProbe.GetComponent<Ultrasound>().StartAnimation();   
                    break;

                case 11: // check wire position with ultrasound
                    speakerstext = "The wire should look like the following picture.";
                    ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
                    //ultrasound image of the wire

                    break;

                case 12: //remove needle
                    speakerstext = "Next, remove the needle, keeping the wire in place.";
                    break; 

                case 13: //insert & remove dillator
                    speakerstext = "Make a nick in the skin where the wire enters the skin to get the dilator through. Now, grab the dilator and feed it over the wire to the skin. Apply firm but steady pressure, gently oscillating the wire back and forth while twisting the dialator firmly, to dialate the skin. Only insert the dilator up the depth of the anticipated vein, which is usually no more than 3 to 4 centimeters. Afterwards remove the dialator.";
                    //dialator animation
                    dillator.GetComponent<Dillator>().StartAnimation();
                    break; 

                case 14: //put central line on wire
                    dillator.GetComponent<Dillator>().StopAnimation();
                    speakerstext = "Insert the central line over the wire until the wire is poking out of the port. Keep one hand on the wire at all times. Now push the catheter slowly a bit further into the vein.";
                    break; 

                case 15: //withdraw wire a bit
                    speakerstext = "Slowly withdraw the wire back through the central line until the wire tip appears from the line port. Hold the wire here. ";
                    break;

                case 16: //insert line completely
                    speakerstext = "Insert the line until a few centimeters are left outside the skin.";
                    
                    break;

                case 17: //withdraw wire
                    speakerstext ="Withdraw the wire and immediately clip off the remaining port.";
                    break;

                case 18://us-image of catheter
                    speakerstext = "";
                    break;

                case 19:
                    speakerstext ="Attach the line to the skin with sutures.";
                    break;
         
                case 20: //clear after insertion
                    speakerstext = "Clean the skin around the line using the cotton pad once more, dry, and cover it with occlusive dressings.";
                    sponge.GetComponent<Sponge>().StartAnimation();
                    break;

                case 21: FinishSpeaking();
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
        heart.GetComponent<Heart>().Disappear();

//initializing the TextToSpeech-Schript locally
        TextToSpeech textToSpeech = audioSource.GetComponent<TextToSpeech>();
//if the user made too many mistakes
        if (negationCounter >1 && (position == 3 || position == 4))
        {
             textToSpeech.StartSpeaking("Insertion failed. Please restart or quit the session.");        //GetComponent(TextToSpeech).StartSpeaking("Insertion failed. Please restart or quit the session.");
        }
//if user succeeded
        else textToSpeech.StartSpeaking("Well done, you sucessfully inserted a central line!");
//to make sure that the app will quit, the position is being changed to a number > 8
        position = 8;
        print("reached here");
        EditorApplication.isPlaying = false;
    }

    public void Next()
    {
//at position 3, skip the "failed insertion"-step
        if(position == 3)
        {
            position = 5;
        } 
        else if(position <=8) position++;

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
        if (position <= 4 && position < 8)
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
        heart.GetComponent<Heart>().Disappear();
        ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
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
        //If "no" is not an appropriate answer at this moment, do nothing
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
//If "yes" is not an appropriate answer at this moment, do nothing
    }
}
