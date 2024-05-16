using Leopotam.Ecs;

public class BonusBallCollisionSystem : IEcsRunSystem
{
    private readonly EcsFilter<GameObjectReference, OnCollisionEnter, BonusBall>.Exclude<Delay> ecsFilter;

    private SceneData sceneData;
    private UI uI;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);
            ref var gameObject = ref ecsFilter.Get1(filter).gameObject;

            uI.levelUpPanel.gameObject.SetActive(true);

            sceneData.player.entity.Del<Flight>();
            sceneData.player.entity.Del<CameraFollow>();
            sceneData.player.entity.Get<PositionChange>().bonusShot = true;

            entity.Get<Destroy>().gameObject = gameObject;
            entity.Get<Delay>().duration = 5.0f;

            entity.Del<OnCollisionEnter>();
        }
    }
}
