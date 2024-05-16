using Leopotam.Ecs;
using UnityEngine.SceneManagement;

public class LevelUpSystem : IEcsRunSystem
{
    private readonly EcsFilter<OnMouseDown, LevelUpButton> ecsFilter;

    private StaticData staticData;
    private JsonConfiguration config;
    private RuntimeData runtimeData;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);

            staticData.bestScore = staticData.bestScore > runtimeData.score ? staticData.bestScore : runtimeData.score;

            if (staticData.currentLevel + 1 == config.targets.Length)
            {
                SceneManager.LoadScene("StartScene");
            }
            else
            {
                staticData.currentLevel++;
                SceneManager.LoadScene("GameScene");
            }

            entity.Del<OnMouseDown>();
        }
    }
}