using System.Collections.Generic;
using RT.Base;

namespace RT.Hit
{
  public class HitableList : Hitable
  {
    private List<Hitable> _list;

    public List<Hitable> List { get => _list; set => _list = value; }

    public HitableList(List<Hitable> list)
    {
      _list = list;
    }

    public override bool Hit(Ray ray, double tMin, double tMax, ref HitRecord record)
    {
      HitRecord tempRecord = new HitRecord();
      bool hitAnything = false;
      double closestSoFar = tMax;
      foreach (Hitable hitable in List)
        if (hitable.Hit(ray, tMin, closestSoFar, ref tempRecord))
        {
          hitAnything = true;
          closestSoFar = tempRecord.T;
          record = tempRecord;
        }
      return hitAnything;
    }
  }
}