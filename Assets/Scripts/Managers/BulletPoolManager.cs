using UnityEngine;
using System.Collections.Generic;

public class BulletPoolManager : MonoBehaviour
{
    public static BulletPoolManager Instance;

    public GameObject normalBulletPrefab;
    public GameObject damageBulletPrefab;
    public GameObject homingBulletPrefab;
    public int poolSize = 20;

    private List<GameObject> normalBullets = new List<GameObject>();
    private List<GameObject> damageBullets = new List<GameObject>();
    private List<GameObject> homingBullets = new List<GameObject>();

    void Awake()
    {
        Instance = this;

        CreatePool(normalBulletPrefab, normalBullets);
        CreatePool(damageBulletPrefab, damageBullets);
        CreatePool(homingBulletPrefab, homingBullets);
    }

    void CreatePool(GameObject prefab, List<GameObject> pool)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetBullet(bool isDamage)
    {
        return isDamage
            ? GetFromPool(damageBullets, damageBulletPrefab)
            : GetFromPool(normalBullets, normalBulletPrefab);
    }

    public GameObject GetBullet(string type)
    {
        if (type == "normal") return GetFromPool(normalBullets, normalBulletPrefab);
        if (type == "damage") return GetFromPool(damageBullets, damageBulletPrefab);
        if (type == "homing") return GetFromPool(homingBullets, homingBulletPrefab);
        return null;
    }

    GameObject GetFromPool(List<GameObject> pool, GameObject prefab)
    {
        foreach (GameObject bullet in pool)
        {
            if (!bullet.activeInHierarchy)
                return bullet;
        }

        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
