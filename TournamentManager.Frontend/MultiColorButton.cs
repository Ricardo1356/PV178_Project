using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class MulticolorButton : Button
{
    private Color _startColor;
    private Color _endColor;

    // Properties to set start and end colors from outside
    public Color StartColor
    {
        get => _startColor;
        set => _startColor = SubdueColor(value);
    }

    public Color EndColor
    {
        get => _endColor;
        set => _endColor = SubdueColor(value);
    }

    public MulticolorButton()
    {
        // Default colors, if not set
        this.StartColor = Color.Red;
        this.EndColor = Color.Blue;
    }

    // Method to blend the color with white to reduce its saturation and brightness
    private Color SubdueColor(Color originalColor)
    {
        // Blend with white (255, 255, 255) to subdue the color
        Color blendWith = Color.FromArgb(255, 255, 255);
        return Color.FromArgb(
            (originalColor.R + blendWith.R) / 2,
            (originalColor.G + blendWith.G) / 2,
            (originalColor.B + blendWith.B) / 2
        );
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        pevent.Graphics.Clear(this.BackColor);

        Rectangle rectangle = new Rectangle(0, 0, this.Width, this.Height);

        using (LinearGradientBrush brush = new LinearGradientBrush(rectangle, this.StartColor, this.EndColor, LinearGradientMode.Horizontal))
        {
            pevent.Graphics.FillRectangle(brush, rectangle);
        }

        // Draw the button text
        TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, rectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
