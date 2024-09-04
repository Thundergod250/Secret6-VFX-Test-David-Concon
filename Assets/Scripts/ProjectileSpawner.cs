using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public static ProjectileSpawner Instance { get; private set; }

    public GameObject projectilePrefab;
    public int poolSize = 2;
    public float delay = 1f;
    public float power = 10f;

    private Queue<GameObject> projectilePool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        projectilePool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false);
            projectilePool.Enqueue(obj);
        }
    }

    public void DelayProjectile()
    {
        StartCoroutine(SpawnProjectileWithDelay());
    }

    private IEnumerator SpawnProjectileWithDelay()
    {
        yield return new WaitForSeconds(delay);
        SpawnProjectile();
    }

    public void SpawnProjectile()
    {
        if (projectilePool.Count > 0)
        {
            GameObject projectile = projectilePool.Dequeue();
            projectile.transform.SetPositionAndRotation(transform.position, transform.rotation);
            Projectile projectileComponent = projectile.GetComponent<Projectile>();
            projectileComponent.power = power;

            projectile.SetActive(true);
            projectileComponent.ReEnableVfx();

            StartCoroutine(DisableProjectileAfterTime(projectile, 1.5f));
        }
        else
        {
            GameObject newProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            Projectile newProjectileComponent = newProjectile.GetComponent<Projectile>();
            newProjectileComponent.power = power;

            newProjectile.SetActive(true);
            newProjectileComponent.ReEnableVfx();

            projectilePool.Enqueue(newProjectile);
            StartCoroutine(DisableProjectileAfterTime(newProjectile, 1.5f));
        }
    }

    private IEnumerator DisableProjectileAfterTime(GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);
        projectile.SetActive(false);
        projectilePool.Enqueue(projectile);
    }
}
