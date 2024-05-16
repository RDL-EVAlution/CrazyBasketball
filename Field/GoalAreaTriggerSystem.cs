using Leopotam.Ecs;

public class GoalAreaTriggerSystem : IEcsRunSystem
{
    private readonly EcsFilter<OnTriggerEnter, GoalArea> ecsFilter;

    private StaticData staticData;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);
            ref var guest = ref ecsFilter.Get1(filter).other;

            if (guest.gameObject.name == $"{staticData.ball.name}(Clone)") entity.Get<Goal>().value = 1;
            if (guest.gameObject.name == $"{staticData.ballBonus.name}(Clone)") entity.Get<Goal>().value = 5;

            entity.Del<OnTriggerEnter>();
        }
    }
}
