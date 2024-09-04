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

        StartCoroutine(TriggerFireProjectileRepeatedly());
    }

    private IEnumerator TriggerFireProjectileRepeatedly()
    {
        yield return new WaitForSeconds(delay);
        while (true)
        {
            animatorB.SetTrigger("fireProjectile");
            yield return new WaitForSeconds(interval);
        }
    }

    public void TriggerKnockback()
    {
        animatorA.SetTrigger("attacked");
        StartCoroutine(SetUnitABackToIdle());
    }

    private IEnumerator SetUnitABackToIdle()
    {
        yield return new WaitForSeconds(1.5f);
        animatorA.SetTrigger("idle");
    }
}
