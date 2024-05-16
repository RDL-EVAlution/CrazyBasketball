using Leopotam.Ecs;
using UnityEngine;

public class FakeBallSystem : IEcsRunSystem
{
    private readonly EcsFilter<GameObjectReference, FakeBall>.Exclude<Flight> ecsFilter;
    private readonly EcsFilter<GameObjectReference, FakeBall, Flight> flightFilter;

    private Vector3 rotationDirection = Vector3.zero;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var gameObject = ref ecsFilter.Get1(filter).gameObject;

            gameObject.SetActive(true);

            if(rotationDirection == Vector3.zero)
            {
                rotationDirection = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
            }

            gameObject.transform.position = new Vector3(0.0f, Mathf.Cos(Time.time) / 10000, 0.0f) + gameObject.transform.position;

            gameObject.transform.Rotate(rotationDirection);
        }

        foreach (var filter in flightFilter)
        {
            ref var gameObject = ref flightFilter.Get1(filter).gameObject;

            gameObject.SetActive(false);

            rotationDirection = new Vector3(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
        }
    }
}
