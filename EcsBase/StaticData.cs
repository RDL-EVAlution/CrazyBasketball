using UnityEngine;

[CreateAssetMenu]
public class StaticData : ScriptableObject
{
    public GameObject ball;
    public GameObject ballBonus;

    public int currentLevel;
    public int bestScore;
    public float currentMusicTime;
}