using UnityEngine;
using Unity.Cinemachine;

// Chạy sau CinemachineBrain (order âm) để đọc đúng vị trí camera sau khi Cinemachine cập nhật
[DefaultExecutionOrder(100)]
public class ParallaxController : MonoBehaviour
{
    [Tooltip("Tốc độ parallax. Giá trị càng nhỏ, lớp nền xa di chuyển càng ít.")]
    [Range(0.001f, 0.1f)]
    public float parallaxSpeed = 0.01f;

    private Transform cam;
    private Vector3 camPrevPos;
    private bool isInitialized = false;

    private GameObject[] backgrounds;
    private Material[] materials;
    private float[] backSpeed;
    private float[] textureOffsets;

    private void Start()
    {
        cam = Camera.main.transform;

        int count = transform.childCount;
        backgrounds = new GameObject[count];
        materials    = new Material[count];
        backSpeed    = new float[count];
        textureOffsets = new float[count];

        for (int i = 0; i < count; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            var rend = backgrounds[i].GetComponent<Renderer>();
            // Tạo material instance riêng để tránh thay đổi shared material
            materials[i] = rend.material;
            // Đảm bảo texture dùng Repeat wrap mode (chống vỡ ảnh)
            if (materials[i].mainTexture != null)
                materials[i].mainTexture.wrapMode = TextureWrapMode.Repeat;
            // Reset offset
            materials[i].SetTextureOffset("_MainTex", Vector2.zero);
            textureOffsets[i] = 0f;
        }
    }

    private void CalculateLayerSpeeds()
    {
        // Tìm lớp xa nhất so với camera (Z lớn nhất)
        float maxZDist = 0f;
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float z = backgrounds[i].transform.position.z - cam.position.z;
            if (z > maxZDist) maxZDist = z;
        }

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float z = backgrounds[i].transform.position.z - cam.position.z;
            // Lớp xa nhất (z = maxZDist) → speed = 0 (không cuộn)
            // Lớp gần nhất (z = 0) → speed = 1 (cuộn nhanh nhất)
            backSpeed[i] = (maxZDist > 0) ? (1f - z / maxZDist) : 0f;
        }
    }

    private void LateUpdate()
    {
        if (!isInitialized)
        {
            // Đợi ít nhất 2 frame để Cinemachine hoàn tất snap camera đến đúng vị trí player
            if (Time.frameCount < 3)
            {
                // Snap background vào đúng vị trí camera trong khi chờ
                transform.position = new Vector3(cam.position.x, transform.position.y, transform.position.z);
                camPrevPos = cam.position;
                return;
            }

            // Lúc này Cinemachine đã settle xong → lưu vị trí làm mốc
            camPrevPos = cam.position;
            transform.position = new Vector3(cam.position.x, transform.position.y, transform.position.z);
            CalculateLayerSpeeds();
            isInitialized = true;
            return;
        }

        // Tính mức thay đổi vị trí camera trong frame này
        float deltaX = cam.position.x - camPrevPos.x;
        camPrevPos = cam.position;

        // Kéo toàn bộ background parent theo camera X (để luôn nằm trong viewport)
        transform.position = new Vector3(cam.position.x, transform.position.y, transform.position.z);

        // Cuộn texture từng lớp với tốc độ riêng
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            textureOffsets[i] += deltaX * speed;
            materials[i].SetTextureOffset("_MainTex", new Vector2(textureOffsets[i], 0f));
        }
    }

    private void OnDestroy()
    {
        // Giải phóng material instance để tránh memory leak
        if (materials != null)
        {
            foreach (var mat in materials)
            {
                if (mat != null)
                    Destroy(mat);
            }
        }
    }
}
