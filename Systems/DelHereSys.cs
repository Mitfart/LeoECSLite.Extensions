using Leopotam.EcsLite;

namespace Mitfart.LeoECSLite.Extensions.LeoECSLite.Extensions.Systems{
	public sealed class DelHereSys<T> : IEcsRunSystem, IEcsInitSystem where T : struct {
		private EcsWorld   _world;
		private EcsFilter  _filter;
		private EcsPool<T> _tPool;

		public void Init(IEcsSystems systems){
			_world  = systems.GetWorld();
			_filter = _world.Filter<T>().End();
			_tPool  = _world.GetPool<T>();
		}

		public void Run(IEcsSystems systems){
			foreach (int e in _filter)
				_tPool.Del(e);
		}
	}
}

			
