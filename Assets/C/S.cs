using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour
{  
    [SerializeField] float speed = 10f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float postionYawFactor = 2f;
    [SerializeField] float controlYawFactor = -10f;
    [SerializeField] float controlRollFactor = 5f;

    float hor;
    float ver;
    
     void Update()
     {
        ProcessTranslation();
        ProcessRotation();
     }

     void ProcessRotation()
     {
        float pitchPos = transform.localPosition.y * positionPitchFactor;
        float pitchCon = ver * controlPitchFactor;
        float pitch = pitchPos + pitchCon;

        float yawPos = transform.localPosition.x * postionYawFactor;
        float yawCon = hor * controlPitchFactor;
        float yaw = yawPos + yawCon;

        float roll = hor * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
     }
     private void ProcessTranslation()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        float xDffset = hor * Time.deltaTime * speed;
        float newXpos = transform.localPosition.x + xDffset;
        float clampedXpos = Mathf.Clamp(newXpos, -xRange, xRange);

        float yDffset = ver * Time.deltaTime * speed;
        float newYpos = transform.localPosition.y + yDffset;
        float clampedYpos = Mathf.Clamp(newYpos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXpos, clampedYpos, transform.localPosition.z);
    }
}
