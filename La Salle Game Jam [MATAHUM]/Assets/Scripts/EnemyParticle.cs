using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticle : MonoBehaviour
{
    public ParticleSystem _particleSystem;
    public SkinnedMeshRenderer _skinnedMeshRenderer;

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

}
