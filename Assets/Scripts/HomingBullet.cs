using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float speed = 5f;
    public float trackingDuration = 2.5f;

    private Transform player;
    private float timer;
    private BulletPool pool;

    void Start()
    {
        pool = BulletPool.Instance;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void OnEnable()
    {
        timer = 0f;
    }

    void Update()
    {
        if (player != null && timer < trackingDuration)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.forward = direction;
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        timer += Time.deltaTime;
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
            pool.ReturnToPool(gameObject, true);
        else
            Destroy(gameObject);
    }
}
