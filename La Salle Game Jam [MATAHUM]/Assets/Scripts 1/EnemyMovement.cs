using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject target;

    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            GameManager.Instance.AddPressure(1);
            Debug.Log("Adding Pressure Counter");
            Destroy(this.gameObject);
        }
    }
}
