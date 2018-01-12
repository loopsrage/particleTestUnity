using UnityEngine;
using System.Collections;

public class ScriptableParticle : ScriptableObject
{
    GameObject SubObject = null;
    public void selectParticleEffects(GameObject ThisGameObject, MoveData.MoveTypes moveType)
    {
        ParticleSystem PS = ThisGameObject.GetComponent<ParticleSystem>();
        AnimationCurve EmissionCurve;
        AnimationCurve SizeCurve;
        ParticleSystem SPS;
        AnimationCurve SPSCurve;
        ParticleSystem.Burst[] Bursts;
        string[] Layers = new string[] { "Players" };
        if (SubObject != null)
        {
            GameObject.Destroy(SubObject);
            SubObject = null;
        }
        SubObject = new GameObject();
        SubObject.AddComponent<ParticleSystem>();
        SubObject.transform.SetParent(PS.transform.parent);
        SubObject.transform.position = PS.transform.parent.position;
        switch (moveType)
        {
            case MoveData.MoveTypes.Fire:
                // Main Settings
                PS.ParticleMainSettings(true, 0, 1f, 100f, 2f);

                // Emission Settings
                EmissionCurve = new AnimationCurve();
                EmissionCurve.AddKey(0f, 1f);
                PS.ParticleEmissionSettings(true, 1, true, false, null, EmissionCurve);

                // Size Settings
                SizeCurve = new AnimationCurve();
                SizeCurve.AddKey(0f, 1f);
                SizeCurve.AddKey(2f, 3f);
                PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);

                // Shape Settings
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, false, 0f, 0f, 0f);

                // Trail Settings
                PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 2, true, false);

                // Collision Settings
                PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);

                // Noise Settings
                PS.ParticleNoiseSettings(true, 1, 0.1f, 1);

                // Light Settings
                PS.ParticleLightSettings(false, 1, EmissionCurve, "Point light");

                // Renderer settings
                PS.ParticleRendererSettings(true, "Capsule", "nomat", "Fire", ParticleSystemRenderMode.Mesh);

                // Velocity Settings
                PS.ParticleInheritVelocity();

                // Sub Particle Settings
                SPS = SubObject.GetComponent<ParticleSystem>();
                SPSCurve = new AnimationCurve();
                SPSCurve.AddKey(0f, 10f);
                Bursts = new ParticleSystem.Burst[]
                {
                        new ParticleSystem.Burst(1f,1,1)
                };
                SPS.ParticleEmissionSettings(true, 1f, false, true, Bursts);
                SPS.ParticleMainSettings(true, 0f, 1f, 1f, 1f, 1f);
                SPS.ParticleNoiseSettings(true, 0, 0, 0);
                SPS.ParticleShapeSettings(true, ParticleSystemShapeType.Donut, ParticleSystemShapeMultiModeValue.Loop, true, 0f, 0f, 0f);
                SPS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 0.1f, false, false);
                SPS.ParticleRendererSettings(true, "Capsule", "nomat", "Fire", ParticleSystemRenderMode.Stretch);

                PS.ParticleSubSettings(true, SubObject);
                break;
            case MoveData.MoveTypes.Lightning:
                // Main Settings
                PS.ParticleMainSettings(true, 0, 1f, 300f, 1f);

                // Emission Settings
                EmissionCurve = new AnimationCurve();
                EmissionCurve.AddKey(0f, 3f);
                PS.ParticleEmissionSettings(true, 1, true, false, null, EmissionCurve);

                // Size Settings
                SizeCurve = new AnimationCurve();
                SizeCurve.AddKey(0f, 0.5f);
                SizeCurve.AddKey(2f, 0f);
                PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);

                // Shape Settings
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, true, 0f, 0f, 0f);

                // Trail Settings
                PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 6, true, true);

                // Collision Settings
                PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);

                // Noise Settings
                PS.ParticleNoiseSettings(true, 6, 6, 6);

                // Light Settings
                PS.ParticleLightSettings(true, 1, EmissionCurve, "Point light");
                
                // Renderer settings
                PS.ParticleRendererSettings(true, "Capsule", "nomat", "BLT", ParticleSystemRenderMode.Mesh);

                // Rotation Settings:
                PS.ParticleRotationSettings();

                // Sub Particle Settings
                SPS = SubObject.GetComponent<ParticleSystem>();
                SPSCurve = new AnimationCurve();
                SPSCurve.AddKey(0f, 10f);
                Bursts = new ParticleSystem.Burst[]
                {
                        new ParticleSystem.Burst(1f,1,1)
                };
                SPS.ParticleEmissionSettings(true, 1f, false, true, Bursts);
                SPS.ParticleMainSettings(true, 0f, 1f, 15f, 0.5f, 0.5f);
                SPS.ParticleNoiseSettings(true, 10, 1, 10);
                SPS.ParticleShapeSettings(true, ParticleSystemShapeType.Donut, ParticleSystemShapeMultiModeValue.Loop, true, 0f, 0f, 0f);
                SPS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 0.1f, false, false);
                SPS.ParticleRendererSettings(true, "Capsule", "nomat", "BLT", ParticleSystemRenderMode.Stretch);

                PS.ParticleSubSettings(true, SubObject);

                break;
            case MoveData.MoveTypes.Ice:
                // Main Settings
                PS.ParticleMainSettings(true, 0, 1f, 400f, 6f);

                // Emission Settings
                EmissionCurve = new AnimationCurve();
                EmissionCurve.AddKey(0f, 2f);
                PS.ParticleEmissionSettings(true, 1, true, false, null, EmissionCurve);

                // Size Settings
                SizeCurve = new AnimationCurve();
                SizeCurve.AddKey(0f, 1f);
                PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);

                // Shape Settings
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, true, 0f, 0f, 0f);

                // Trail Settings
                PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 6, true, false);

                // Collision Settings
                PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);

                // Noise Settings
                PS.ParticleNoiseSettings(true, 0, 0, 0);

                // Light Settings
                PS.ParticleLightSettings(false, 1, EmissionCurve, "Point light");

                // Renderer settings
                PS.ParticleRendererSettings(true, "Capsule", "nomat", "ICE", ParticleSystemRenderMode.Mesh);

                // Rotation Settings:
                PS.ParticleRotationSettings();
                break;
            case MoveData.MoveTypes.Rock:
                // Main Settings
                PS.ParticleMainSettings(true, 0, 15f, 100f, 6f);

                // Emission Settings
                EmissionCurve = new AnimationCurve();
                EmissionCurve.AddKey(0f, 1f);
                PS.ParticleEmissionSettings(true, 1, true, false, null, EmissionCurve);

                // Size Settings
                SizeCurve = new AnimationCurve();
                SizeCurve.AddKey(0f, 1f);
                PS.ParticleSizeOverLifetimeSettings(false, 1, SizeCurve);

                // Shape Settings
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, true, 0f, 0f, 0f);

                // Trail Settings
                PS.ParticleTrailSettings(false, ParticleSystemTrailTextureMode.Stretch, 1, true, false);

                // Collision Settings
                PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);

                // Noise Settings
                PS.ParticleNoiseSettings(true, 0, 0, 0);

                // Light Settings
                PS.ParticleLightSettings(false, 1, EmissionCurve, "Point light");

                // Renderer settings
                PS.ParticleRendererSettings(true, "Capsule", "RockMat", "RockTrailMat", ParticleSystemRenderMode.Mesh);

                // Rotation Settings:
                PS.ParticleRotationSettings();
                break;
            default:
                break;
        }

    }
}
