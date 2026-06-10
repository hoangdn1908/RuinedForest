using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private Transform cam;
    private Vector3 camPreviousPos;
    private float[] backSpeed;
    private float farthestBack;
    private GameObject[] backgrounds;
    private Material[] materials;
    private float[] textureOffsets; // lưu offset tích lũy để không bị reset

    [Range(0.01f, 0.05f)]
    public float parallaxSpeed;

    private bool isInitialized = false;

    private void Start()
    {
        cam = Camera.main.transform;

        int backCount = transform.childCount;
        materials = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];
        textureOffsets = new float[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            materials[i] = backgrounds[i].GetComponent<Renderer>().material;
            // Reset texture offset về 0 khi bắt đầu
            materials[i].SetTextureOffset("_MainTex", Vector2.zero);
            textureOffsets[i] = 0f;
        }
    }

    private void BackSpeedCalculate(int backCount)
    {
        farthestBack = 0f;
        for (int i = 0; i < backCount; i++)
        {
            float zDist = backgrounds[i].transform.position.z - cam.position.z;
            if (zDist > farthestBack)
                farthestBack = zDist;
        }

        for (int i = 0; i < backCount; i++)
        {
            float zDist = backgrounds[i].transform.position.z - cam.position.z;
            if (farthestBack > 0)
                backSpeed[i] = 1f - (zDist / farthestBack);
            else
                backSpeed[i] = 0f;
        }
    }

    private void LateUpdate()
    {
        if (!isInitialized)
        {
            // Đợi Cinemachine snap camera xong (frame 2 trở đi)
            if (Time.frameCount < 2)
                return;

            // Tại thời điểm này, camera đã ở đúng vị trí follow player
            camPreviousPos = cam.position;
            BackSpeedCalculate(backgrounds.Length);
            isInitialized = true;
            return; // frame này chưa di chuyển nên không cần update offset
        }

        // Tính delta X camera giữa frame trước và frame này
        float deltaX = cam.position.x - camPreviousPos.x;
        camPreviousPos = cam.position;

        // Di chuyển ParallaxController theo camera (để background luôn bao phủ màn hình)
        transform.position = new Vector3(cam.position.x, transform.position.y, 0);

        // Cộng dồn offset texture theo delta, không phải theo tổng khoảng cách
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            textureOffsets[i] += deltaX * speed;
            materials[i].SetTextureOffset("_MainTex", new Vector2(textureOffsets[i], 0));
        }
    }
}
