using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    void Update()
    {
            gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * 10f);
        // if(Input.GetKey(KeyCode.A)) {
        // }
        
        // else if(Input.GetKey(KeyCode.D)) {
        //     gameObject.transform.Rotate(0f, 0f, -10f * Time.deltaTime * 10f);
        // }
    }
}
