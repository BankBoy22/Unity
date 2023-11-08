using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject cubePrefab; // ť�� ������
    public float spawnInterval = 5.0f; // ���� ����
    public float cubeSpeed = 5.0f; // ť�� �̵� �ӵ�

    private float timeSinceLastSpawn = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnCube();
            timeSinceLastSpawn = 0.0f;
        }
    }

    void SpawnCube()
    {
        // ť�긦 (0, 15, 30) ��ġ���� x ��ǥ�� -7���� 7 ������ ������ ������ ����
        float randomX = Random.Range(-7f, 7f);
        Vector3 spawnPosition = new Vector3(randomX, 15f, 30f);

        GameObject newCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);

        // ť�꿡 Rigidbody ������Ʈ�� �����ͼ� ����
        Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();
        if (cubeRigidbody != null)
        {
            Vector3 direction = Vector3.forward; // �̵� ���� ����
            cubeRigidbody.velocity = direction * cubeSpeed;
        }

        // ť�긦 ������ ��ũ��Ʈ�� �߰�
        CubeMover mover = newCube.AddComponent<CubeMover>();
        mover.SetSpeed(5.0f); // Z ��ǥ ���� �ӵ� ����
    }
}
