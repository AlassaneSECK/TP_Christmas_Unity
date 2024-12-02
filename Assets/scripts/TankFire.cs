using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class TankFire : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public GameObject sphere;
    public GameObject sphereSpawnPosition;
    public GameObject targetPosition;
    float force = 10f;
    private Coroutine shootingCoroutine; // Pour gérer la coroutine de tir

    void Update()
    {
        RaycastHit hit;

        // Lancer un Raycast vers l'avant
        if (Physics.Raycast(transform.position, transform.TransformDirection(targetPosition.transform.position), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(targetPosition.transform.position) * hit.distance, Color.green);
            
            if (shootingCoroutine == null)
            {
                shootingCoroutine = StartCoroutine(ShootRepeatedly());
            }
            
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            
                if (shootingCoroutine != null)
                {
                    StopCoroutine(shootingCoroutine);
                    shootingCoroutine = null;
                }
            }
        }
    
    }

// Coroutine pour tirer 3 fois par seconde
    private IEnumerator ShootRepeatedly()
    {
        while (true)
        {
            var newBullet = Instantiate(sphere, sphereSpawnPosition.transform.position, Quaternion.identity);
            Rigidbody sphereRb = newBullet.AddComponent<Rigidbody>();
            sphereRb.AddForce(transform.TransformDirection(targetPosition.transform.position) * force, ForceMode.Impulse);
            yield return new WaitForSeconds(1f / 3f);
            Destroy(newBullet);
        }
    }
}