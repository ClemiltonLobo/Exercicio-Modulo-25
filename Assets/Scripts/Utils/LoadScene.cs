using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator animator;
    public AudioSource AudioSource;
    public string triggerName;

    public void Load(int i)
    {
        //Aivar o som "SFX"
        AudioSource.Play();

        // Ativar a anima��o "PopAnimPlay" antes de carregar a nova cena
        animator.SetTrigger(triggerName);

        // Aguardar a dura��o da anima��o (ajuste o tempo de acordo com a anima��o)
        float animDuration = GetAnimationDuration(triggerName);
        StartCoroutine(LoadSceneAfterDelay(i, animDuration));
    }

    public void Load(string s)
    {
        //Aivar o som "SFX"
        AudioSource.Play();

        // Ativar a anima��o "PopAnimPlay" antes de carregar a nova cena
        animator.SetTrigger(triggerName);

        // Aguardar a dura��o da anima��o (ajuste o tempo de acordo com a anima��o)
        float animDuration = GetAnimationDuration(triggerName);
        StartCoroutine(LoadSceneAfterDelay(s, animDuration));
    }

    IEnumerator LoadSceneAfterDelay(int i, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Carregar a nova cena ap�s a anima��o
        SceneManager.LoadScene(i);
    }

    IEnumerator LoadSceneAfterDelay(string s, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Carregar a nova cena ap�s a anima��o
        SceneManager.LoadScene(s);
    }

    float GetAnimationDuration(string animationName)
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);

        if (clipInfo.Length > 0)
        {
            AnimationClip animClip = clipInfo[0].clip;
            return animClip.length;
        }
        else
        {
            Debug.LogWarning("AnimatorClipInfo array is empty.");
            return 0f;
        }
    }
}
