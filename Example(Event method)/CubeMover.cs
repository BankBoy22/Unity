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
        // �� �����Ӹ��� Z ��ǥ�� ���ҽ�Ŵ
        Vector3 position = transform.position;
        position.z -= speed * Time.deltaTime;
        transform.position = position;

        // Z ��ǥ�� -12 ���Ϸ� �������� ������Ʈ�� ����
        if (position.z < -12f)
        {
            Destroy(gameObject);
        }
    }
}
