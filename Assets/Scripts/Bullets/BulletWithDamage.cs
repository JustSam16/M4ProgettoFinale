using UnityEngine;

public class BulletWithDamage : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;

    void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(Disable), lifetime);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHearts hearts = other.GetComponent<PlayerHearts>();
            if (hearts != null)
            {
                hearts.TakeDamage();
            }

            BulletPoolManager.Instance.ReturnBullet(gameObject);
        }
    }

    void Disable()
    {
        BulletPoolManager.Instance.ReturnBullet(gameObject);
    }
}
