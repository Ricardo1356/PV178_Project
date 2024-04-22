using System.Drawing;
using System.Windows.Forms;

public class MulticolorButton : Button
{
    public Color BackgroundColor { get; set; } = Color.FromArgb(230, 230, 250); // Light lavender for the background
    public Color TopBorderColor { get; set; } = Color.FromArgb(147, 112, 219); // Medium purple for the top border
    public Color BottomBorderColor { get; set; } = Color.FromArgb(75, 0, 130); // Dark indigo for the bottom border

    // Black text for readability
    public Color TextColor { get; set; } = Color.Black;

    // Thickness of the borders
    public int BorderThickness { get; set; } = 25;

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        // Use the BackgroundColor for the main button area
        pevent.Graphics.Clear(this.BackgroundColor);

        // Draw the top border with the TopBorderColor
        using (SolidBrush topBorderBrush = new SolidBrush(this.TopBorderColor))
        {
            pevent.Graphics.FillRectangle(topBorderBrush, 0, 0, this.Width, this.BorderThickness);
        }

        // Draw the bottom border with the BottomBorderColor
        using (SolidBrush bottomBorderBrush = new SolidBrush(this.BottomBorderColor))
        {
            pevent.Graphics.FillRectangle(bottomBorderBrush, 0, this.Height - this.BorderThickness, this.Width, this.BorderThickness);
        }

        // Draw the button text in black
        TextRenderer.DrawText(
            pevent.Graphics,
            this.Text,
            this.Font,
            new Rectangle(0, 0, this.Width, this.Height),
            this.TextColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
