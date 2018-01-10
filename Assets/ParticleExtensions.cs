using UnityEngine;
using System.Collections;

public class ParticleExtensions : ScriptableObject
{

}
public static class ParticleExten
{
    public static void ParticleRendererSettings(this ParticleSystem PS, Mesh ThisMesh)
    {
        ParticleSystemRenderer PR = PS.GetComponent<ParticleSystemRenderer>();
        GameObject ResourceMesh = (GameObject)Resources.Load("Capsule");
        PR.enabled = true;
        PR.material = Resources.Load<Material>("Fire") as Material;
        PR.trailMaterial = Resources.Load<Material>("Fire") as Material;
        PR.renderMode = ParticleSystemRenderMode.Mesh;
        PR.mesh = ResourceMesh.GetComponent<MeshFilter>().sharedMesh;
        PR.sortMode = ParticleSystemSortMode.Distance;
    }
    public static void ParticleMainSettings(this ParticleSystem PS)
    {
        ParticleSystem.MainModule main = PS.main;
        // Main Settings
        main.loop = true;
        main.simulationSpace = ParticleSystemSimulationSpace.World;
        main.gravityModifier = 0f;
        main.startSize = 1f;
        main.startSpeed = 20f;
        main.startLifetime = 3f ;
    }
    public static void ParticleColorOverLifetimeSettings(this ParticleSystem PS)
    {
        ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = PS.colorOverLifetime;
        // ColorOverLifetime Settings
        colorOverLifetimeModule.enabled = false;
        Gradient G = new Gradient();
        G.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.yellow, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) });
        colorOverLifetimeModule.color = new ParticleSystem.MinMaxGradient(G);
    }
    public static void ParticleSizeOverLifetimeSettings(this ParticleSystem PS)
    {
        ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = PS.sizeOverLifetime;
        // Size over Lifetime Settings
        AnimationCurve animationCurve = new AnimationCurve();
        animationCurve.AddKey(0f,1f);
        animationCurve.AddKey(1f,0f);
        float scalar = 1.0f;
        ParticleSystem.MinMaxCurve Curve = new ParticleSystem.MinMaxCurve(scalar,animationCurve);
        sizeOverLifetimeModule.enabled = true;
        sizeOverLifetimeModule.size = Curve;
    }
    public static void ParticleShapeSettings(this ParticleSystem PS)
    {
        ParticleSystem.ShapeModule shapeModule = PS.shape;
        // Shape settings
        shapeModule.shapeType = ParticleSystemShapeType.Cone;
        shapeModule.radiusMode = ParticleSystemShapeMultiModeValue.Loop;
        shapeModule.alignToDirection = true;
        shapeModule.angle = 0;
        shapeModule.arc = 0;
        shapeModule.radius = 0;
    }
    public static void ParticleEmissionSettings(this ParticleSystem PS)
    {
        ParticleSystem.EmissionModule emissionModule = PS.emission;
        // Emission Settings
        emissionModule.enabled = true;
        float scaler = 1.0f;
        AnimationCurve animationCurve = new AnimationCurve();
        animationCurve.AddKey(0f, 10f);
        animationCurve.AddKey(1f, 10f);
        animationCurve.AddKey(2f, 10f);
        animationCurve.AddKey(3f, 10f);
        animationCurve.AddKey(4f, 10f);
        animationCurve.AddKey(5f, 10f);
        ParticleSystem.MinMaxCurve EmissionCurve = new ParticleSystem.MinMaxCurve(scaler,animationCurve);
        emissionModule.rateOverTime = EmissionCurve;
        emissionModule.SetBursts(
            new ParticleSystem.Burst[]
           {
                new ParticleSystem.Burst(3.4f, 3)
            }
        );
    }
    public static void ParticleCollisionSettings(this ParticleSystem PS)
    {
        ParticleSystem.CollisionModule collisionModule = PS.collision;
        // Collision Settings
        collisionModule.enabled = true;
        collisionModule.colliderForce = 1;
        collisionModule.radiusScale = 0;
        collisionModule.mode = ParticleSystemCollisionMode.Collision3D;
        collisionModule.quality = ParticleSystemCollisionQuality.High;
        collisionModule.type = ParticleSystemCollisionType.World;
        collisionModule.collidesWith = LayerMask.GetMask(new string[] { "Players" });
        collisionModule.enableDynamicColliders = true;
        collisionModule.sendCollisionMessages = true;
    }
    public static void ParticleTriggerSettings(this ParticleSystem PS)
    {
        ParticleSystem.TriggerModule triggerModule = PS.trigger;
        // Trigger Settings
        triggerModule.enabled = false;
    }
    public static void ParticleRotationSettings(this ParticleSystem PS)
    {
        ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = PS.rotationOverLifetime;
        // Rotation settings
        rotationOverLifetimeModule.enabled = true;
    }
    public static void ParticleNoiseSettings(this ParticleSystem PS)
    {
        ParticleSystem.NoiseModule noiseModule = PS.noise;
        // Noise settings
        noiseModule.enabled = false;
        noiseModule.octaveCount = 1;
        noiseModule.scrollSpeed = 0.1f;
        noiseModule.strength = 1;
    }
    public static void ParticleLightSettings(this ParticleSystem PS)
    {
        ParticleSystem.LightsModule lightsModule = PS.lights;
        // Light Settings
        lightsModule.enabled = true;
        float scaler = 1.0f;
        AnimationCurve animationCurve = new AnimationCurve();
        animationCurve.AddKey(0f,100f);
        ParticleSystem.MinMaxCurve LightCurve = new ParticleSystem.MinMaxCurve(scaler, animationCurve);
        lightsModule.light = Resources.Load<Light>("Area Light");
        lightsModule.intensity = LightCurve;

    }
    public static void ParticleTrailSettings(this ParticleSystem PS)
    {
        ParticleSystem.TrailModule trailModule = PS.trails;
        // Trail Settings
        trailModule.enabled = true;
        trailModule.textureMode = ParticleSystemTrailTextureMode.Stretch;
    }
    public static void ParticleSubSettings(this ParticleSystem PS)
    {
        ParticleSystem.SubEmittersModule subEmittersModule = PS.subEmitters;
        // Sub Emitters
        subEmittersModule.enabled = false;
        subEmittersModule.AddSubEmitter(new ParticleSystem(), ParticleSystemSubEmitterType.Birth, ParticleSystemSubEmitterProperties.InheritEverything);
    }
}
