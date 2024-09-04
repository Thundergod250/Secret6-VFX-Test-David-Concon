using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float delay = 1f; 
    public float power = 10f;

    private void Start()
    {
        Invoke(nameof(SpawnProjectile), delay); 
    }

    public void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.GetComponent<Projectile>().power = power;
    }
}
