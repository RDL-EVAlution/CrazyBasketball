using Leopotam.Ecs;

public class BallCollisionSystem : IEcsRunSystem
{
    private readonly EcsFilter<GameObjectReference, OnCollisionEnter, Ball>.Exclude<Delay, BonusBall> ecsFilter;

    private SceneData sceneData;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);
            ref var gameObject = ref ecsFilter.Get1(filter).gameObject;

            sceneData.player.entity.Del<Flight>();

            entity.Get<Destroy>().gameObject = gameObject;
            entity.Get<Delay>().duration = 5.0f;

            entity.Del<OnCollisionEnter>();
        }
    }
}
