using Android.Speech.Tts;
using Xamarin.Forms;
using System.Collections.Generic;
using Java.Lang;
using TodoApp.Interface;
using Android.Runtime;

namespace TodoApp.Droid
{
    public sealed class TodoTextToSpeech : Object, ITextToSpeech, TextToSpeech.IOnInitListener
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
            if (!string.IsNullOrWhiteSpace(text))
            {
                toSpeak = text;
                if (speaker == null)
                    speaker = new TextToSpeech(Forms.Context, this);
                else
                {
                    var p = new Dictionary<string, string>();
                    speaker.Speak(toSpeak, QueueMode.Flush, p);
                }
            }
        }
    }
}