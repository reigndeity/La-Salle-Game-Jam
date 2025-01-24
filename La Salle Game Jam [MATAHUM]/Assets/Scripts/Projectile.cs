using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Properties")]
    [SerializeField] float lifetime;
    public string projectileSequence;
    void Start()
    {
        Destroy(gameObject, lifetime);

        // Debug to verify the sequence
        Debug.Log($"Projectile spawned with sequence: {projectileSequence}");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Projectile hit {collision.gameObject.name}");
    }
}
