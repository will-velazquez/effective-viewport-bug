using Microsoft.UI.Xaml;
using System.Linq;

namespace effective_viewport_bug;

public sealed partial class SomeOtherWindow : Window
{
    public SomeOtherWindow()
    {
        this.InitializeComponent();

        this.AppWindow.Resize(new Windows.Graphics.SizeInt32(300, 600));
    }

    private void Rectangle_EffectiveViewportChanged(FrameworkElement sender, EffectiveViewportChangedEventArgs args)
    {
        string? prev = this.PART_StatusText.Text;

        if (!string.IsNullOrEmpty(prev))
        {
            prev = prev.Split('\n').LastOrDefault() ?? string.Empty;
        }

        string str = $"{args.BringIntoViewDistanceX}/{args.BringIntoViewDistanceY}/{args.EffectiveViewport.Width}/{args.EffectiveViewport.Height}/{args.MaxViewport.Width}/{args.MaxViewport.Height}";

        if (!string.IsNullOrEmpty(prev))
        {
            str = $"Previous:\n{prev}\nCurrent:\n{str}";
        }

        this.PART_StatusText.Text = str;
    }
}
