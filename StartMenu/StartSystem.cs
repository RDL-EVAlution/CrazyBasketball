using Leopotam.Ecs;
using UnityEngine.SceneManagement;

public class StartSystem : IEcsRunSystem
{
    private readonly EcsFilter<OnMouseDown, StartButton> ecsFilter;

    private StaticData staticData;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);

            staticData.currentLevel = 0;
            staticData.currentMusicTime = 0;
            SceneManager.LoadScene("GameScene");

            entity.Del<OnMouseDown>();
        }
    }
}
