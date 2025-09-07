using UnityEngine;

public class SMScript : MonoBehaviour
{
    /* Manages sounds for all non-parallax sounds
        - parallax sounds are manages in the ParallaxSMScript
     * 
     */


    [Tooltip("The audio clip needs to be a .wav file")]
    // player sounds
    [SerializeField] private AudioClip player_jump_clip;

    //enemy sounds
    [SerializeField] private AudioClip enemy_defeated_clip;
    public AudioClip enemy_ground_idle_clip; // walking
    public AudioClip enemy_air_idle_clip; // flying

    // item sounds
    [SerializeField] private AudioClip collectable_clip;
    [SerializeField] private AudioClip powerup_clip;

    // background
    [SerializeField] private AudioClip background_clip;


    // looped sounds
    public void BackgroundMusic()
    {
        if (background_clip == null)
            return;

        AudioSource sound = gameObject.AddComponent<AudioSource>();
        sound.clip = player_jump_clip;
        sound.loop = true;
        sound.Play();
    }


    // single instance sounds
    public void JumpSound()
    {
        if (player_jump_clip == null)
            return;

        AudioSource sound = gameObject.AddComponent<AudioSource>();
        sound.clip = player_jump_clip;    
        sound.Play();   
    }

    public void DefeatSound()
    {
        if (enemy_defeated_clip == null)
            return;

        AudioSource sound = gameObject.AddComponent<AudioSource>();
        sound.clip = enemy_defeated_clip;
        sound.Play();
    }

    public void CollectableSound()
    {
        if (collectable_clip == null)
            return;

        AudioSource sound = gameObject.AddComponent<AudioSource>();
        sound.clip = collectable_clip;
        sound.Play();
    }

    public void PowerupSound()
    {
        if (powerup_clip == null)
            return;

        AudioSource sound = gameObject.AddComponent<AudioSource>();
        sound.clip = powerup_clip;
        sound.Play();
    }
}