using Android.Runtime;
using Android.Speech.Tts;
using Java.Lang;
using System.Collections.Generic;
using TodoApp.Interface;
using Xamarin.Forms;

namespace TodoApp.Droid.Helpers
{
    public class SpeechText : Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech speaker;
        private string toSpeak;

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if(status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Flush, new Dictionary<string, string>());
            }
        }

        public void Speak(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                toSpeak = text;
                if (speaker == null)
                    speaker = new TextToSpeech(Forms.Context, this);
                else
                    speaker.Speak(text, QueueMode.Flush, new Dictionary<string, string>());
            }
        }
    }
}