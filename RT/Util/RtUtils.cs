using System;
using System.Collections.Generic;
using RT.Base;
using RT.Hit;
using RT.Mat;

namespace RT.Util
{
  public class RtUtils
  {
    public static Random R = new Random();

    public static Vector RandomInUnitSphere()
    {
      Vector p;
      do
      {
        p = 2.0 * new Vector(R.NextDouble(), R.NextDouble(), R.NextDouble());
      } while (p.SquaredLength() >= 1.0);

      return p;
    }

    public static Vector Reflect(Vector v, Vector n)
    {
      return v - 2 * Vector.DotProduct(v, n) * n;
    }

    public static bool Refract(Vector v, Vector n, double niOverNt, ref Vector refracted)
    {
      Vector uv = Vector.UnitVector(v);
      double dt = Vector.DotProduct(uv, n);
      double discriminant = 1.0 - niOverNt * niOverNt * (1 - dt * dt);
      if (discriminant > 0)
      {
        refracted = niOverNt * (uv - n * dt) - n * Math.Sqrt(discriminant);
        return true;
      }
      return false;
    }

    public static double Schlick(double cosine, double refIdx)
    {
      double r0 = (1 - refIdx) / (1 + refIdx);
      r0 = r0 * r0;
      return r0 + (1 - r0) * Math.Pow(1 - cosine, 5);
    }

    public static Vector Color(Ray r, Hitable world, int depth)
    {
      HitRecord rec = new HitRecord();
      if (world.Hit(r, 0.001, double.MaxValue, ref rec))
      {
        Ray scattered = new Ray();
        Vector attenuation = new Vector();
        if (depth < 50 && rec.Material.Scatter(r, rec, ref attenuation, ref scattered))
        {
          Vector colorTemp = Color(scattered, world, depth + 1);
          colorTemp = colorTemp * attenuation;
          // colorTemp.R *= attenuation.X;
          // colorTemp.G *= attenuation.Y;
          // colorTemp.B *= attenuation.Z;
          return colorTemp;
        }
        return new Vector(0, 0, 0);
      }
      Vector unitDirection = Vector.UnitVector(r.Direction);
      double t = 0.5 * (unitDirection.Y + 1.0);
      return new Vector(1.0 - t + t * 0.5,
                        1.0 - t + t * 0.7,
                        1.0 - t + t * 1);
    }
    
    public static Hitable RandomScene()
    {
      List<Hitable> list = new List<Hitable>();
      list.Add(new Sphere(new Vector(0, -1000, 0), 1000, new Lambert(new Vector(0.5, 0.5, 0.5))));
      for (int a = -11; a < 11; a++)
      for (int b = -11; b < 11; b++)
      {
        double chooseMat = R.NextDouble();
        Vector center = new Vector(a + 0.9 * R.NextDouble(), 0.2, b + 0.9 * R.NextDouble());
        if ((center - new Vector(4, 0.2, 0)).Length() > 0.9)
        {
          if (chooseMat < 0.8)
            list.Add(new Sphere(center,
                                0.2,
                                new Lambert(new Vector(Math.Pow(R.NextDouble(), 2),
                                                       Math.Pow(R.NextDouble(), 2),
                                                       Math.Pow(R.NextDouble(), 2)))));
          else if (chooseMat < 0.95)
            list.Add(new Sphere(center,
                                0.2,
                                new Metal(new Vector(0.5 * (1 + R.NextDouble()),
                                                     0.5 * (1 + R.NextDouble()),
                                                     0.5 * (1 + R.NextDouble())),
                                          0.5 * R.NextDouble())));
          else
            list.Add(new Sphere(center, 0.2, new Dielectrics(1.5)));
        }
      }

      list.Add(new Sphere(new Vector(0, 1, 0), 1.0, new Dielectrics(1.5)));
      list.Add(new Sphere(new Vector(-4, 1, 0), 1.0, new Lambert(new Vector(0.4, 0.2, 0.1))));
      list.Add(new Sphere(new Vector(4, 1, 0), 1.0, new Metal(new Vector(0.7, 0.6, 0.5), 0)));
      HitableList lists = new HitableList(list);
      return lists;
    }
  }
}