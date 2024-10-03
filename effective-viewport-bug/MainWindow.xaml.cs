using Microsoft.UI.Xaml;

namespace effective_viewport_bug;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        this.InitializeComponent();

        this.AppWindow.Resize(new Windows.Graphics.SizeInt32(300, 300));
    }

    private void myButton_Click(object sender, RoutedEventArgs e)
    {
        (new SomeOtherWindow()).Activate();
    }

    private void TextBlock_EffectiveViewportChanged(FrameworkElement sender, EffectiveViewportChangedEventArgs args)
    {
    }

    private void myButton2_Click(object sender, RoutedEventArgs e)
    {
        this.PART_DisclaimerText.EffectiveViewportChanged -= this.TextBlock_EffectiveViewportChanged;
        this.PART_DisclaimerText.EffectiveViewportChanged += this.TextBlock_EffectiveViewportChanged;

        this.PART_DisclaimerText.Text = "Registered";
    }

    private void myButton3_Click(object sender, RoutedEventArgs e)
    {
        this.PART_DisclaimerText.EffectiveViewportChanged -= this.TextBlock_EffectiveViewportChanged;

        this.PART_DisclaimerText.Text = "Unregistered";
    }
}
