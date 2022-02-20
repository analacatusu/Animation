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
    public GameObject catheter_1;
    public GameObject ultrasoundProbe;
    public GameObject needle;
    //public GameObject syringe_fade_out;

    //initialize US-images
    //public GameObject usImage1;
    //public GameObject usImage2;

    /// <summary>
    /// Sets the specified text dependent on the position | should also be used for repeat [the current step] & continue, so the animations will be set awake again
    /// <param name="speakerstext">actual output.</param>
    /// </summary>

    public void GetText()
    {
        if (position <= 20)
        {
            switch (position)
            {
                case 0: //cleaning and sterilising
                    // if back
                    painkiller.GetComponent<PainKiller>().StopAnimation();
                    speakerstext = "Welcome to the training lesson for inserting a central line into the right internal jungular vein. At first, drape the insertion site and clean it using the cotton pad and some antiseptic solution.";
                    //show the animated sponge
                    sponge.GetComponent<Sponge>().StartAnimation();
                    break;

                case 1: //aplly local aneastetic
                    // if back
                    ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
                    heart.GetComponent<Heart>().Disappear();
                    sponge.GetComponent<Sponge>().StopAnimation();
                    painkiller.GetComponent<PainKiller>().StartAnimation();
                    speakerstext = "Next, draw up 10 ml of lidocaine. Infiltrate local anesthetic all around the site by touching the skin five times with the tip of your needle. Work down toward the vein.";
                    break;

                case 2: //take US probe
                    painkiller.GetComponent<PainKiller>().StopAnimation();
                    speakerstext = "Until the anaestethics starts to work, always determine the location of the vein using ultrasound to avoid complications. Therefore take a small linear probe and move it like shown.";
                    ultrasoundProbe.GetComponent<Ultrasound>().StartAnimation();
                    heart.GetComponent<Heart>().Appear();
                    break;

                case 3: //show US video
                    ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
                    speakerstext = "Watch the following video to understand what you are expected to see.";
                    // if we got here by "back, stop the animations
                    heart.GetComponent<Heart>().Disappear();
                    syringe.GetComponent<Syringe>().StopAnimation();
                    // Additional text if we do not use the sound from the video:
                    // ...The internal jungular vein will appear as a dark elliptical shape. It is located lateral and superficial to the carotic artery. You can convince yourself further by compression testing. The vein will compress and the artery will remain plump and pulsatile.";
                    //Show the ultrasound video

                    break;

                case 4: //Insertion
                    // if back from 6
                    ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
                    heart.GetComponent<Heart>().Appear();
                    speakerstext = "Now take the compass pressure transducer syringe and insert it 0.5 to 1 centimeter laterally to the artery, aiming at a 45 angle to the vertical. In men, aim for the right nipple; in women, aim for the iliac crest. Advance slowly, aspirating all the time, until you enter 3 to 4 centimeter into the vein. - Are you able to aspirate dark, venous blood?";
                    syringe.GetComponent<Syringe>().StartAnimation();
                    break;

                case 5: //Negation - blood was not aspirated
                    //if we got here by back, stop the US-animation
                    ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
                    speakerstext = "Withdraw the needle, re-enter at the same point, but aim slightly more medially. - Are you now able to aspirate blood?";
                    syringe.GetComponent<Syringe>().StartAnimation();                    
                    break;

                case 6://aspiration was successfull > check with ultrasound
                    //negationCounter = 0;
                    syringe.GetComponent<Syringe>().StopAnimation();
                    //heart.GetComponent<Heart>().Disappear();
                    speakerstext = "Great! Let´s check how the insertion of the tip of the needle into the vein looks like using ultrasound. Take the ultrasound probe again and center it right over the vessel. Mimic the movements.";
                    //ultrasound probe animation
                    ultrasoundProbe.GetComponent<Ultrasound>().StartAnimation();
                    break;

                case 7: // show US video and images
                    //heart.GetComponent<Heart>().Disappear();
                    //if "back" > stop the animations
                    needle.GetComponent<Needle>().Disappear();
                    //syringe_fade_out.GetComponent<Syringe2>().StopAnimation();
                    negationCounter = 0;
                    ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
                    speakerstext = "Watch the following video to see whether you can correctly identify the tip of the needle using ultrasound.";
                    //show ultrasound-video
                    //show ultrasound-image
                    break;

                case 8: //insert wire
                    // if back
                    wire.GetComponent<Wire>().StopAnimation();
                    speakerstext = "Remove the syringe from the needle and cover the tip of the needle with your finger.";
                    needle.GetComponent<Needle>().Appear();
                    heart.GetComponent<Heart>().Appear();
                   // syringe_fade_out.GetComponent<Syringe2>().StartAnimation();
                    break;

                case 9:
                    //if back
                    ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
                   // syringe_fade_out.GetComponent<Syringe2>().StopAnimation();
                    speakerstext = "Once the needle is in the lumen of the jugular vein and you were able to aspirate venous blood, feed the wire into the end of the needle, advance at least 20 centimeters, but only until the colormark on the wire reaches the skin. The wire should advance smoothly. Keep one hand on the wire at all times, until it is removed."; 
                    needle.GetComponent<Needle>().Appear();
                    wire.GetComponent<Wire>().StartAnimation();                  
                    break;

                case 10: //check the wire position with ultrasound
                    speakerstext = "Now let´s confirm the placement of the wire. Take the ultrasound probe again and place it central on the vein.";
                    wire.GetComponent<Wire>().StopAnimation();
                    needle.GetComponent<Needle>().Disappear();
                    //ultrasound probe animation
                    ultrasoundProbe.GetComponent<Ultrasound>().StartAnimation();   
                    break;

                case 11: // check wire position with ultrasound
                    speakerstext = "The wire should look like the following. When it´s too far in, you´ll notice it trough the irregular EKG.";
                    ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
                    //ultrasound image of the wire
                    break;

                case 12: //remove needle
                    // if back
                    dillator.GetComponent<Dillator>().StopAnimation();
                    speakerstext = "If you inserted the wire correctly, remove the needle, keeping the wire in place.";                 
                    break; 

                case 13: //insert & remove dillator
                    //if back
                    catheter_1.GetComponent<Catheter_Part1>().Disappear();
                    speakerstext = "Make a nick in the skin where the wire enters the skin to get the dilator through. Now, grab the dilator and feed it over the wire to the skin. Apply firm but steady pressure, gently oscillating the wire back and forth while twisting the dialator firmly. Only insert the dilator up the depth of the anticipated vein, which is usually no more than 3 to 4 centimeters. Afterwards remove the dialator.";
                    //dillator animation
                    dillator.GetComponent<Dillator>().StartAnimation();                    
                    break; 

                case 14: //put central line on wire
                    dillator.GetComponent<Dillator>().StopAnimation();
                    speakerstext = "Insert the central line over the wire until the wire is poking out of the port. Keep one hand on the wire at all times. Now push the catheter slowly a bit further into the vein.";
                    catheter_1.GetComponent<Catheter_Part1>().Appear();
                    break; 

                case 15: //withdraw wire a bit
                    catheter_1.GetComponent<Catheter_Part1>().Disappear();
                    speakerstext = "Slowly withdraw the wire back through the central line until the wire tip appears from the line port. Hold the wire here. ";
                    break;

                case 16: //insert line completely
                    catheter_1.GetComponent<Catheter_Part1>().Appear();
                    speakerstext = "Insert the line until a few centimeters are left outside the skin.";
                    break;

                case 17: //withdraw wire
                    catheter_1.GetComponent<Catheter_Part1>().Disappear();
                    speakerstext = "Withdraw the wire and immediately clip off the remaining port.";
                    break;

                case 18:
                    //if back
                    sponge.GetComponent<Sponge>().StopAnimation();
                    speakerstext ="Attach the line to the skin with sutures.";
                    break;
         
                case 19: //clear after insertion
                    speakerstext = "Clean the skin around the line using the cotton pad once more, dry, and cover it with occlusive dressings.";
                    sponge.GetComponent<Sponge>().StartAnimation();
                    break;

                case 20: FinishSpeaking();
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
        if (negationCounter > 1 && (position == 4 || position == 5))
        {
            textToSpeech.StartSpeaking("Insertion failed. Please restart or quit the session.");        //alternatively: GetComponent(TextToSpeech).StartSpeaking("Insertion failed. Please restart or quit the session.");
        }
        //if user succeeded
        else if (position == 19 || position == 20)
        {
            textToSpeech.StartSpeaking("Well done, you sucessfully inserted a central line!");
        }
        else textToSpeech.StartSpeaking("Thank you for using the central line insertion training program and see you soon!");
        //to make sure that the app will quit, the position is being changed to a number > 21
        position = 20;
        print("reached here");
        EditorApplication.isPlaying = false;
    }

    public void Next()
    {
//at position 4, skip the "failed insertion"-step
        if(position == 4)
        {
            position = 6;
        } 
        else 
            position++;

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
        if (position == 6)
        {
            negationCounter = 0;
            position = 4;
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
        //heart.GetComponent<Heart>().Disappear();
        ultrasoundProbe.GetComponent<Ultrasound>().StopAnimation();
        wire.GetComponent<Wire>().StopAnimation();
        dillator.GetComponent<Dillator>().StopAnimation();
        //needle.GetComponent<Needle>().Disappear();
        //catheter_1.GetComponent<Catheter_Part1>().Disappear();
}

    public void AspirationFailed() //for the "no"-answer
    {
        negationCounter++;
        //aspiration failed for the first time
        if (position == 4 && negationCounter < 2)
        {
            position++;
            GetText();
        }
        //For the 2nd try, repeat the question - the animation is already running
        else if (position == 5 && negationCounter < 2)
        {
            GetTextToSpeechStartSpeaking();
        }
        //if the blood aspiration or the needle insertion fails two times, finish the training
        else if ((position == 4 || position == 5) && negationCounter >= 2)
        {
            FinishSpeaking();
        }
        //If "no" is not an appropriate answer at this moment, do nothing
    }

    public void Approved()
    {
        if(position == 4 || position == 5)
        { 
            position=6; 
        }
//If "yes" is not an appropriate answer at this moment, do nothing
    }
}
