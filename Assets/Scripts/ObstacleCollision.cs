using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private GameObject rawImage;

    void Start()
    {
        // 1. 항상 켜져 있는 부모 "Canvas"를 먼저 찾습니다.
        // 2. 그 자식 중에서 "RawImage"를 찾아 강제로 연결합니다. (누가 먼저 끄든 상관없이 다 찾아냅니다)
        rawImage = GameObject.Find("Canvas").transform.Find("RawImage").gameObject;

        rawImage.SetActive(false);
    }

    void OnCollisionEnter(Collision collision) // (OnTriggerEnter를 쓰셨다면 변경하세요)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rawImage.SetActive(true);
        }
    }
}