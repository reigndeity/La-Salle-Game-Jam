using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float currentSpeed;
    public bool isAngry;
    private bool isOrderCompleted;
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
        currentSpeed = speed;
    }
    private void Update()
    {
        if (target != null)
        {
            if (GameManager.Instance.isGameStart == true && !isOrderCompleted)
            {
                Vector3 direction = (target.transform.position - transform.position).normalized;
                transform.Translate(direction * speed * Time.deltaTime, Space.World);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                speed = currentSpeed;
            }
            else
            {
                speed = 0;
            }

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
            AudioManager.instance.EnemyAngry();
            _animator.SetInteger("animState", 1);
        }
    }

    public void Catch()
    {
        AudioManager.instance.FinishedOrder();
        _capsuleCollider.enabled = false;
        _enemyStats.ingr_PopUp.SetActive(false);
        isOrderCompleted = true;
        speed = 0;
        _animator.SetInteger("animState", 2);
        Invoke("PoofMyself", 2.01f);
        Invoke("DestroyMyself", 4.01f);
    }

    public void TooLate()
    {
        AudioManager.instance.EnemyEndPoint();
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
