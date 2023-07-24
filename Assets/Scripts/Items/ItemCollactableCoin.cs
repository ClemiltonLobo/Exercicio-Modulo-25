using DG.Tweening;
using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableCoin : ItemCollactableBase
{
    public Collider Collider;
    public bool collect = false;
    public float lerp = 3f;
    public float minDistance = 1f;

    private bool canBounce = true; // Flag para controlar o intervalo entre os bounces
    private BounceHelper bounceHelper; // Referência ao BounceHelper

    private void Start()
    {
        bounceHelper = GetComponentInChildren<BounceHelper>(); // Obter a referência ao BounceHelper usando GetComponentInChildren
    }

    protected override void OnCollect()
    {
        base.OnCollect();        
        Collider.enabled = false;
        collect = true;
        
        // Verificar se o segundo objeto está próximo do primeiro
        if (CheckIfSecondObjectIsClose())
        {
            Invoke("BounceWithDelay", 0.5f);
        }
        else
        {
            Bounce();
        }
    }

    private bool CheckIfSecondObjectIsClose()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("CandyCollector") && collider.gameObject != gameObject)
            {
                float distance = Vector3.Distance(collider.transform.position, transform.position);
                if (distance < minDistance)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void BounceWithDelay()
    {
        if (canBounce && gameObject.activeSelf) // Verificar se é permitido fazer o bounce e se o objeto está ativo
        {
            StartCoroutine(DelayedBounce());
            canBounce = false;
            StartCoroutine(ResetBounceFlag());
        }
    }

    private IEnumerator DelayedBounce()
    {
        yield return new WaitForEndOfFrame(); // Aguardar o próximo quadro para iniciar a coroutine
        bounceHelper.Bounce(); // Chamar a função Bounce() do BounceHelper
    }
   

    private IEnumerator ResetBounceFlag()
    {
        yield return new WaitForSeconds(0.5f); // Tempo de espera antes de permitir outro salto
        canBounce = true;
    }

    private void Bounce()
    {
        var bounceHelper = PlayerController.Instance.GetComponent<BounceHelper>();
        if (bounceHelper != null)
        {
            bounceHelper.Bounce();
        }
    }

    private void Update()
    {
        if(collect)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerp * Time.deltaTime);
            //Esconde e destroy os Candys, apos coletado
            /*if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < minDistance)
            {
                HideItens();
                Destroy(gameObject);
            }*/
        }
    }
}
