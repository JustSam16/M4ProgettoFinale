using UnityEngine;

public class PooledBullet : MonoBehaviour
{
    public float speed = 10f;
    private BulletPool pool;

    void Start()
    {
        pool = BulletPool.Instance;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var hearts = other.GetComponent<PlayerHearts>();
            if (hearts != null)
                hearts.TakeDamage();
        }

        if (pool != null)
            pool.ReturnToPool(gameObject, false);
        else
            Destroy(gameObject);
    }
}

