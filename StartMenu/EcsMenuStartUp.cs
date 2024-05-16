using Leopotam.Ecs;
using UnityEngine;

public class EcsMenuStartUp : MonoBehaviour
{
    [SerializeField] private StaticData staticData;
    [SerializeField] private StartButtonReference startButtonReference;

    private EcsWorld world;
    private EcsSystems systems;

    private void Start()
    {
        world = new EcsWorld();
        systems = new EcsSystems(world);

        systems
            .Add(new StartButtonInitSystem())

            .Add(new OnButtonClickSoundSystem())
            .Add(new StartSystem())

            .Inject(staticData)
            .Inject(startButtonReference)
            .Init();
    }

    private void Update()
    {
        systems.Run();
    }

    private void OnDestroy()
    {
        systems.Destroy();
        systems = null;
        world.Destroy();
        world = null;
    }
}