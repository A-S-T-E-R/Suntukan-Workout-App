using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Maui.Controls;

namespace Boxing_Trainer_App
{
    public partial class RoutinesPage : ContentPage
    {
        private DatabaseHelper dbHelper;

        public List<string> Days { get; set; }
        public List<string> Exercises { get; set; }

        private List<int> selectedExerciseIds = new List<int>();
        private Exercise selectedExerciseToEdit = null;

        public RoutinesPage()
        {
            InitializeComponent();
            BindingContext = this;

            Days = new List<string>
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            };

            Exercises = new List<string>
            {
                "Back Pec Stretch", "Cross Punch", "Hook Punch", "Jab Punch", "Jogging", "Jump Rope",
                "Reach Up Back Stretch", "Shadow Boxing", "Sprint", "Uppercut Punch"
            };

            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "exercises.db3"
            );

            dbHelper = new DatabaseHelper(dbPath);

            daysPicker.ItemsSource = Days;
            exercisesPicker.ItemsSource = Exercises;

            DisplayExercises(0);
        }

        private void OnAddExerciseClicked(object sender, EventArgs e)
        {
            if (daysPicker.SelectedIndex == -1 || exercisesPicker.SelectedItem == null)
            {
                DisplayAlert("Error", "Please select both a day and an exercise.", "OK");
                return;
            }

            int selectedDay = daysPicker.SelectedIndex + 1;
            string selectedExercise = exercisesPicker.SelectedItem.ToString();

            dbHelper.AddExercise(selectedDay, selectedExercise);
                DisplayExercises(selectedDay);  
        }

        private void OnDeleteExerciseClicked(object sender, EventArgs e)
        {
            foreach (var exerciseId in selectedExerciseIds)
            {
                dbHelper.DeleteExercise(exerciseId);
            }
            selectedExerciseIds.Clear();

            if (daysPicker.SelectedIndex != -1)
            {
                int selectedDay = daysPicker.SelectedIndex + 1;
                DisplayExercises(selectedDay);
            }
        }

        private void OnEditExerciseClicked(object sender, EventArgs e)
        {
            if (selectedExerciseToEdit != null)
            {
                var editEntry = new Entry
                {
                    Text = selectedExerciseToEdit.ExercisesName,
                    Placeholder = "Edit Exercise Name"
                };

                var editButton = new Button
                {
                    Text = "Save"
                };
                editButton.Clicked += (s, ev) =>
                {
                    string newName = editEntry.Text.Trim();
                    if (string.IsNullOrEmpty(newName))
                    {
                        DisplayAlert("Error", "Exercise name cannot be empty.", "OK");
                        return;
                    }

                    dbHelper.UpdateExercise(selectedExerciseToEdit.Id, newName);
                    DisplayExercises(daysPicker.SelectedIndex + 1); 
                };

                exercisesStack.Children.Add(editEntry);
                exercisesStack.Children.Add(editButton);
            }
        }

        private void DisplayExercises(int dayId)
        {
            exercisesStack.Children.Clear();
            selectedExerciseIds.Clear(); 

            for (int i = 1; i <= 7; i++)
            {
                var dayExercises = dbHelper.GetExercisesForDay(i);
                var dayLabel = new Label
                {
                    Text = Days[i - 1], 
                    FontAttributes = FontAttributes.Bold,
                    HorizontalOptions = LayoutOptions.Start
                };

                var exercisesLayout = new StackLayout
                {
                    Children = { dayLabel }
                };

                if (dayExercises.Count > 0)
                {
                    foreach (var exercise in dayExercises)
                    {
                        var exerciseCheckBox = new CheckBox
                        {
                            IsChecked = false
                        };

                        exerciseCheckBox.CheckedChanged += (sender, e) =>
                        {
                            if (e.Value)
                            {
                                selectedExerciseIds.Add(exercise.Id);
                                selectedExerciseToEdit = exercise; 
                            }
                            else
                            {
                                selectedExerciseIds.Remove(exercise.Id);
                                if (selectedExerciseToEdit != null && selectedExerciseToEdit.Id == exercise.Id)
                                {
                                    selectedExerciseToEdit = null; 
                                }
                            }
                        };

                        var exerciseLayout = new HorizontalStackLayout
                        {
                            Spacing = 10,
                            Children =
                            {
                                exerciseCheckBox,
                                new Label { Text = exercise.ExercisesName, VerticalOptions = LayoutOptions.Center }
                            }
                        };

                        exercisesLayout.Children.Add(exerciseLayout);
                    }
                }
                else
                {
                    var noExercisesLabel = new Label
                    {
                        Text = "No exercises scheduled",
                        TextColor = Colors.Gray,
                        VerticalOptions = LayoutOptions.Center
                    };
                    exercisesLayout.Children.Add(noExercisesLabel);
                }

                exercisesStack.Children.Add(exercisesLayout);
            }
        }
    }
}
