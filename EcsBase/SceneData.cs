using UnityEngine;

public class SceneData : MonoBehaviour
{
    public EntityReference player;
    public EntityReference goalArea;

    public ParticleSystem regularGoalParticleSystem;
    public ParticleSystem bigGoalParticleSystem;

    public GameObject hoop;

    public AudioSource musicAudioSource;
}