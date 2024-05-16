using Leopotam.Ecs;
using UnityEngine;

public class CameraFollowSystem : IEcsRunSystem
{
    private readonly EcsFilter<TransformReference, CameraFollow, Flight> ecsFilter;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var transform = ref ecsFilter.Get1(filter).transform;
            ref var target = ref ecsFilter.Get2(filter).targetTransform;

            Vector3 targetPosition = target.position + (transform.position - target.position).normalized * 3.0f;
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.25f);
            transform.LookAt(target);
        }
    }
}
