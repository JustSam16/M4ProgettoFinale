using UnityEngine;
using System.Collections;

public class BurstTurret : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 0.2f;
    public int burstCount = 3;
    public float burstCooldown = 2f;
    public float detectionRange = 10f;
    public LayerMask playerLayer;

    private bool isPlayerInRange = false;

    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);
        if (hit.Length > 0 && !isPlayerInRange)
        {
            isPlayerInRange = true;
            StartCoroutine(BurstLoop());
        }
        else if (hit.Length == 0 && isPlayerInRange)
        {
            isPlayerInRange = false;
            StopAllCoroutines();
        }
    }

    IEnumerator BurstLoop()
    {
        while (isPlayerInRange)
        {
            for (int i = 0; i < burstCount; i++)
            {
                GameObject bullet = BulletPoolManager.Instance.GetBullet(false);
                bullet.transform.position = firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.SetActive(true);

                yield return new WaitForSeconds(fireRate);
            }

            yield return new WaitForSeconds(burstCooldown);
        }
    }
}
