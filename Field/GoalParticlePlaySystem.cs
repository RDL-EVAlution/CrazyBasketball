using Leopotam.Ecs;

public class GoalParticlePlaySystem : IEcsRunSystem
{
    private readonly EcsFilter<Goal> ecsFilter;
    
    private SceneData sceneData;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            var value = ecsFilter.Get1(filter).value;

            if (value == 1)
            {
                sceneData.regularGoalParticleSystem.Play();
            }
            else
            {
                sceneData.bigGoalParticleSystem.Play();
            }
        }
    }
}