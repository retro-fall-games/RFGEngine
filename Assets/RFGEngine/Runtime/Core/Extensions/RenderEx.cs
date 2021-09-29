using UnityEngine;

namespace RFG.Core
{
  public static class RendererEx
  {
    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
      Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
      return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
  }
}