using Leopotam.Ecs;

public class OnButtonClickSoundSystem : IEcsRunSystem
{
    private readonly EcsFilter<OnMouseDown, AudioReference> ecsFilter;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var audio = ref ecsFilter.Get2(filter).audio;
            audio.Play();
        }
    }
}
