namespace RT.Base
{
  public class Ray
  {
    // 起点
    private Vector _origin;
    // 方向
    private Vector _direction;

    public Vector Origin    { get => _origin;    set => _origin = value; }
    public Vector Direction { get => _direction; set => _direction = value; }

    public Ray() { }

    public Ray(Vector origin, Vector direction)
    {
      _origin = new Vector(origin);
      _direction = new Vector(direction);
    }

    // 光线上指定参数位置的射线向量
    // P(t) = O + t * D
    public Vector PointAt(double t)
    {
      return Origin + new Vector(t * Direction.X, t * Direction.Y, t * Direction.Z);
    }
  }
}