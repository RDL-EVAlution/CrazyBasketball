using Leopotam.Ecs;
using UnityEngine;

public class InputSystem : IEcsRunSystem
{
    private readonly EcsFilter<InputData, TransformReference>.Exclude<Flight, Delay> ecsFilter;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);
            ref var inputData = ref ecsFilter.Get1(filter);
            var position = ecsFilter.Get2(filter).transform.position;

            if (Input.GetMouseButtonDown(0)) //
            {
                inputData.swipeDuration += Time.deltaTime;
                inputData.swipeStartPosition = Input.mousePosition;
            }

            if(Input.GetMouseButtonUp(0) || inputData.swipeDuration >= 0.50f)
            {
                float power = Mathf.Clamp(inputData.swipeDuration, 0.25f, 0.50f);
                power *= 15;

                Vector3 direction = Input.mousePosition - inputData.swipeStartPosition;

                float x = Mathf.Clamp(direction.x, -500.0f, 500.0f) / 100;
                float y = Mathf.Clamp(direction.y, 200.0f, 1000.0f) / 100;

                x += -position.x * 1.0f;

                direction = new Vector3(x, y, power);

                inputData.swipeDuration = 0;
                inputData.swipeStartPosition = Vector3.zero;

                entity.Get<Shot>().direction = direction;
            }
            else if (Input.GetMouseButton(0) && inputData.swipeDuration != 0.0f)
            {
                inputData.swipeDuration += Time.deltaTime;
            }
        }
    }
}
