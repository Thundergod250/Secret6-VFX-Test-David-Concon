using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    public GameObject targetObject;

    private void Update()
    {
        if (targetObject != null)
        {
            transform.position = new Vector3(targetObject.transform.position.x, transform.position.y, targetObject.transform.position.z);
        }
    }
}
