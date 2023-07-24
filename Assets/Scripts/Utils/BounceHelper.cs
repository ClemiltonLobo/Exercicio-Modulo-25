using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
    public float ScaleDuration = .2f;
    public float scaleBounce = .2f;
    public Ease ease = Ease.OutBack;


    private Vector3 originalScale; // Escala original do objeto
    private PlayerController playerController; // Referência ao script PlayerController

    private void Awake()
    {
        playerController = GetComponent<PlayerController>(); // Obtenha a referência ao script PlayerController
    }

    /*private void Start()
    {
        originalScale = transform.localScale; // Salvar a escala original
    }*/


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Bounce();
        }
    }
    public void Bounce()
    {
        transform.DOScale(scaleBounce, ScaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            transform.localScale = playerController.DefaultScale;
        });
    }

    private void ResetScale()
    {
        transform.DOScale(originalScale, ScaleDuration) // Restaurar a escala original
            .SetEase(ease);
    }
}