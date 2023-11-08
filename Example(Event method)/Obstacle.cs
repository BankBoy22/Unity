using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject cubePrefab; // 큐브 프리팹
    public float spawnInterval = 5.0f; // 생성 간격
    public float cubeSpeed = 5.0f; // 큐브 이동 속도

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
        // 큐브를 (0, 15, 30) 위치에서 x 좌표가 -7에서 7 사이의 랜덤한 값으로 생성
        float randomX = Random.Range(-7f, 7f);
        Vector3 spawnPosition = new Vector3(randomX, 15f, 30f);

        GameObject newCube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);

        // 큐브에 Rigidbody 컴포넌트를 가져와서 설정
        Rigidbody cubeRigidbody = newCube.GetComponent<Rigidbody>();
        if (cubeRigidbody != null)
        {
            Vector3 direction = Vector3.forward; // 이동 방향 설정
            cubeRigidbody.velocity = direction * cubeSpeed;
        }

        // 큐브를 삭제할 스크립트를 추가
        CubeMover mover = newCube.AddComponent<CubeMover>();
        mover.SetSpeed(5.0f); // Z 좌표 감소 속도 설정
    }
}
