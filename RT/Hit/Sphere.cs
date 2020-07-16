using System;
using RT.Base;
using RT.Mat;

namespace RT.Hit
{
  public class Sphere : Hit.Hitable
  {
    // 球心
    private Vector _center;
    // 半径
    private double _radius;
    // 材质
    private Mat.Material _material;

    public Vector       Center   { get => _center;   set => _center = value; }
    public double       Radius   { get => _radius;   set => _radius = value; }
    public Mat.Material Material { get => _material; set => _material = value; }

    public Sphere(Vector center, double radius, Mat.Material material)
    {
      _radius = radius;
      _center = center;
      _material = material;
    }

    /*
     * 球面方程：
     *           X*X           + Y*Y           + Z*Z           = R*R
     *           (X-Xc)*(X-Xc) + (Y-Yc)*(Y-Yc) + (Z-Zc)*(Z-Zc) = R*R
     * 向量表示：  
     *           Dot(P(t)  - C, P(t)  - C) = R*R
     *           Dot(O+t*D - C, O+t*D - C) = R*R
     */
    public override bool Hit(Ray ray, double tMin, double tMax, ref HitRecord record)
    {
      Vector oc = ray.Origin - Center;
      double a = Vector.DotProduct(ray.Direction, ray.Direction);
      double b = Vector.DotProduct(oc, ray.Direction);
      double c = Vector.DotProduct(oc, oc) - Radius * Radius;
      double discriminant = b * b - a * c;
      if (discriminant > 0)
      {
        double temp = (-b - Math.Sqrt(b * b - a * c)) / a;
        if (temp < tMax && temp > tMin)
        {
          record.T = temp;
          record.P = ray.PointAt(record.T);
          record.Normal = (record.P - Center) / Radius;
          record.Material = Material;
          return true;
        }

        temp = (-b + Math.Sqrt(b * b - a * c)) / a;
        if (temp < tMax && temp > tMin)
        {
          record.T = temp;
          record.P = ray.PointAt(record.T);
          record.Normal = (record.P - Center) / Radius;
          record.Material = Material;
          return true;
        }
      }

      return false;
    }
  }
}