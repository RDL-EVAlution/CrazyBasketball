using Leopotam.Ecs;
using UnityEngine;

public class DestroySystem : IEcsRunSystem
{
    private readonly EcsFilter<Destroy>.Exclude<Delay> ecsFilter;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);
            ref var destroy = ref ecsFilter.Get1(filter);

            if (destroy.gameObject != null)
            {
                GameObject.Destroy(destroy.gameObject);
            }

            entity.Del<Destroy>();
            entity.Destroy();
        }
    }
}