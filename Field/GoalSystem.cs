using Leopotam.Ecs;

public class GoalSystem : IEcsRunSystem
{
    private readonly EcsFilter<Goal> ecsFilter;

    private StaticData staticData;
    private SceneData sceneData;
    private RuntimeData runtimeData;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            var value = ecsFilter.Get1(filter).value;

            runtimeData.score += value;

            if (staticData.currentLevel != 0)
            {
                sceneData.player.entity.Get<PositionChange>().bonusShot = false;
            }
        }
    }
}