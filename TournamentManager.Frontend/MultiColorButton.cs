﻿using System.Drawing;
using System.Windows.Forms;
using TournamentManager.Backend.Structures;

public class MulticolorButton : Button
{
    public Color BackgroundColor { get; set; } = Color.FromArgb(255, 255, 255);
    public Color TopBorderColor { get; set; } = Color.FromArgb(255, 255, 255);
    public Color BottomBorderColor { get; set; } = Color.FromArgb(255, 255, 255);

    public Color TextColor { get; set; } = Color.Black;

    public int BorderThickness { get; set; } = 25;

    public void ShadeButton()
    {
        this.BackgroundColor = Color.LightGray;
        this.TopBorderColor = Color.LightGray;
        this.BottomBorderColor = Color.LightGray;
        this.Invalidate();
    }

    public void UpdateColorsByTeam(Team team)
    {
        this.TopBorderColor = team.GetTopColor();
        this.BottomBorderColor = team.GetBottomColor();
        this.BackgroundColor = team.GetBackColor();
        this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);
        BorderThickness = this.Height / 3;

        pevent.Graphics.Clear(this.BackgroundColor);

        using (SolidBrush topBorderBrush = new SolidBrush(this.TopBorderColor))
        {
            pevent.Graphics.FillRectangle(topBorderBrush, 0, 0, this.Width, this.BorderThickness);
        }

        using (SolidBrush bottomBorderBrush = new SolidBrush(this.BottomBorderColor))
        {
            pevent.Graphics.FillRectangle(bottomBorderBrush, 0, this.Height - this.BorderThickness, this.Width, this.BorderThickness);
        }

        using (Pen borderPen = new Pen(Color.Black, 2))
        {
            pevent.Graphics.DrawRectangle(borderPen, 1, 1, this.Width - 2, this.Height - 2);
        }

        Font boldFont = new Font(this.Font.FontFamily, 12, FontStyle.Bold);


        TextRenderer.DrawText(
            pevent.Graphics,
            this.Text,
            boldFont,
            new Rectangle(0, 0, this.Width, this.Height),
            this.TextColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
}
