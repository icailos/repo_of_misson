using UnityEngine;

public class Rotator : MonoBehaviour
{
    // 인스펙터 창에서 회전 속도를 조절할 수 있게 열어둡니다.
    public float rotateSpeed = 100f;

    void Update()
    {
        // Time.deltaTime을 곱해줘야 컴퓨터 성능과 상관없이 일정한 속도로 돕니다.
        // 현재는 Y축(위아래 기둥 기준)으로 도는 세팅입니다.
        // X축이나 Z축으로 돌리고 싶다면 숫자의 위치를 (rotateSpeed * Time.deltaTime, 0, 0) 식으로 바꾸면 됩니다.
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}