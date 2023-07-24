using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Cinemachine;

public class LevelsAnimationManager : MonoBehaviour
{
    public List<GameObject> levelFolder;  // Pasta com os objetos
    //public List<GameObject> rightLevelFolder;  // Pasta com os objetos do lado direito
    public float scaleTimeBetweenPieces = 1f; // Tempo entre o crescimento de cada objeto
    public CinemachineVirtualCamera virtualCamera; // Referência ao objeto VirtualCamera da Cinemachine

    [Header("Animation")]
    public float animDuration = 0.5f; // Duração da animação de fade-in
    public Ease ease = Ease.OutQuad;    // Curva de easing para a animação

    private void Start()
    {
        StartCoroutine(ScaleObjects());
    }
    private IEnumerator ScaleObjects()
    {
        // Ordena a lista de objetos pela distância até a câmera
        levelFolder = levelFolder.OrderBy(x => Vector3.Distance(virtualCamera.transform.position, x.transform.position)).ToList();

        foreach (GameObject obj in levelFolder)
        {
            if (obj != null) // Verifica se o objeto ainda existe antes de animá-lo
            {
                Debug.Log("Aplicando animação em " + obj.name);
                obj.SetActive(true); // Ativa o objeto antes de animá-lo
                Vector3 targetScale = obj.transform.localScale; // Define a escala final como a escala atual do objeto na cena
                obj.transform.localScale = Vector3.zero; // Define a escala inicial como zero
                obj.transform.DOScale(targetScale, animDuration).SetEase(ease); // Faz o objeto crescer gradualmente até sua escala atual na cena
                yield return new WaitForSeconds(scaleTimeBetweenPieces); // Espera um tempo antes de passar para o próximo objeto

            }
        }
    }
}