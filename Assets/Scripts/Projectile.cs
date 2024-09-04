using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float power = 10f;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Target target))
        {
            VfxManager.Instance.SetEffectState(0, true);
            VfxManager.Instance.SetEffectState(1, true);
            TriggerReactionAnimation(); 
            Destroy(gameObject); 
        }
    }

    private void TriggerReactionAnimation()
    {
        AnimationManager.Instance.TriggerKnockback(); 
    }
}
