using UnityEngine;
using System.Collections;

public class ScriptableParticle : ScriptableObject
{
    public void selectParticleEffects(GameObject ThisGameObject)
    {
        ParticleSystem PS = ThisGameObject.GetComponent<ParticleSystem>();
        PS.ParticleMainSettings(true, 0, 1f, 150f, 1f);
        AnimationCurve EmissionCurve = new AnimationCurve();
        AnimationCurve SizeCurve = new AnimationCurve();
        //AnimationCurve VelocityCurveX = new AnimationCurve();
        //VelocityCurveX.AddKey(0f,0f);
        //VelocityCurveX.AddKey(2f,50f);
        SizeCurve.AddKey(0f, 1f);
        SizeCurve.AddKey(2f, 0f);
        EmissionCurve.AddKey(0f, 70f);
        PS.ParticleEmissionSettings(true, 1, true, false, null, EmissionCurve);
        PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, true, 0f, 0f, 0f);
        PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);
        PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch);
        string[] Layers = new string[] { "Players" };
        PS.ParticleNoiseSettings(true, 2, 6, 2);
        PS.ParticleLightSettings(true,1,EmissionCurve,"Point light");
        PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
            ParticleSystemCollisionType.World, true, true, Layers);
        PS.ParticleRendererSettings(true, "Capsule", "nomat", "ICE", ParticleSystemRenderMode.Mesh);
    }
}
