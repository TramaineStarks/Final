using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public CharacterController controller;

    public float moveSpeed = 10f;

    public float rotateSpeed = 10f;

    public int health;

    private EnemyFollow enemy;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        enemy = FindObjectOfType<EnemyFollow>();
    }

    
    void Update()
    {
       float horizontalInput = Input.GetAxis("Horizontal");
       float verticalInput = Input.GetAxis("Vertical");  

       Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

       controller.Move(movement * moveSpeed * Time.deltaTime);

       if (movement != Vector3.zero)
       {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
       }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            health = health - enemy.damage;

            if(health <= 0)
            {
                GameManager.Instance.GameOver();

                Destroy(gameObject);
            }
        }
    }

}
