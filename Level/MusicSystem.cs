using Leopotam.Ecs;

public class MusicSystem : IEcsInitSystem, IEcsRunSystem
{
    private StaticData staticData;
    private SceneData sceneData;

    public void Init()
    {
        sceneData.musicAudioSource.time = staticData.currentMusicTime;
    }

    public void Run()
    {
        staticData.currentMusicTime = sceneData.musicAudioSource.time;
    }
}
