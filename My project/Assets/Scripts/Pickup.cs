using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int pointValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            GameManager.Instance.UpdateScore(pointValue);
            GameManager.Instance.totalPickups -= 1;
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(15,30,45)*Time.deltaTime);
    }
}
