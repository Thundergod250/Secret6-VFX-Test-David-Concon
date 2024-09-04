using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject vfx;

    private void Start()
    {
        vfx.SetActive(false);
    }

    public void EnableVFX()
    {
        vfx.SetActive(true);
    }
}
