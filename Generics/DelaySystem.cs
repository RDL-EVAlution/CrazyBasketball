using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelaySystem : IEcsRunSystem
{
    private readonly EcsFilter<Delay> ecsFilter;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);
            ref var duration = ref ecsFilter.Get1(filter).duration;

            duration -= Time.deltaTime;

            if (duration <= 0) entity.Del<Delay>();
        }
    }
}
