﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using DevDaysSpeakers.Model;
using Plugin.TextToSpeech;

using DevDaysSpeakers.ViewModel;

namespace DevDaysSpeakers.View
{
    public partial class DetailsPage : ContentPage
    {
        Speaker speaker;
        public DetailsPage(Speaker speaker)
        {
            InitializeComponent();
            
            //Set local instance of speaker and set BindingContext
            this.speaker = speaker;
            BindingContext = this.speaker;

            ButtonSpeak.Clicked += ButtonSpeak_Clicked;
            ButtonWebsite.Clicked += ButtonWebsite_Clicked;
        }

        private void ButtonSpeak_Clicked(object sender, EventArgs e)
        {
            CrossTextToSpeech.Current.Speak(this.speaker.Description);
        }

        private void ButtonWebsite_Clicked(object sender, EventArgs e)
        {
            if (speaker.Website.StartsWith("http"))
                Device.OpenUri(new Uri(speaker.Website));
        }
    }
}
