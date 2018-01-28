using AVFoundation;
using TodoApp.Interface;

namespace TodoApp.iOS.Helper
{
    public class SpeechText : ITextToSpeech
    {
        private float volume = 0.5f;
        private float pitch = 1.0f;


        /// <summary>
		/// Speak example from: 
		/// http://blog.xamarin.com/make-your-ios-7-app-speak/
		/// </summary>
        public void Speak(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var speechSynthesizer = new AVSpeechSynthesizer();
                var speechUtterence = new AVSpeechUtterance(text)
                {
                    Rate = AVSpeechUtterance.MaximumSpeechRate / 3,
                    Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                    Volume = volume,
                    PitchMultiplier = pitch
                };

                speechSynthesizer.SpeakUtterance(speechUtterence);
            }
        }
    }
}