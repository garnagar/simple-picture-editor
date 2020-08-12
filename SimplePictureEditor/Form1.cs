using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimplePictureEditor
{
    public partial class Form1 : Form
    {
        Bitmap Image;
        Color[,] Colors;


        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFile()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Images (*.bmp, *.jpg)|*.bmp;*.jpg";
            openFile.ShowDialog();
            if (openFile.FileName != "")
            {
                using (Bitmap tempImage = (Bitmap)Bitmap.FromFile(openFile.FileName))
                {
                    if (tempImage.Width <= 500 && tempImage.Height <= 500)
                    {
                        if (Image != null)
                        {
                            Image.Dispose();
                            Image = null;
                        }
                        Image = (Bitmap)tempImage.Clone();
                        Colors = new Color[Image.Width, Image.Height];
                        for (int x = 0; x < Image.Width; x++)
                        {
                            for (int y = 0; y < Image.Height; y++)
                            {
                                Colors[x, y] = Image.GetPixel(x, y);
                            }
                        }
                        this.effectList.Enabled = true;
                        this.Invalidate();
                    }
                    else { MessageBox.Show("Image is too big!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (Image != null)
            {
                e.Graphics.DrawImage(Image, 15, 22);
            }
        }

        private void InvertColors()
        {
            for (int x = 0; x < Image.Width; x++)
            {
                for (int y = 0; y < Image.Height; y++)
                {
                    Color tempColor = Colors[x, y];
                    int newRed = 255 - tempColor.R;
                    int newGreen = 255 - tempColor.G;
                    int newBlue = 255 - tempColor.B;
                    Color newColor = Color.FromArgb(newRed, newGreen, newBlue);
                    Image.SetPixel(x, y, newColor);
                    Colors[x, y] = newColor;
                }
            }
            this.Invalidate();
        }

        private void Lighten(int rate)
        {
            for (int x = 0; x < Image.Width; x++)
            {
                for (int y = 0; y < Image.Height; y++)
                {
                    Color tempColor = Colors[x, y];
                    int newRed = Math.Min(255, tempColor.R + rate);
                    int newGreen = Math.Min(255, tempColor.G + rate);
                    int newBlue = Math.Min(255, tempColor.B + rate);
                    Color newColor = Color.FromArgb(newRed, newGreen, newBlue);
                    Image.SetPixel(x, y, newColor);
                    Colors[x, y] = newColor;
                }
            }
            this.Invalidate();
        }

        private void Darken(int rate)
        {
            for (int x = 0; x < Image.Width; x++)
            {
                for (int y = 0; y < Image.Height; y++)
                {
                    Color tempColor = Colors[x, y];
                    int newRed = Math.Max(0, tempColor.R - rate);
                    int newGreen = Math.Max(0, tempColor.G - rate);
                    int newBlue = Math.Max(0, tempColor.B - rate);
                    Color newColor = Color.FromArgb(newRed, newGreen, newBlue);
                    Image.SetPixel(x, y, newColor);
                    Colors[x, y] = newColor;
                }
            }
            this.Invalidate();
        }

        private void Blur()
        {
            for (int x = 0; x < Image.Width; x++)
            {
                for (int y = 0; y < Image.Height; y++)
                {
                    Color color;

                    if (x > 0) { color = Colors[x - 1, y]; }
                    else { color = Colors[x, y]; }
                    int previousRed = color.R;
                    int previousGreen = color.G;
                    int previousBlue = color.B;

                    if (x < Image.Width - 1) { color = Colors[x + 1, y]; }
                    else { color = Colors[x, y]; }
                    int nextRed = color.R;
                    int nextGreen = color.G;
                    int nextBlue = color.B;

                    int newRed = (previousRed + nextRed) / 2;
                    int newGreen = (previousGreen + nextGreen) / 2;
                    int newBlue = (previousBlue + nextBlue) / 2;
                    Color newColor = Color.FromArgb(newRed, newGreen, newBlue);
                    Image.SetPixel(x, y, newColor);
                    Colors[x, y] = newColor;
                }
            }
            this.Invalidate();
        }

        private void FlipHorizontaly()
        {
            Color[,] tempColors = new Color[Image.Width, Image.Height];
            for (int x = 0; x < Image.Width; x++)
            {
                for (int y = 0; y < Image.Height; y++)
                {
                    Image.SetPixel(x, y, Colors[(Image.Width - 1) - x, y]);
                    tempColors[x, y] = Colors[(Image.Width - 1) - x, y];
                }
            }
            Colors = tempColors;
            this.Invalidate(); 
        }

        private void FlipVerticaly()
        {
            Color[,] tempColors = new Color[Image.Width, Image.Height];
            for (int x = 0; x < Image.Width; x++)
            {
                for (int y = 0; y < Image.Height; y++)
                {
                    Image.SetPixel(x, y, Colors[x, (Image.Height - 1) - y]);
                    tempColors[x, y] = Colors[x, (Image.Height - 1) - y];
                }
            }
            Colors = tempColors;
            this.Invalidate();
        }

        private void effectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btn_Apply.Enabled = true;
            switch (effectList.SelectedIndex)
            {
                case 0:
                    choosenEffect = this.InvertColors;
                    this.rateTrackBar.Visible = false;
                    break;
                case 1:
                    choosenEffect = this.Blur;
                    this.rateTrackBar.Visible = false;
                    break;
                case 2:
                    choosenEffect = () => this.Lighten(rateTrackBar.Value);
                    this.rateTrackBar.Visible = true;
                    break;
                case 3:
                    choosenEffect = () => this.Darken(rateTrackBar.Value);
                    this.rateTrackBar.Visible = true;
                    break;
                case 4:
                    choosenEffect = this.FlipHorizontaly;
                    this.rateTrackBar.Visible = true;
                    break;
                case 5:
                    choosenEffect = this.FlipVerticaly;
                    this.rateTrackBar.Visible = true;
                    break;
            }
        }

        delegate void DelegateChoosenEffect();
        DelegateChoosenEffect choosenEffect;

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (this.choosenEffect != null)
            {
                this.choosenEffect();
                this.btn_Save.Enabled = true;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Image != null)
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.ShowDialog();
                    string path = saveFile.FileName;
                    if (path != "")
                    {
                        Image.Save(path);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error occured while saveing file!", "Error");
            }
        }


    }
}
