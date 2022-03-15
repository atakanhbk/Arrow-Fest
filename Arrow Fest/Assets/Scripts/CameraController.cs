using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(new Vector3(0,transform.position.y,transform.position.z), new Vector3(0,target.transform.position.y+offset.y,target.transform.position.z+offset.z), 2 * Time.deltaTime);
    }
}
