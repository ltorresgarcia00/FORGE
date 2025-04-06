using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace FORGE.Pages.AIChatbotPage;

public partial class AIChatbotPage : ForgeBasePage
{
    public ObservableCollection<string> Messages { get; set; } = new();

    public AIChatbotPage()
    {
        InitializeComponent();

        CameraButton.IsVisible = false; // Hide floating camera
        BindingContext = this;
    }

    private void OnSendClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(ChatInput.Text))
        {
            Messages.Add("You: " + ChatInput.Text);
            Messages.Add("Forge AI: " + GenerateBotReply(ChatInput.Text));
            ChatInput.Text = string.Empty;
        }
    }

    private string GenerateBotReply(string input)
    {
        // TEMP: Fake AI reply
        if (input.ToLower().Contains("body"))
            return "Want to scan your body now? Tap the 📷 icon!";
        return "Working on that... 💪";
    }

    private async void OnCameraIconClicked(object sender, EventArgs e)
    {
        try
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            if (photo != null)
            {
                Messages.Add("📸 Photo captured for body analysis!");
                Messages.Add("Forge AI: Analyzing your muscle groups...");
                // Here: send photo to an AI model or server
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Camera Error", ex.Message, "OK");
        }
    }
}
