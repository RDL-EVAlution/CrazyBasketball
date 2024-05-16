using Leopotam.Ecs;
using UnityEngine;

public class UIInitSystem : IEcsInitSystem
{
    private EcsWorld world;
    private StaticData staticData;
    private UI uI;
    private JsonConfiguration config;

    public void Init()
    {
        EcsEntity entity = world.NewEntity();

        entity.Get<Timer>().duration = config.time;

        uI.currentScore.text = "0";
        uI.targetScore.text = $"TARGET:{config.targets[staticData.currentLevel]}";

        uI.bestScore.text = $"BEST:{staticData.bestScore}";
        uI.currentLevel.text = $"LEVEL:{staticData.currentLevel}";

        EcsEntity retryButtonEntity = world.NewEntity();
        retryButtonEntity.Get<RetryLevelButton>();
        retryButtonEntity.Get<AudioReference>().audio = uI.levelRetryPanel.GetComponentInChildren<AudioSource>();
        uI.levelRetryPanel.GetComponentInChildren<EntityReference>().entity = retryButtonEntity;

        EcsEntity upButtonEntity = world.NewEntity();
        upButtonEntity.Get<LevelUpButton>();
        upButtonEntity.Get<AudioReference>().audio = uI.levelUpPanel.GetComponentInChildren<AudioSource>();
        uI.levelUpPanel.GetComponentInChildren<EntityReference>().entity = upButtonEntity;
    }
}