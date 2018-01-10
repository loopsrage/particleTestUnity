using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTest : MonoBehaviour {

    // Use this for initialization
    private ParticleSystem PS;
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public Transform Target;
    void Start () {

        gameObject.AddComponent<ParticleSystem>();
        PS = gameObject.GetComponent<ParticleSystem>();
        MeshFilter mesh = gameObject.GetComponent<MeshFilter>();
        PS.ParticleRendererSettings(mesh.mesh);
        PS.ParticleColorOverLifetimeSettings();
        PS.ParticleEmissionSettings();
        PS.ParticleMainSettings();
        PS.ParticleShapeSettings();
        PS.ParticleSizeOverLifetimeSettings();
        PS.ParticleNoiseSettings();
        PS.ParticleCollisionSettings();
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
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
        transform.Rotate(Vector3.up, 1000f * Time.deltaTime);
        transform.Rotate(Vector3.right, 1000f * Time.deltaTime);
        // GetComponent<Rigidbody>().AddForce(Target.position * Time.deltaTime, ForceMode.Impulse);
	}
}
