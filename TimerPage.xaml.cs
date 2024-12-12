using System;
using System.Timers;  
using Microsoft.Maui.Controls;

namespace Boxing_Trainer_App
{
    public partial class TimerPage : ContentPage
    {
        private System.Timers.Timer _timer;  
        private int _totalSeconds;
        private int _remainingMinutes;
        private int _remainingSeconds;

        public TimerPage()
        {
            InitializeComponent();
            _timer = new System.Timers.Timer(1000);  
            _timer.Elapsed += OnTimerElapsed;
        }

        private void OnStartButtonClicked(object sender, EventArgs e)
        {
            if (_timer.Enabled)
            {
                _timer.Stop();
            }

            if (int.TryParse(MinutesEntry.Text, out int minutes) && int.TryParse(SecondsEntry.Text, out int seconds))
            {
                if (minutes >= 0 && minutes <= 99 && seconds >= 0 && seconds <= 59)
                {
                    _remainingMinutes = minutes;
                    _remainingSeconds = seconds;
                    _totalSeconds = (_remainingMinutes * 60) + _remainingSeconds;

                    _timer.Start();
                    StartButton.IsEnabled = false; 
                }
                else
                {
                    DisplayAlert("Invalid Input", "Please enter a valid time (0-99 minutes, 0-59 seconds).", "OK");
                }
            }
            else
            {
                DisplayAlert("Invalid Input", "Please enter valid numbers for minutes and seconds.", "OK");
            }
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_totalSeconds > 0)
            {
                _totalSeconds--;
                _remainingMinutes = _totalSeconds / 60;
                _remainingSeconds = _totalSeconds % 60;

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    TimerLabel.Text = $"{_remainingMinutes:D2}:{_remainingSeconds:D2}";
                });
            }
            else
            {
                _timer.Stop();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    TimerLabel.Text = "00:00";
                    StartButton.IsEnabled = true; 
                    DisplayAlert("Time's Up", "The timer has finished.", "OK");
                });
            }
        }
    }
}
