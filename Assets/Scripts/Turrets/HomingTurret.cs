using UnityEngine;

public class HomingTurret : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 3f;
    public float detectionRange = 12f;
    public LayerMask playerLayer;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        Collider[] hit = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);

        foreach (Collider col in hit)
        {
            Vector3 dirToPlayer = (col.transform.position - transform.position).normalized;
            float dot = Vector3.Dot(transform.forward, dirToPlayer);

            if (dot > 0.5f && timer >= fireRate) 
            {
                GameObject bullet = BulletPoolManager.Instance.GetBullet("homing");
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.SetActive(true);
                timer = 0f;
                break;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}

