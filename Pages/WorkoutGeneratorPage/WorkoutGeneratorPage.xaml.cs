namespace Generate Workout
{

public partial class: MainPage : ContentPage

{


private Dictionary,string, List,<string>> workoutCategories;

private Random random;

public MainPage()
{

    InitializeComponent();
    random = new Random();

    workoutCategories = new Dictionary<string, List, string>>
{

        { "Hang", new List<string> {"Knee Tucks", "Leg Raise", "One Arm Hang", Cycle" }},
{"Core1", new List<string> {"Plank", "High Low", "Shoulder Tap", "Plank Jacks"}},
{"Core2", new List<string> {"In & Out", "Reverse Crunch", "Leg Raise"}},
{"Obliques", new List<string> {"Russian Twist", "Side Plank", "Side Raise"}},
{"Core3", new List<string> {"Plank", "High Low", "Shoulder Tap", "Plank Jacks"}},
{"Jump", new List<string> {"Squat Jump", "Box Jump", "Lunge Jump"}},
{ "Strength", new List<string> { "Clean", "Thruster" } },
{ "Strength2", new List<string> { "Overhead Squat", "Snatch", "Plate Snatch to Lunge" } },
{ "Strength3", new List<string> { "Squat Reach" } },
{ "Strength4", new List<string> { "Barbell Rows" } },
{ "Lunge", new List<string> { "Squat Walk", "Overhead Lunge", "Step Up", "Step-Up Barbell" } }
            };
        }

        private void OnGenerateWorkoutClicked(object sender, EventArgs e)
{
    if (DurationPicker.SelectedIndex == -1)
    {
        WorkoutResult.Text = "Please select a workout duration!";
        return;
    }

    int duration = (DurationPicker.SelectedIndex == 0) ? 20 : 45;
    List<string> workoutPlan = GenerateWorkoutPlan(duration);

    WorkoutResult.Text = "Your Workout:\n" + string.Join("\n", workoutPlan);
}

private List<string> GenerateWorkoutPlan(int duration)
{
    List<string> plan = new List<string>();

    if (duration == 45)
    {
        plan.Add(PickRandom("Hang"));
        plan.Add(PickRandom("Jump"));
        plan.Add(PickRandom("Core3"));
        plan.Add(PickRandom("Core2"));
        plan.Add(PickRandom("Strength2"));
        plan.Add(PickRandom("Core1"));
        plan.Add(PickRandom("Strength"));
        plan.Add(PickRandom("Obliques"));
        plan.Add(PickRandom("Strength4"));
        plan.Add(PickRandom("Strength3"));
        plan.Add(PickRandom("Lunge"));
    }
    else if (duration == 20)
    {
        plan.Add(PickRandom("Jump"));
        plan.Add(PickRandom("Strength2"));
        plan.Add(PickRandom("Core2"));
        plan.Add(PickRandom("Strength"));
        plan.Add(PickRandom("Core3"));
    }

    return plan;
}

private string PickRandom(string category)
{
    if (workoutCategories.ContainsKey(category) && workoutCategories[category].Count > 0)
    {
        int index = random.Next(workoutCategories[category].Count);
        return workoutCategories[category][index];
    }
    return "No exercise available";
}
}
}
}
}
