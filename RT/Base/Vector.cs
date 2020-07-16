using System;

namespace RT.Base
{
  public class Vector
  {
    // 三维值
    private double _a;
    private double _b;
    private double _c;

    // 向量
    public double X { get => _a; set => _a = value; }
    public double Y { get => _b; set => _b = value; }
    public double Z { get => _c; set => _c = value; }

    // RGB 颜色
    public double R { get => _a; set => _a = value; }
    public double G { get => _b; set => _b = value; }
    public double B { get => _c; set => _c = value; }

    public Vector() { }

    public Vector(double a, double b, double c)
    {
      _a = a;
      _b = b;
      _c = c;
    }

    public Vector(Vector v)
    {
      _a = v._a;
      _b = v._b;
      _c = v._c;
    }

    // 向量取模
    public double Length()
    {
      return Math.Sqrt(SquaredLength());
    }
    
    // 模的平方
    public double SquaredLength()
    {
      return X * X + Y * Y + Z * Z;
    }
    
    // 归一化
    public static Vector UnitVector(Vector v)
    {
      return v / v.Length();
    }

    // 向量点积
    public static double DotProduct(Vector v1, Vector v2)
    {
      return v1.X * v2.X +
             v1.Y * v2.Y +
             v1.Z * v2.Z;
    }

    // 向量叉乘
    public static Vector CrossProduct(Vector v1, Vector v2)
    {
      return new Vector(v1.Y * v2.Z - v1.Z * v2.Y,
                        v1.Z * v2.X - v1.X * v2.Z,
                        v1.X * v2.Y - v1.Y * v2.X);
    }

    // 向量取负
    public static Vector operator -(Vector v)
    {
      return new Vector(-v.X, -v.Y, -v.Z);
    }

    // 向量 + 向量 = 向量
    public static Vector operator +(Vector v1, Vector v2)
    {
      return new Vector(v1.X + v2.X,
                        v1.Y + v2.Y,
                        v1.Z + v2.Z);
    }

    // 向量 - 向量 = 向量
    public static Vector operator -(Vector v1, Vector v2)
    {
      return new Vector(v1.X - v2.X,
                        v1.Y - v2.Y,
                        v1.Z - v2.Z);
    }

    // 向量 * 数 = 向量
    public static Vector operator *(Vector v1, double t)
    {
      return new Vector(v1.X * t,
                        v1.Y * t,
                        v1.Z * t);
    }

    // 数 * 向量 = 向量
    public static Vector operator *(double t, Vector v)
    {
      return new Vector(t * v.X,
                        t * v.Y,
                        t * v.Z);
    }

    // 向量坐标相乘
    public static Vector operator *(Vector v1, Vector v2)
    {
      return new Vector(v1.X * v2.X,
                        v1.Y * v2.Y,
                        v1.Z * v2.Z);
    }

    // 向量坐标 / 数
    public static Vector operator /(Vector v, double t)
    {
      return new Vector(v.X / t,
                        v.Y / t,
                        v.Z / t);
    }
  }
}