using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float power = 10f;
    [SerializeField] private ParticleSystem projectileHead;
    [SerializeField] private ParticleSystem magicCircles;
    [SerializeField] private TrailRenderer trailRenderer;

    private void OnEnable()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;  
        GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Target>())
        {
            VfxManager.Instance.SetEffectState(0, true);
            VfxManager.Instance.SetEffectState(1, true);
            VfxManager.Instance.PlayPersistentVfx(); 
            TriggerReactionAnimation();

            projectileHead.Stop();
            projectileHead.gameObject.SetActive(false);
            magicCircles.Stop();
            trailRenderer.emitting = false;
        }
    }

    public void ReEnableVfx()
    {
        projectileHead.gameObject.SetActive(true);
        projectileHead.Play();
        magicCircles.Play();
        trailRenderer.emitting = true;
    }

    private void TriggerReactionAnimation()
    {
        AnimationManager.Instance.TriggerKnockback();
    }
}
