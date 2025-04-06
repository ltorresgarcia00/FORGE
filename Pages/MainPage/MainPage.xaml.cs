namespace FORGE;

public partial class MainPage : ForgeBasePage
{
	int count = 0;
	Button counterBtn;

	public MainPage()
	{
		InitializeComponent();
		
		var title = new Label
		{
			Text = "FORGE",
			FontSize = 32,
			TextColor = Colors.White,
			HorizontalOptions = LayoutOptions.Center,
			FontAttributes = FontAttributes.Bold
		};

		counterBtn = new Button
		{
			Text = "Click me"
		};
		counterBtn.Clicked += OnCounterClicked;

		var layout = new VerticalStackLayout
		{
			Padding = 20,
			Children = {
				title,
				new Button { Text = "Start Workout" },
				new Button { Text = "Start Meal Plan" },
				new Button { Text = "Start Track Water" },
				counterBtn
			}
		};

		PageContent = layout;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		counterBtn.Text = count == 1 ? "Clicked 1 time" : $"Clicked {count} times";
		SemanticScreenReader.Announce(counterBtn.Text);
	}
}


