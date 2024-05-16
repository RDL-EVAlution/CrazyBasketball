using Leopotam.Ecs;

public class GoalAreaInitSystem : IEcsInitSystem
{
    private EcsWorld world;
    private SceneData sceneData;

    public void Init()
    {
        EcsEntity entity = world.NewEntity();

        entity.Get<GoalArea>();

        sceneData.goalArea.entity = entity;
    }
}
