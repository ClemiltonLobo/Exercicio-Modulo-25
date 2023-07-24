using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUpFly : PowerUpBase
{
    [Header("PowerUp Fly")]
    public float amountFly = 2;
    public float animationDuration = .1f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();
        PlayerController.Instance.ChangeFly(amountFly, duration, animationDuration, ease);
        PlayerController.Instance.SetPowerUpText("PowerUp Fly");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();
        PlayerController.Instance.ResetFly();
        PlayerController.Instance.SetPowerUpText("");
    }
}