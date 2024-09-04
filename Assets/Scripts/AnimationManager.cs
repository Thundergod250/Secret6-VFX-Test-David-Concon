using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance { get; private set; }

    public Animator animatorA;
    public Animator animatorB;

    public float delay = 2f;
    public float interval = 2f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        animatorA.SetTrigger("idle");
        animatorB.SetTrigger("idle");

        InvokeRepeating("TriggerFireProjectile", delay, interval);
    }

    private void TriggerFireProjectile()
    {
        animatorB.SetTrigger("fireProjectile");
    }

    public void TriggerKnockback()
    {
        animatorA.SetTrigger("attacked");
        Invoke(nameof(SetUnitABackToIdle), 1.5f); 
    }

    private void SetUnitABackToIdle()
    {
        animatorA.SetTrigger("idle");
    }
}
