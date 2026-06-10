using UnityEngine;

/// <summary>
/// Keeps the background aligned with the camera and scrolls each layer for parallax.
/// </summary>
[DefaultExecutionOrder(100)]
public class ParallaxController : MonoBehaviour
{
    private static readonly int MainTexId = Shader.PropertyToID("_MainTex");
    private static readonly int BaseMapId = Shader.PropertyToID("_BaseMap");

    [Tooltip("Main Camera transform. If empty, the script uses Camera.main.")]
    [SerializeField] private Transform cameraTransform;

    [Tooltip("Texture scroll multiplier. Smaller values make the parallax movement more subtle.")]
    [Range(0.001f, 0.2f)]
    [SerializeField] private float parallaxSpeed = 0.01f;

    private Transform cam;
    private Material[] materials;
    private float[] layerSpeeds;
    private int[] texturePropertyIds;
    private Vector2[] initialTextureOffsets;

    private float initialCameraX;
    private float initialBackgroundX;
    private bool initialized;

    private void Start()
    {
        cam = cameraTransform != null ? cameraTransform : Camera.main?.transform;

        if (cam == null)
        {
            Debug.LogError("[ParallaxController] Main Camera was not found.", this);
            enabled = false;
            return;
        }

        int count = transform.childCount;
        materials = new Material[count];
        layerSpeeds = new float[count];
        texturePropertyIds = new int[count];
        initialTextureOffsets = new Vector2[count];

        float maxDistanceFromCamera = 0f;
        for (int i = 0; i < count; i++)
        {
            float distance = Mathf.Abs(transform.GetChild(i).position.z - cam.position.z);
            maxDistanceFromCamera = Mathf.Max(maxDistanceFromCamera, distance);
        }

        for (int i = 0; i < count; i++)
        {
            InitializeLayer(i, maxDistanceFromCamera);
        }
    }

    private void InitializeLayer(int index, float maxDistanceFromCamera)
    {
        Transform child = transform.GetChild(index);
        Renderer layerRenderer = child.GetComponent<Renderer>();

        if (layerRenderer == null || layerRenderer.sharedMaterial == null)
        {
            Debug.LogWarning($"[ParallaxController] Layer '{child.name}' needs a Renderer with a material.", child);
            return;
        }

        Material material = new Material(layerRenderer.sharedMaterial);
        materials[index] = material;
        layerRenderer.sharedMaterial = material;

        int texturePropertyId = GetTexturePropertyId(material);
        texturePropertyIds[index] = texturePropertyId;

        if (texturePropertyId != 0)
        {
            initialTextureOffsets[index] = material.GetTextureOffset(texturePropertyId);

            Texture texture = material.GetTexture(texturePropertyId);
            if (texture != null)
            {
                texture.wrapMode = TextureWrapMode.Repeat;
            }
        }
        else
        {
            Debug.LogWarning(
                $"[ParallaxController] Material on layer '{child.name}' has no _MainTex or _BaseMap property.",
                child);
        }

        float distance = Mathf.Abs(child.position.z - cam.position.z);
        layerSpeeds[index] = maxDistanceFromCamera > 0f
            ? 1f - distance / maxDistanceFromCamera
            : 0f;
    }

    private static int GetTexturePropertyId(Material material)
    {
        if (material.HasProperty(MainTexId))
        {
            return MainTexId;
        }

        return material.HasProperty(BaseMapId) ? BaseMapId : 0;
    }

    private void LateUpdate()
    {
        if (!initialized)
        {
            // LateUpdate runs after CinemachineBrain, so these are the actual starting positions.
            initialCameraX = cam.position.x;
            initialBackgroundX = transform.position.x;
            initialized = true;
            return;
        }

        float cameraDeltaX = cam.position.x - initialCameraX;

        Vector3 backgroundPosition = transform.position;
        backgroundPosition.x = initialBackgroundX + cameraDeltaX;
        transform.position = backgroundPosition;

        for (int i = 0; i < materials.Length; i++)
        {
            Material material = materials[i];
            int texturePropertyId = texturePropertyIds[i];

            if (material == null || texturePropertyId == 0)
            {
                continue;
            }

            Vector2 offset = initialTextureOffsets[i];
            offset.x += cameraDeltaX * layerSpeeds[i] * parallaxSpeed;
            material.SetTextureOffset(texturePropertyId, offset);
        }
    }

    private void OnDestroy()
    {
        if (materials == null)
        {
            return;
        }

        foreach (Material material in materials)
        {
            if (material != null)
            {
                Destroy(material);
            }
        }
    }
}
