using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float speed = 5f;
    public float homingDuration = 2.5f;
    public float lifetime = 5f;

    private Transform target;
    private float timer;

    void OnEnable()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
        timer = 0f;
        CancelInvoke();
        Invoke(nameof(Disable), lifetime);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (target != null && timer < homingDuration)
        {
            Vector3 dir = (target.position - transform.position).normalized;
            transform.forward = dir;
        }

        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHearts hearts = other.GetComponent<PlayerHearts>();
            if (hearts != null)
                hearts.TakeDamage();

            BulletPoolManager.Instance.ReturnBullet(gameObject);
        }
    }

    void Disable()
    {
        BulletPoolManager.Instance.ReturnBullet(gameObject);
    }
}
