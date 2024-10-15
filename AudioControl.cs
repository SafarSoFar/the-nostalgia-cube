using System.Collections;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioSource stepSource;
    [SerializeField] AudioClip[] stepClips;
    [SerializeField] float stepCooldown = 1.0f;
    public bool canPlayStep = true;


    public void PlayStepSound(){
        if(canPlayStep){
            StartCoroutine(StepSoundCoroutine());
        }
    }

    IEnumerator StepSoundCoroutine(){
        canPlayStep = false;
        AudioClip newClip = null;
        // To prevent last sound repetition
        do{ 
            newClip = stepClips[Random.Range(0, stepClips.Length)];
            yield return null;

        }while(newClip == stepSource.clip);

        stepSource.clip = newClip;
        stepSource.Play();
        float time = 0.0f;
        while(time < stepCooldown){
            time += Time.deltaTime;
            yield return null;
        }
        canPlayStep = true;
        yield return null;

    }


    
}
