using RT.Base;
using RT.Hit;

namespace RT.Mat
{
  public class Material
  {
    // 散射
    public virtual bool Scatter(Ray rayIn, HitRecord record, ref Vector attenuation, ref Ray scattered)
    {
      return false;
    }
  }
}