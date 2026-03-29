using UnityEngine;

public class StunPowerUp : MonoBehaviour
{
    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Enemy[] enemies = FindObjectsOfType<Enemy>();

            foreach (Enemy e in enemies)
            {
                e.Stun(5f); 
            }

            Destroy(gameObject);
        }
    }
}
