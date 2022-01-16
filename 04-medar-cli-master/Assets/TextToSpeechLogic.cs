using System.Collections;
using System.Collections.Generic;

using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class TextToSpeechLogic : MonoBehaviour, IInputClickHandler
{
    private TextToSpeech tts;
    public string speakText;

    private void Awake()
    {
        tts = GetComponent<TextToSpeech>();
    }

    public void OnInputClicked (InputClickedEventData eventData)
    {
        //create message
        var message = string.Format(speakText, tts.Voice.ToString());

        //spoken message
        tts.StartSpeaking(message);
    }
   
}
