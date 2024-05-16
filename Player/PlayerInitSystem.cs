using Leopotam.Ecs;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld world;
    private StaticData staticData;
    private SceneData sceneData;
    private RuntimeData runtimeData;

    public void Init()
    {
        EcsEntity entity = world.NewEntity();

        entity.Get<InputData>();
        entity.Get<TransformReference>().transform = sceneData.player.transform;

        entity.Get<FakeBall>();
        entity.Get<GameObjectReference>().gameObject = sceneData.player.transform.GetChild(0).gameObject;

        if (staticData.currentLevel == 1)
        {
            entity.Get<PositionChange>().bonusShot = false;
        }

        sceneData.player.entity = entity;

        Time.timeScale = 1.0f;
        runtimeData.ball = staticData.ball;
        runtimeData.bonusShot = false;
    }
}