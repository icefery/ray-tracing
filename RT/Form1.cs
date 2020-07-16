using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using RT.Base;
using RT.Hit;
using RT.Util;
using RT.View;

namespace RT
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void testBtn_Click(object sender, EventArgs e)
    {
      int nx = 1600;
      int ny = 800;
      int ns = 50;
      Bitmap bitmap = new Bitmap(nx, ny);
      Hitable world = RtUtils.RandomScene();
      Camera cam = new Camera(new Vector(13, 2, 3),
                              new Vector(0, 0, 0),
                              new Vector(0, 1, 0),
                              20,
                              (double) (nx) / ny,
                              0.1,
                              10.0);
      for (int i = 0; i < nx; i++)
      {
        for (int j = 0; j < ny; j++)
        {
          Vector color = new Vector();
          for (int s = 0; s < ns; s++)
          {
            double u = (i + RtUtils.R.NextDouble()) / nx;
            double v = (j + RtUtils.R.NextDouble()) / ny;
            Ray r = cam.GetRay(u, v);
            Vector tempColor = RtUtils.Color(r, world, 0);
            color = color + tempColor;
          }

          color = color / ns;
          color = new Vector(Math.Sqrt(color.R), Math.Sqrt(color.G), Math.Sqrt(color.B));
          int ir = (int) (255.99 * color.R);
          int ig = (int) (255.99 * color.G);
          int ib = (int) (255.99 * color.B);
          bitmap.SetPixel(i, ny - j - 1, Color.FromArgb(ir, ig, ib));
        }
      }

      pictureBox1.BackgroundImage = bitmap;
      bitmap.Save("rt.bmp", ImageFormat.Bmp);
    }
  }
}