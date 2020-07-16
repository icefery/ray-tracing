using RT.Base;
using RT.Hit;
using RT.Util;

namespace RT.Mat
{
  public class Dielectrics : Mat.Material
  {
    // 相对折射率
    private double _refIdx;

    public double RefIdx { get => _refIdx; set => _refIdx = value; }

    public Dielectrics(double refIdx)
    {
      _refIdx = refIdx;
    }

    public override bool Scatter(Ray rayIn, HitRecord record, ref Vector attenuation, ref Ray scattered)
    {
      attenuation = new Vector(1, 1, 1); //衰减率
      Vector reflected = RtUtils.Reflect(rayIn.Direction, record.Normal);
      Vector refracted = new Vector();
      Vector outwardNormal;
      double niOverNt;
      double reflectProb;
      double cosine;
      if (Vector.DotProduct(rayIn.Direction, record.Normal) > 0)
      {
        outwardNormal = record.Normal * -1;
        niOverNt = RefIdx;
        cosine = RefIdx * Vector.DotProduct(rayIn.Direction, record.Normal) / rayIn.Direction.Length();
      }
      else
      {
        outwardNormal = record.Normal;
        niOverNt = 1.0 / RefIdx;
        cosine = -Vector.DotProduct(rayIn.Direction, record.Normal) / rayIn.Direction.Length();
      }

      if (RtUtils.Refract(rayIn.Direction, outwardNormal, niOverNt, ref refracted))
      {
        reflectProb = RtUtils.Schlick(cosine, RefIdx);
      }
      else
      {
        scattered = new Ray(new Vector(record.P), reflected);
        reflectProb = 1.0;
      }

      scattered = RtUtils.R.NextDouble() < reflectProb ?
                    new Ray(new Vector(record.P), reflected) :
                    new Ray(new Vector(record.P), refracted);

      return true;
    }
  }
}