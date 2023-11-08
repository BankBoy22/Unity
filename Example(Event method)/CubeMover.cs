using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private float speed = 1.0f;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 Z 좌표를 감소시킴
        Vector3 position = transform.position;
        position.z -= speed * Time.deltaTime;
        transform.position = position;

        // Z 좌표가 -12 이하로 내려가면 오브젝트를 삭제
        if (position.z < -12f)
        {
            Destroy(gameObject);
        }
    }
}
