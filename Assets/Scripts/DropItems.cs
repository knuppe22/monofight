using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    private float degreePerSecond = 60f;
    private void Update() 
    {
        transform.Rotate(Vector3.up * Time.deltaTime * degreePerSecond);
        
    }
    public int id;
}
