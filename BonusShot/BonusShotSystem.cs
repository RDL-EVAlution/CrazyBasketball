using Leopotam.Ecs;
using UnityEngine;

public class BonusShotSystem : IEcsRunSystem
{
    private readonly EcsFilter<BonusShot>.Exclude<Delay> ecsFilter;

    private StaticData staticData;
    private RuntimeData runtimeData;
    private UI uI;

    public void Run()
    {
        foreach (var filter in ecsFilter)
        {
            ref var entity = ref ecsFilter.GetEntity(filter);
            ref var inputData = ref ecsFilter.Get1(filter);

            Time.timeScale = 0.75f;

            runtimeData.ball = staticData.ballBonus;
            runtimeData.bonusShot = true;

            uI.bonusPanel.gameObject.SetActive(false);
        }
    }
}
