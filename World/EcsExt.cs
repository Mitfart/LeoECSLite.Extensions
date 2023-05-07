using System;
using System.Reflection;
using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.UnityIntegration.Extentions {
  public static class EcsExt {
    private static readonly MethodInfo _Get_Pool_Method_Info = typeof(EcsWorld).GetMethod(nameof(EcsWorld.GetPool));
    private static readonly MethodInfo _Filter_Method_Info  = typeof(EcsWorld).GetMethod(nameof(EcsWorld.Filter));
    private static readonly MethodInfo _Exc_Method_Info     = typeof(EcsWorld.Mask).GetMethod(nameof(EcsWorld.Mask.Exc));
    private static readonly MethodInfo _Inc_Method_Info     = typeof(EcsWorld.Mask).GetMethod(nameof(EcsWorld.Mask.Inc));


    public static IEcsPool GetPool(this EcsWorld world, Type type) {
      IEcsPool pool = world.GetPoolByType(type);
      if (pool != null) return pool;

      MethodInfo getPool = _Get_Pool_Method_Info.MakeGenericMethod(type);
      pool = (IEcsPool)getPool.Invoke(world, null);

      return pool;
    }


    public static EcsWorld.Mask Filter(this EcsWorld world, Type type) {
      MethodInfo getFilter = _Filter_Method_Info.MakeGenericMethod(type);
      return (EcsWorld.Mask)getFilter.Invoke(world, null);
    }


    public static EcsWorld.Mask Inc(this EcsWorld.Mask mask, Type type) {
      MethodInfo method = _Inc_Method_Info.MakeGenericMethod(type);
      return (EcsWorld.Mask) method.Invoke(mask, null);
    }


    public static EcsWorld.Mask Exc(this EcsWorld.Mask mask, Type type) {
      MethodInfo method = _Exc_Method_Info.MakeGenericMethod(type);
      return (EcsWorld.Mask)method.Invoke(mask, null);
    }
  }
}
