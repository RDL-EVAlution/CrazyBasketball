using Leopotam.Ecs;
using UnityEngine;

public class TimerSystem : IEcsRunSystem
{
    private readonly EcsFilter<Timer> ecsFilter;

    private UI uI;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var duration = ref ecsFilter.Get1(filter).duration;

            duration -= Time.deltaTime;

            if (duration <= 0)
            {
                ref var entity = ref ecsFilter.GetEntity(filter);

                entity.Get<TimerEnd>();
                entity.Del<Timer>();
            }

            uI.timer.text = (duration - (duration % 1)).ToString();
        }
    }
}
