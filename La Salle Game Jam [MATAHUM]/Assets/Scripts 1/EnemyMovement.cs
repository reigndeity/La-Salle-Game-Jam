using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public bool isAngry;
    public float angrySpeed = 1.5f;
    public GameObject target;
    public Animator _animator;
    public CapsuleCollider _capsuleCollider;
    private EnemyStats _enemyStats;

    public GameObject _particleObj;
    public SkinnedMeshRenderer _skinnedMeshRenderer;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _enemyStats = GetComponent<EnemyStats>();
    }
    private void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            TooLate();
        }
    }

    public void Angry()
    {
        if(!isAngry)
        {
            isAngry = true;
            speed += angrySpeed;
            _animator.SetInteger("animState", 1);
        }
    }

    public void Catch()
    {
        _capsuleCollider.enabled = false;
        _enemyStats.ingr_PopUp.SetActive(false);
        speed = 0;
        _animator.SetInteger("animState", 2);
        Invoke("PoofMyself", 2.01f);
        Invoke("DestroyMyself", 4.01f);
    }

    public void TooLate()
    {
        _capsuleCollider.enabled = false;
        _enemyStats.ingr_PopUp.SetActive(false);
        speed = 0;
        GameManager.Instance.AddPressure(1);
        _animator.SetInteger("animState", 3);
        Invoke("PoofMyself", 2.01f);
        Invoke("DestroyMyself", 4.01f);
    }

    public void PoofMyself()
    {
        _particleObj.SetActive(true);
        _skinnedMeshRenderer.enabled = false;
    }
    public void DestroyMyself()
    {
        Destroy(gameObject);
    }
}
