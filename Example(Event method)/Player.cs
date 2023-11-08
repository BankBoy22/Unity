using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody rigid;
    private float moveForce = 7.0f;
    private float x_Axis; 
    private float z_Axis;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x_Axis = Input.GetAxis("Horizontal");
        z_Axis = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(x_Axis, 0, z_Axis);
        velocity *= moveForce;
        rigid.velocity = velocity;
    }

    // OnCollisionEnter 함수는 트리거와 충돌하는 순간 호출됩니다.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // "Enemy" 태그를 가진 오브젝트와 충돌한 경우 게임 종료
            GameOver();
        }
    }

    void GameOver()
    {
        // 게임 오버 시 원하는 동작 수행
        // 여기서는 간단하게 현재 씬을 재로드하는 것으로 대체합니다.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
