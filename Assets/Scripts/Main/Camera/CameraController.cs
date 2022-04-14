using System;
using UnityEngine;
using UnityEngine.U2D;

public class CameraController : MonoBehaviour
{
    public float lerpSpeed;
    public Vector3 offset;
    public Character character;

    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            if (Input.mouseScrollDelta.y > 0 && offset.z < -2f)
            {
                // ZOOM OUT
                offset.z += 2;
            }
            if (Input.mouseScrollDelta.y < 0 && offset.z > -16f)
            {
                // ZOOM IN
                offset.z -= 2;
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            // ROTATE LEFT
            transform.RotateAround(character.transform.position + offset, Vector3.back, 1);
            character.transform.Rotate(0f, 0f, -1.1525f);
        } 
        else if (Input.GetKey(KeyCode.E))
        {
            //ROTATE RIGHT
            transform.RotateAround(character.transform.position + offset, Vector3.forward, 1);
            character.transform.Rotate(0f, 0f, 1.1525f);
        }

        // APPLY OFFSET AND LERP
        transform.position = Vector3.Lerp(transform.position, character.transform.position + offset, lerpSpeed * Time.deltaTime);
        // APPLY OFFSET
        transform.position = character.transform.position + offset;
    }
}