namespace FORGE;

public partial class ForgeBasePage : ContentPage
{
    public ForgeBasePage()
    {
        InitializeComponent();
    }

    public View PageContent
    {
        get => ContentArea.Content;
        set => ContentArea.Content = value;
    }
}

private async void OnCameraClicked(object sender, EventArgs e) {
        try
        {
            FileResult photo = await MediaPicker.CapturePhotoAsynce();
            if (photo != null) {
                await Application.Current.MainPage.DisplayAlert("Photo Taken", $"Saved: {photo.FileName}", "OK");
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAler("Error", ex.Message, "OK")
    }
    }
