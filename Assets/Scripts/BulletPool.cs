using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;

    public GameObject pooledBulletPrefab;
    public GameObject homingBulletPrefab;
    public int poolSize = 20;

    private Queue<GameObject> pooledBullets = new Queue<GameObject>();
    private Queue<GameObject> homingBullets = new Queue<GameObject>();

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            var bullet = Instantiate(pooledBulletPrefab);
            bullet.SetActive(false);
            pooledBullets.Enqueue(bullet);

            var homing = Instantiate(homingBulletPrefab);
            homing.SetActive(false);
            homingBullets.Enqueue(homing);
        }
    }

    public GameObject GetBullet(bool isHoming)
    {
        Queue<GameObject> pool = isHoming ? homingBullets : pooledBullets;

        if (pool.Count > 0)
        {
            GameObject bullet = pool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }

        return null;
    }

    public void ReturnToPool(GameObject bullet, bool isHoming)
    {
        bullet.SetActive(false);
        if (isHoming)
            homingBullets.Enqueue(bullet);
        else
            pooledBullets.Enqueue(bullet);
    }
}
