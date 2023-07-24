using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : MonoBehaviour
{
    public Animator animator;
    public AudioSource AudioSource;

    public void Quit()
    {
        //Aivar o som "SFX"
        AudioSource.Play();
        // Ativar a anima��o "PopAnimQuit"
        animator.SetTrigger("PopAnimQuit");

        // Aguardar a dura��o da anima��o (ajuste o tempo de acordo com a anima��o)
        float animDuration = GetAnimationDuration("PopAnimQuit");
        StartCoroutine(QuitAfterDelay(animDuration));
    }

    IEnumerator QuitAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Sair do jogo ap�s a anima��o
        Application.Quit();
    }

    float GetAnimationDuration(string animationName)
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        AnimationClip animClip = clipInfo[0].clip;
        return animClip.length;
    }
}