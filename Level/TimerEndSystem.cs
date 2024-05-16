using Leopotam.Ecs;

public class TimerEndSystem : IEcsRunSystem
{
    private readonly EcsFilter<TimerEnd> ecsFilter;

    private StaticData staticData;
    private SceneData sceneData;
    private UI uI;
    private JsonConfiguration config;
    private RuntimeData runtimeData;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);

            if (runtimeData.score >= config.targets[staticData.currentLevel])
            {
                sceneData.player.entity.Get<PositionChange>().bonusShot = true;
                sceneData.player.entity.Get<BonusShot>();
                sceneData.player.entity.Get<Delay>().duration = 5.0f;
                uI.bonusPanel.gameObject.SetActive(true);
            }
            else
            {
                sceneData.player.entity.Get<Delay>().duration = 60.0f;
                uI.levelRetryPanel.SetActive(true);
            }


            entity.Del<TimerEnd>();
        }
    }
}