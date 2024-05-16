using Leopotam.Ecs;
using UnityEngine;

public class ShotSystem : IEcsRunSystem
{
    private readonly EcsFilter<InputData, TransformReference, Shot> ecsFilter;

    private EcsWorld world;
    private RuntimeData runtimeData;

    public void Run()
    {
        foreach(var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);

            GameObject ballInstance = GameObject.Instantiate(
                runtimeData.ball, ecsFilter.Get2(filter).transform.position, Quaternion.identity);

            var entityRef = ballInstance.GetComponent<EntityReference>();
            var ballRigidbody = ballInstance.GetComponent<Rigidbody>();

            var ballEntity = world.NewEntity();

            ballEntity.Get<GameObjectReference>().gameObject = ballInstance;
            ballEntity.Get<Ball>();

            if (runtimeData.bonusShot)
            {
                ballEntity.Get<BonusBall>();
                entity.Get<CameraFollow>().targetTransform = ballInstance.transform;
            }

            entityRef.entity = ballEntity;

            ballRigidbody.velocity = ecsFilter.Get3(filter).direction;
            ballRigidbody.AddTorque(new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)));

            entity.Get<Flight>();
            entity.Del<Shot>();
        }
    }
}
