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

    // OnCollisionEnter �Լ��� Ʈ���ſ� �浹�ϴ� ���� ȣ��˴ϴ�.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // "Enemy" �±׸� ���� ������Ʈ�� �浹�� ��� ���� ����
            GameOver();
        }
    }

    void GameOver()
    {
        // ���� ���� �� ���ϴ� ���� ����
        // ���⼭�� �����ϰ� ���� ���� ��ε��ϴ� ������ ��ü�մϴ�.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
