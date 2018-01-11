using System.Collections;
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

        PS.ParticleMainSettings(true, 0, 1f, 150f,1f);
        AnimationCurve EmissionCurve = new AnimationCurve();
        AnimationCurve SizeCurve = new AnimationCurve();
        //AnimationCurve VelocityCurveX = new AnimationCurve();
        //VelocityCurveX.AddKey(0f,0f);
        //VelocityCurveX.AddKey(2f,50f);
        SizeCurve.AddKey(0f,1f);
        SizeCurve.AddKey(2f,0f);
        EmissionCurve.AddKey(0f, 70f);
        PS.ParticleEmissionSettings(true, 1, true, false, null, EmissionCurve);
        PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, true, 0f, 0f, 0f);
        PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);
        PS.ParticleTrailSettings(true,ParticleSystemTrailTextureMode.Stretch);
        string[] Layers = new string[] { "Players" };
        PS.ParticleNoiseSettings(true,2,6,2);

        PS.ParticleCollisionSettings(true,0,0f,ParticleSystemCollisionMode.Collision3D,ParticleSystemCollisionQuality.High,
            ParticleSystemCollisionType.World,true,true,Layers);
        PS.ParticleRendererSettings(true, "Capsule", "nomat", "ICE",ParticleSystemRenderMode.Mesh);
        // PS.ParticleVelocityOverTimeSettings(true,ParticleSystemSimulationSpace.World,1,VelocityCurveX); CRASHES!!
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
         // transform.Rotate(Vector3.right, 1000f * Time.deltaTime);
	}
}
