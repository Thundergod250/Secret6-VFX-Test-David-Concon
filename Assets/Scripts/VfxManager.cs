using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxManager : MonoBehaviour
{
    [System.Serializable]
    public struct VisualEffect
    {
        public GameObject effect;
        public bool initialState;
    }

    public static VfxManager Instance { get; private set; }

    public float persistentDuration = 1.0f; 
    public List<VisualEffect> visualEffects;
    public List<ParticleSystem> persistentEffects; 

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
        foreach (var visualEffect in visualEffects)
        {
            visualEffect.effect.SetActive(visualEffect.initialState);
        }
    }

    public void SetEffectState(int index, bool state)
    {
        if (index >= 0 && index < visualEffects.Count)
        {
            visualEffects[index].effect.SetActive(state);
        }

        if (index == 0)
        {
            PlayPersistentVfx(); 
        }
    }

    public void DisableChannellingVfx()
    {
        Invoke(nameof(InvokeDisableChannellingVfx), 1f);
    }

    public void PlayPersistentVfx()
    {
        foreach (ParticleSystem particle in persistentEffects)
        {
            particle.Play();
        }
        StopPersistentAfterSomeTime();
    }

    public void StopPersistentVfx()
    {
        foreach (ParticleSystem particle in persistentEffects)
        {
            particle.Stop();
        }
    }

    public void StopPersistentAfterSomeTime()
    {
        StartCoroutine(DisablePersistentVfx());
    }

    private IEnumerator DisablePersistentVfx()
    {
        yield return new WaitForSeconds(persistentDuration);
        StopPersistentVfx(); 
    }

    private void InvokeDisableChannellingVfx()
    {
        VfxManager.Instance.SetEffectState(2, false);
    }
}
