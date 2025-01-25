using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Properties")]
    [SerializeField] float lifetime;
    public string projectileSequence;
    public string enemySequence;
     
    void Start()
    {
        Destroy(gameObject, lifetime);
        Debug.Log($"Projectile spawned with sequence: {projectileSequence}");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyStats enemyStats = other.gameObject.GetComponent<EnemyStats>();
            EnemyMovement enemyMovement = other.gameObject.GetComponent<EnemyMovement>();
            enemySequence = enemyStats.enemySequence;
            if (projectileSequence == enemySequence)
            {
                enemyStats.Die();
                
            }
            else if(projectileSequence != enemySequence)
            {
                enemyMovement.Angry();
            }
            Destroy(gameObject);
        }
    }
}
