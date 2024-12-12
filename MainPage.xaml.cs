using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace Boxing_Trainer_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnImageTapped(object sender, TappedEventArgs e)
        {
            if (e.Parameter == null)
            {
                await DisplayAlert("Error", "No parameter found!", "OK");
                return;
            }

            string parameter = e.Parameter as string;
            string title = "";
            string videoUrl = "";
            string description = "";

            switch (parameter)
            {
                case "jogging":
                    title = "Jogging Warm-Up";
                    videoUrl = "https://drive.google.com/uc?export=download&id=1tSt0ZYVwRczfg3A7XW26w_62dQ5aIy0R"; // Updated to direct link
                    description = "Definition: Steady, low-intensity running over a prolonged period, typically at a pace where conversation is possible.\n\n" +
                                  "Duration: 20–30 minutes of continuous running at a moderate pace.\n\n" +
                                  "Benefit: Improves cardiovascular fitness, increases stamina, and helps with fat burning.";
                    break;

                case "sprint":
                    title = "Sprint Warm-Up";
                    videoUrl = "https://drive.google.com/uc?export=download&id=1r5D6pIx1oRP5yLlr-HpaXQ9wcBwCgyU5"; // Updated to direct link
                    description = "Definition: Short bursts of high-intensity running followed by a period of rest or slow jogging.\n\n" +
                                  "Duration: 10–12 sprints, each lasting 20–30 seconds with a rest period of 1-2 minutes between each sprint.\n\n" +
                                  "Benefit: Improves speed, anaerobic power, and leg strength.";
                    break;

                case "jump_rope":
                    title = "Jump Rope Warm-Up";
                    videoUrl = "https://drive.google.com/uc?export=download&id=1YZC8zn7Glwbic_285ENcmbkOJxbMG45O"; // Updated to direct link
                    description = "Definition: A rhythmic exercise where you skip rope continuously, improving coordination and agility.\n\n" +
                                  "Duration: 3–5 minutes per round, with short rest breaks between rounds.\n\n" +
                                  "Benefit: Enhances cardiovascular health, footwork, and endurance.";
                    break;

                case "shadow_box":
                    title = "Shadow Boxing Warm-Up";
                    videoUrl = "https://drive.google.com/uc?export=download&id=1DudkYdfDPeesXAHPYebOBhFtKpCp88Zo"; // Updated to direct link
                    description = "Definition: Practicing punches and footwork combinations in the air, without a physical opponent.\n\n" +
                                  "Duration: 3-minute rounds with 1-minute rest between rounds.\n\n" +
                                  "Benefit: Improves technique, agility, and mental focus.";
                    break;

                case "back_peck":
                    title = "Back Peck Stretch";
                    videoUrl = "https://drive.google.com/uc?export=download&id=1IgtVToSjH1gkPfTQTDUe3z_1iUv_vm5i"; // Updated to direct link
                    description = "Definition: A static stretch where you extend your arms back and open your chest.\n\n" +
                                  "Duration: Hold for 15–30 seconds per set, with 2–3 sets per side.\n\n" +
                                  "Benefit: Increases flexibility in the chest and shoulders.";
                    break;

                case "reach_up_back":
                    title = "Reach Up and Back Stretch";
                    videoUrl = "https://drive.google.com/uc?export=download&id=1auSgBs4bLw2-0EUYTbQ1rBsYR6vu1MLA"; // Updated to direct link
                    description = "Definition: A dynamic movement where you stand with feet shoulder-width apart and reach upward and back.\n\n" +
                                  "Duration: Perform 8–10 repetitions per side.\n\n" +
                                  "Benefit: Stretches the back, shoulders, and arms.";
                    break;

                case "jab":
                    title = "Jab Punch";
                    videoUrl = "https://drive.google.com/uc?export=download&id=15r3fhwteqk9UzEZ3DliCGDEIFW_VVItb"; // Updated to direct link
                    description = "Definition: A straight punch thrown with the lead hand, designed to keep the opponent at distance.\n\n" +
                                  "Repetitions: 3 sets of 10–15 jabs per round.\n\n" +
                                  "Benefit: Improves punching speed, precision, and hand-eye coordination.";
                    break;

                case "cross":
                    title = "Cross Punch";
                    videoUrl = "https://drive.google.com/uc?export=download&id=1o4d4kiRSag7QBcWD4y1uXSmb_qL682fg"; // Updated to direct link
                    description = "Definition: A powerful, straight punch delivered with the rear hand, aimed at the opponent's head or torso.\n\n" +
                                  "Repetitions: 3 sets of 8–12 crosses per round.\n\n" +
                                  "Benefit: Builds punching power, strength, and speed.";
                    break;

                case "hook":
                    title = "Hook Punch";
                    videoUrl = "https://drive.google.com/uc?export=download&id=1J1MrYMwngIhi1kC9awaqXPaBqs5OvDfB"; // Updated to direct link
                    description = "Definition: A curved punch targeting the side of the opponent’s head or body.\n\n" +
                                  "Repetitions: 3 sets of 8–12 hooks per side.\n\n" +
                                  "Benefit: Develops punching power and improves striking angles.";
                    break;

                case "uppercut":
                    title = "Uppercut Punch";
                    videoUrl = "https://drive.google.com/uc?export=download&id=1D-Yh59aGS4J4FdEvVbwypM14x4NY0lz2"; // Updated to direct link
                    description = "Definition: An upward punch aimed at the opponent’s chin, designed to break through defense.\n\n" +
                                  "Repetitions: 3 sets of 8–12 uppercuts per side.\n\n" +
                                  "Benefit: Builds upper body power and improves punch variety.";
                    break;
            }
            await Navigation.PushAsync(new Description(title, videoUrl, description));
        }
    }
}
