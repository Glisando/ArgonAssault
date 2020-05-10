using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float speed;
    [SerializeField] float xRange;
    [SerializeField] float yRange;

    [Header("Screen-position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 7f;


    [Header("Control-throw Based")]
    [SerializeField] float controlRollFactor = -30f;
    [SerializeField] float controlPitchFactor = -20f;

    bool isControlEnebled = true;
    Transform tf;

    float pitch = 0f;
    float yaw = 0f;
    float roll = 0f;

    float xThrow;
    float yThrow;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        xRange = 8;
        yRange = 4;
        tf = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnebled == true)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }
    
    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float yawDueToPosition = transform.localPosition.x * positionYawFactor;

        float pitchDueToControl = yThrow * controlPitchFactor;
        float rollDueToControl = xThrow * controlRollFactor;

        pitch = pitchDueToPosition + pitchDueToControl;
        yaw = yawDueToPosition;
        roll = rollDueToControl;

        tf.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = speed * xThrow * Time.deltaTime;
        float yOffset = speed * yThrow * Time.deltaTime;

        float rawNewXPos = Mathf.Clamp(tf.localPosition.x + xOffset, -xRange, xRange);
        float rawNewYPos = Mathf.Clamp(tf.localPosition.y + yOffset, -yRange, yRange);

        tf.localPosition = new Vector3(rawNewXPos, tf.localPosition.y, tf.localPosition.z);
        tf.localPosition = new Vector3(tf.localPosition.x, rawNewYPos, tf.localPosition.z);
    }

    public void OnPlayerDeath()
    {
        isControlEnebled = false;
    }
}
