using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ParticleExtensions : ScriptableObject
{

}
public static class ParticleExten
{
    private static Object LoadResource(string ResourcePath)
    {
        return Resources.Load(ResourcePath);
    }
    private static int GetLayer(string[] LayerNames)
    {
        if (LayerNames == null)
        {
            LayerNames = new string[] { "Default" };
        }
        return LayerMask.GetMask(LayerNames);
    }
    public static void ParticleRendererSettings(this ParticleSystem PS,
        bool enabled = true,
        string Resources_MeshObject = null,
        string Resources_Material = null,
        string Resources_TrailMaterial = null,
        ParticleSystemRenderMode RenderMode = ParticleSystemRenderMode.Stretch,
        ParticleSystemSortMode SortMode = ParticleSystemSortMode.Distance
        )
    {
        // Call Last
        ParticleSystemRenderer PR = PS.GetComponent<ParticleSystemRenderer>();
        // Renderer Settings
        PR.enabled = enabled;
        // Mesh Options / Material Options
        GameObject ResourceMesh = (GameObject)LoadResource(Resources_MeshObject);
        PR.material = (Material)LoadResource(Resources_Material);
        PR.trailMaterial = (Material)LoadResource(Resources_TrailMaterial);
        PR.mesh = ResourceMesh.GetComponent<MeshFilter>().sharedMesh;
        // Mode Settings
        PR.renderMode = RenderMode;
        PR.sortMode = SortMode;
    }
    public static void ParticleMainSettings(this ParticleSystem PS,
        bool LoopParticle = true,
        float GravityModifier = 0.0f,
        float StartSize = 0.0f,
        float StartSpeed = 0.0f,
        float StartLifetime = 0.0f)
    {
        ParticleSystem.MainModule main = PS.main;
        // Main Settings
        main.loop = LoopParticle;
        main.simulationSpace = ParticleSystemSimulationSpace.World;
        main.gravityModifier = GravityModifier;
        main.startSize = StartSize;
        main.startSpeed = StartSpeed;
        main.startLifetime = StartLifetime;
    }
    public static void ParticleColorOverLifetimeSettings(this ParticleSystem PS,
        bool enabled = true,
        Gradient gradient = null // Set Externally
        )
    {
        ParticleSystem.ColorOverLifetimeModule colorOverLifetimeModule = PS.colorOverLifetime;
        // ColorOverLifetime Settings
        colorOverLifetimeModule.enabled = enabled;
        colorOverLifetimeModule.color = new ParticleSystem.MinMaxGradient(gradient);
    }
    public static void ParticleSizeOverLifetimeSettings(this ParticleSystem PS,
        bool enabled = true,
        float scalar = 0.0f,
        AnimationCurve animationCurve = null // Set Externally
        )
    {
        ParticleSystem.SizeOverLifetimeModule sizeOverLifetimeModule = PS.sizeOverLifetime;
        // Size over Lifetime Settings
        ParticleSystem.MinMaxCurve Curve = new ParticleSystem.MinMaxCurve(scalar, animationCurve);
        sizeOverLifetimeModule.enabled = enabled;
        sizeOverLifetimeModule.size = Curve;
    }
    public static void ParticleShapeSettings(this ParticleSystem PS,
        bool enabled = true,
        ParticleSystemShapeType ShapeType = ParticleSystemShapeType.Cone,
        ParticleSystemShapeMultiModeValue RadiusMode = ParticleSystemShapeMultiModeValue.Loop,
        bool AlignDirection = false,
        float Angle = 0f,
        float Arc = 0f,
        float Radius = 0f)
    {
        ParticleSystem.ShapeModule shapeModule = PS.shape;
        // Shape settings
        shapeModule.shapeType = ShapeType;
        shapeModule.radiusMode = RadiusMode;
        shapeModule.alignToDirection = AlignDirection;
        shapeModule.angle = Angle;
        shapeModule.arc = Arc;
        shapeModule.radius = Radius;
    }
    public static void ParticleEmissionSettings(this ParticleSystem PS,
        bool enabled = true,
        float scalar = 0.0f,
        bool RateOverTime = false,
        bool Burst = false,
        float[][] BurstSettings = null, // Set Externally
        AnimationCurve animationCurve = null // Set Externally
        )
    {
        ParticleSystem.EmissionModule emissionModule = PS.emission;
        // Emission Settings
        emissionModule.enabled = enabled;
        if (RateOverTime)
        {
            ParticleSystem.MinMaxCurve EmissionCurve = new ParticleSystem.MinMaxCurve(scalar, animationCurve);
            emissionModule.rateOverTime = EmissionCurve;
        }
        if (Burst)
        {
            List<ParticleSystem.Burst> BurstFromArray = new List<ParticleSystem.Burst>();
            for (int T = 0; T < BurstSettings.Length; T++)
            {
                BurstFromArray.Add(new ParticleSystem.Burst(BurstSettings[T][0], BurstSettings[T][1]));
            }
            emissionModule.SetBursts(BurstFromArray.ToArray());
        }

    }
    public static void ParticleCollisionSettings(this ParticleSystem PS,
        bool enabled = true,
        float ColliderForce = 0f,
        float RadiusScale = 0f,
        ParticleSystemCollisionMode Mode = ParticleSystemCollisionMode.Collision3D,
        ParticleSystemCollisionQuality Quality = ParticleSystemCollisionQuality.High,
        ParticleSystemCollisionType Type = ParticleSystemCollisionType.World,
        bool DynamicColliders = true,
        bool SendMessages = true,
        string[] MaskNames = null // Set Outside, selects Default if none)
        ) 
    {
        ParticleSystem.CollisionModule collisionModule = PS.collision;
        // Collision Settings
        collisionModule.enabled = enabled;
        collisionModule.colliderForce = ColliderForce;
        collisionModule.radiusScale = RadiusScale;
        collisionModule.mode = Mode;
        collisionModule.quality = Quality;
        collisionModule.type = Type;
        collisionModule.collidesWith = GetLayer(MaskNames);
        collisionModule.enableDynamicColliders = DynamicColliders;
        collisionModule.sendCollisionMessages = SendMessages;
    }
    public static void ParticleTriggerSettings(this ParticleSystem PS,
        bool enabled = true)
    {
        ParticleSystem.TriggerModule triggerModule = PS.trigger;
        // Trigger Settings
        triggerModule.enabled = enabled;
    }
    public static void ParticleRotationSettings(this ParticleSystem PS,
        bool enabled = true)
    {
        ParticleSystem.RotationOverLifetimeModule rotationOverLifetimeModule = PS.rotationOverLifetime;
        // Rotation settings
        rotationOverLifetimeModule.enabled = enabled;
    }
    public static void ParticleNoiseSettings(this ParticleSystem PS,
        bool enabled = true,
        int Octaves = 0,
        float ScrollSpeed = 0.0f,
        int Strength = 0)
    {
        ParticleSystem.NoiseModule noiseModule = PS.noise;
        // Noise settings
        noiseModule.enabled = enabled;
        noiseModule.octaveCount = Octaves;
        noiseModule.scrollSpeed = ScrollSpeed;
        noiseModule.strength = Strength;
    }
    public static void ParticleLightSettings(this ParticleSystem PS,
        bool enabled = true,
        float scalar = 0.0f,
        AnimationCurve animationCurve = null, // Set outside
        string LightPrefab = null
        )
    {
        ParticleSystem.LightsModule lightsModule = PS.lights;
        // Light Settings
        lightsModule.enabled = enabled;
        lightsModule.light = (Light)LoadResource(LightPrefab);

        ParticleSystem.MinMaxCurve LightCurve = new ParticleSystem.MinMaxCurve(scalar, animationCurve);
        lightsModule.intensity = LightCurve;

    }
    public static void ParticleTrailSettings(this ParticleSystem PS,
        bool enabled = true,
        ParticleSystemTrailTextureMode TrailMode = ParticleSystemTrailTextureMode.Stretch)
    {
        ParticleSystem.TrailModule trailModule = PS.trails;
        // Trail Settings
        trailModule.enabled = enabled;
        trailModule.textureMode = TrailMode;
    }
    public static void ParticleSubSettings(this ParticleSystem PS,
        bool enabled = true)
    { // In progress
        ParticleSystem.SubEmittersModule subEmittersModule = PS.subEmitters;
        // Sub Emitters
        subEmittersModule.enabled = false;
        subEmittersModule.AddSubEmitter(new ParticleSystem(), ParticleSystemSubEmitterType.Birth, ParticleSystemSubEmitterProperties.InheritEverything);
    }
}
