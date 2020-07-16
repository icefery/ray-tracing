using System;
using RT.Base;
using RT.Util;

namespace RT.View
{
  public class Camera
  {
    private Vector _lowerLeftCorner;
    private Vector _horizontal;
    private Vector _vertical;
    private Vector _origin;

    private Vector _u;
    private Vector _v;
    private double _lenRadius;

    public Vector LowerLeftCorner { get => _lowerLeftCorner; set => _lowerLeftCorner = value; }
    public Vector Horizontal      { get => _horizontal;      set => _horizontal = value; }
    public Vector Vertical        { get => _vertical;        set => _vertical = value; }
    public Vector Origin          { get => _origin;          set => _origin = value; }

    public Camera(Vector lookFrom,
                  Vector lookAt,
                  Vector vUp,
                  double vFov,
                  double aspect,
                  double aperture,
                  double focusDist)
    {
      _lenRadius = aperture / 2;
      double theta = vFov * Math.PI / 180;
      double halfHeight = Math.Tan(theta / 2);
      double halfWidth = aspect * halfHeight;
      Origin = lookFrom;
      Vector w = Vector.UnitVector(lookFrom - lookAt);
      _u = Vector.UnitVector(Vector.CrossProduct(vUp, w));
      _v = Vector.CrossProduct(w, _u);
      Vector lowerLeftCornerTemp = Origin -
                                   halfWidth * focusDist * _u -
                                   halfHeight * focusDist * _v -
                                   w * focusDist;
      _lowerLeftCorner = new Vector(lowerLeftCornerTemp);
      _horizontal = 2 * halfWidth * _u * focusDist;
      _vertical = 2 * halfHeight * _v * focusDist;
    }

    public Ray GetRay(double s, double t)
    {
      Vector rd = _lenRadius * RtUtils.RandomInUnitSphere();
      Vector offset = _u * rd.X + _v * rd.Y;
      return new Ray(Origin + offset,
                     LowerLeftCorner + s * Horizontal + t * Vertical - Origin - offset);
    }
  }
}