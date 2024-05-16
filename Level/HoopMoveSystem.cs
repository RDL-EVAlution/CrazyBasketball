using Leopotam.Ecs;
using UnityEngine;

public class HoopMoveSystem : IEcsRunSystem
{
    private StaticData staticData;
    private SceneData sceneData;

    public void Run()
    {
        if (staticData.currentLevel != 2) return;

        sceneData.hoop.transform.position += new Vector3(Mathf.Cos(Time.time) / 2000, 0.0f, 0.0f);
    }
}