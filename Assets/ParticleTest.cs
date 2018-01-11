﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTest : MonoBehaviour {

    // Use this for initialization
    private ParticleSystem PS;
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public Transform Target;
    public Rigidbody RB;
    void Start () {
        gameObject.AddComponent<ParticleSystem>();
        PS = gameObject.GetComponent<ParticleSystem>();
        RB = GetComponent<Rigidbody>();
        GameMaster.gameMaster.ParticleSystemSelector.selectParticleEffects(gameObject);
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        RB.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ |
            RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationY;
    }
    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;
        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Vector3 pos = collisionEvents[i].intersection;
                Vector3 force = collisionEvents[i].velocity * 10;
                rb.AddForce(force);
            }
            i++;
        }
    }
    // Update is called once per frame
    void Update () {
        transform.LookAt(Target.transform);
        if (Vector3.Distance(Target.position,transform.position) < 10)
        {
            PS.SwitchPower();
        }
        else
        {
            PS.SwitchPower();
        }
	}
}
