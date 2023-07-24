using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    // Refer�ncia ao AudioSource que reproduz a m�sica de ambiente
    public AudioSource ambienteAudioSource;

    public void Pause()
    {
        // Pausa o jogo
        Time.timeScale = 0;

        // Pausa a reprodu��o da m�sica de ambiente
        ambienteAudioSource.Pause();
    }

    public void UnPause()
    {
        // Despausa o jogo
        Time.timeScale = 1;

        // Retoma a reprodu��o da m�sica de ambiente
        ambienteAudioSource.UnPause();
    }
}
