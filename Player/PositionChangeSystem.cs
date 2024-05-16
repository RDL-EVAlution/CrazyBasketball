using Leopotam.Ecs;
using UnityEngine;

public class PositionChangeSystem : IEcsRunSystem
{
    private readonly EcsFilter<TransformReference, PositionChange> ecsFilter;

    private StaticData staticData;
    private SceneData sceneData;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);
            ref var transform = ref ecsFilter.Get1(filter).transform;
            
            if (ecsFilter.Get2(filter).bonusShot)
            {
                transform.position = new Vector3(0.0f, 4.25f, 0.5f);
            }
            else
            {
                if (staticData.currentLevel == 1)
                {
                    if (transform.position.x == 0 || transform.position.x == -1.0f) transform.position = new Vector3(1.0f, 3.0f, 2.5f);
                    else transform.position = new Vector3(-1.0f, 3.0f, 2.5f);
                }
                else transform.position = new Vector3(Random.Range(-1.0f, 1.0f), 3.0f, 2.5f);
            }

            transform.LookAt(sceneData.goalArea.transform.position);

            entity.Del<PositionChange>();
        }
    }
}