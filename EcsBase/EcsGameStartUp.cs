using Leopotam.Ecs;
using System.IO;
using UnityEngine;

public class EcsGameStartUp : MonoBehaviour
{
    [SerializeField] private StaticData staticData;
    [SerializeField] private SceneData sceneData;
    [SerializeField] private UI uI;
    private JsonConfiguration config;
    private RuntimeData runtimeData;

    private EcsWorld world;
    private EcsSystems systems;

    private string FILE_PATH = Application.streamingAssetsPath + "/saveFile.json";

    private void Start()
    {
        if (!File.Exists(FILE_PATH))
        {
            Debug.LogError("Incorrect config.json file path");
        }
        config = JsonUtility.FromJson<JsonConfiguration>(File.ReadAllText(FILE_PATH));
        runtimeData = new RuntimeData();

        world = new EcsWorld();
        systems = new EcsSystems(world);

        systems
            .Add(new PlayerInitSystem())
            .Add(new GoalAreaInitSystem())
            .Add(new UIInitSystem())

            .Add(new BonusShotSystem())

            .Add(new CameraFollowSystem())
            .Add(new PositionChangeSystem())
            .Add(new InputSystem())
            .Add(new ShotSystem())
            .Add(new FakeBallSystem())

            .Add(new BallCollisionSystem())
            .Add(new BonusBallCollisionSystem())
            .Add(new GoalAreaTriggerSystem())
            .Add(new GoalParticlePlaySystem())
            .Add(new GoalSystem())
            .Add(new ScoreSystem())

            .Add(new DelaySystem())
            .Add(new DestroySystem())

            .Add(new TimerSystem())
            .Add(new TimerEndSystem())

            .Add(new OnButtonClickSoundSystem())
            .Add(new LevelUpSystem())
            .Add(new RetryLevelSystem())

            .Add(new HoopMoveSystem())
            .Add(new MusicSystem())

            .Inject(staticData)
            .Inject(sceneData)
            .Inject(uI)
            .Inject(config)
            .Inject(runtimeData)
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