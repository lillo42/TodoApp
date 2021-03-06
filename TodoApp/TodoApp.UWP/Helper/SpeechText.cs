﻿using System;
using System.Diagnostics;
using TodoApp.Interface;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;

namespace TodoApp.UWP.Helper
{
    public class SpeechText : ITextToSpeech
    {
        // http://msdn.microsoft.com/en-us/library/windowsphone/develop/jj207057(v=vs.105).aspx
        public async void Speak(string text)
        {
            var sythn = new SpeechSynthesizer();
            try
            {
                SpeechSynthesisStream stream = await sythn.SynthesizeTextToStreamAsync(text);

                var mediaElement = new MediaElement();
                mediaElement.SetSource(stream, stream.ContentType);
                mediaElement.Play();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
    }
}
