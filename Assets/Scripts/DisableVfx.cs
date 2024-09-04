using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableVfx : MonoBehaviour
{
    public float lifetime;

    private void OnEnable()
    {
        StartCoroutine(DisableAfterLifetime());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator DisableAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }
}
