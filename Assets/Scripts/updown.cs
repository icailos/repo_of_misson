using UnityEngine;

public class MovingUpDown : MonoBehaviour
{
    public float speed = 2f;    // 움직이는 속도
    public float height = 2f;   // 위아래로 움직일 폭(높이)

    private Vector3 startPos;   // 처음 시작 위치를 기억할 변수

    void Start()
    {
        // 게임이 시작될 때 장애물이 놓여있던 원래 위치를 기억해둡니다.
        startPos = transform.position;
    }

    void Update()
    {
        // Mathf.Sin을 이용해 시간에 따라 부드럽게 오르락내리락 하는 Y값을 계산합니다.
        float newY = startPos.y + (Mathf.Sin(Time.time * speed) * height);

        // 계산된 위치로 오브젝트를 이동시킵니다.
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}