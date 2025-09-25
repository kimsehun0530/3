using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour
{  
    [SerializeField] float speed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
     void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        float xDffset = hor * Time.deltaTime * speed;
        float newXpos = transform.localPosition.x + xDffset;
        float clampedXpos = Mathf.Clamp(newXpos, -xRange, xRange);

        float yDffset = ver * Time.deltaTime * speed;
        float newYpos = transform.localPosition.y + yDffset;
        float clampedYpos = Mathf.Clamp(newYpos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}
