namespace FORGE.Pages.DashboardPage;

public partial class DashboardPage : ForgeBasePage
{
    public DashboardPage()
    {
        InitializeComponent();
        CameraButton.IsVisible = false; // Hide global camera icon
    }

    private async void GoToWorkout(object sender, EventArgs e) =>
        await Navigation.PushAsync(new WorkoutGeneratorPage());

    private async void GoToMealPlan(object sender, EventArgs e) =>
        await Navigation.PushAsync(new MealPlanPage());

    private async void GoToChatbot(object sender, EventArgs e) =>
        await Navigation.PushAsync(new AIChatbotPage());

    private async void GoToCalorie(object sender, EventArgs e) =>
        await Navigation.PushAsync(new CalorieTrackerPage());

    private async void GoToMealPlan(object sender, EventArgs e) =>
        await Navigation.PushAsync(new MealPlanPage());
    private async void GoToWaterTracker(object sender, EventArgs e) =>
        await Navigation.PushAsync(new WaterTrackerPage());
}
