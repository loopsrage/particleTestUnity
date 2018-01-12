using UnityEngine;
using System.Collections;

public class ScriptableParticle : ScriptableObject
{
    public void selectParticleEffects(GameObject ThisGameObject, MoveData.MoveTypes moveType)
    {
        ParticleSystem PS = ThisGameObject.GetComponent<ParticleSystem>();
        AnimationCurve EmissionCurve;
        AnimationCurve SizeCurve;
        string[] Layers = new string[] { "Players" };
        switch (moveType)
        {
            case MoveData.MoveTypes.Fire:
                // Main Settings
                PS.ParticleMainSettings(true, 0, 1f, 100f, 2f);

                // Emission Settings
                EmissionCurve = new AnimationCurve();
                EmissionCurve.AddKey(0f, 9f);
                PS.ParticleEmissionSettings(true, 1, true, false, null, EmissionCurve);

                // Size Settings
                SizeCurve = new AnimationCurve();
                SizeCurve.AddKey(0f, 1f);
                SizeCurve.AddKey(2f, 8f);
                PS.ParticleSizeOverLifetimeSettings(true, 1, SizeCurve);

                // Shape Settings
                PS.ParticleShapeSettings(true, ParticleSystemShapeType.Cone, ParticleSystemShapeMultiModeValue.Loop, false, 0f, 0f, 0f);

                // Trail Settings
                PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 6, true, false);

                // Collision Settings
                PS.ParticleCollisionSettings(true, 0, 0f, ParticleSystemCollisionMode.Collision3D, ParticleSystemCollisionQuality.High,
                    ParticleSystemCollisionType.World, true, true, Layers);

                // Noise Settings
                PS.ParticleNoiseSettings(true, 1, 0, 1);

                // Light Settings
                PS.ParticleLightSettings(false, 1, EmissionCurve, "Point light");

                // Renderer settings
                PS.ParticleRendererSettings(true, "Capsule", "nomat", "Fire", ParticleSystemRenderMode.Mesh);


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
                SizeCurve.AddKey(0f, 1f);
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
                PS.ParticleTrailSettings(true, ParticleSystemTrailTextureMode.Stretch, 1, true, false);

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
