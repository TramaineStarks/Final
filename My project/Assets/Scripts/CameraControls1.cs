using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls1 : MonoBehaviour
{
  public GameObject target;

  public Vector3 posOffset;

  void Start()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    posOffset = transform.position - target.transform.position;
  }

  void LateUpdate()
  {
    transform.position = target.transform.position + posOffset;
  }
}
