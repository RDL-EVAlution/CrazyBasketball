using Leopotam.Ecs;
using UnityEngine;

public class StartButtonInitSystem : IEcsInitSystem
{
    private EcsWorld world;
    private StartButtonReference startButtonReference;

    public void Init()
    {
        EcsEntity entity = world.NewEntity();

        entity.Get<StartButton>();
        entity.Get<AudioReference>().audio = startButtonReference.startButtonEntityReference.gameObject.GetComponent<AudioSource>();

        startButtonReference.startButtonEntityReference.entity = entity;

    }
}
