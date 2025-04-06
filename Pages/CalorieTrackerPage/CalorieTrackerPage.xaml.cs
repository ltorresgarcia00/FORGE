namespace FORGE.Pages.CalorieTrackerPage;

public partial class CalorieTrackerPage : ForgeBasePage
{
    private int totalCalories = 0;

    public CalorieTrackerPage()
    {
        InitializeComponent();
        CameraButton.IsVisible = false;
    }

    private void OnAddCalories(object sender, EventArgs e)
    {
        if (int.TryParse(CalorieEntry.Text, out int calories))
        {
            totalCalories += calories;
            TotalCaloriesLabel.Text = $"Total Today: {totalCalories} kcal";
            CalorieEntry.Text = string.Empty;
        }
    }
}
