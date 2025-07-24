using UnityEngine;

public class Bullet : MonoBehaviour
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

    void Disable()
    {
        BulletPoolManager.Instance.ReturnBullet(gameObject);
    }
}

