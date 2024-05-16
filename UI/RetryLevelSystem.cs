using Leopotam.Ecs;
using UnityEngine.SceneManagement;

public class RetryLevelSystem : IEcsRunSystem
{
    private readonly EcsFilter<OnMouseDown, RetryLevelButton> ecsFilter;

    private EcsWorld world;
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

            staticData.bestScore = staticData.bestScore > runtimeData.score ? staticData.bestScore : runtimeData.score;
            SceneManager.LoadScene("GameScene");

            entity.Del<OnMouseDown>();
        }
    }
}
