using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace Boxing_Trainer_App
{
    public partial class Description : ContentPage
    {
        public Description(string title, string videoSource, string description)
        {
            InitializeComponent();

            Title = title;
            descriptionLabel.Text = description;

            if (!string.IsNullOrEmpty(videoSource))
            {
                videoPlayer.Source = new Uri(videoSource);
            }

        }
    }
}