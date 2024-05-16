using Leopotam.Ecs;

public class ScoreSystem : IEcsRunSystem
{
    private readonly EcsFilter<Goal> ecsFilter;

    private RuntimeData runtimeData;
    private UI uI;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);

            uI.currentScore.text = runtimeData.score.ToString();

            entity.Del<Goal>();
        }
    }
}