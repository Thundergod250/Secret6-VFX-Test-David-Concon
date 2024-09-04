using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableVfx : MonoBehaviour
{
    public float lifetime;

    private void OnEnable()
    {
        Invoke(nameof(DisableObject), lifetime);
    }

    private void OnDisable()
    {
        CancelInvoke(); 
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
