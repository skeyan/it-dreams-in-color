using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerGB;
    public Transform player;
    Rigidbody2D p_rb;
    public float offset;

    Vector2 cameraDim;
    Vector2 worldDim;
    float cameraRightEdge;

    Vector2 actualCameraDim;
    Vector2 actualWorldDim;

    public float smoothSpeed = 0.5f;

    private void Start()
    {
        cameraDim = new Vector2(Screen.width, Screen.height);
        worldDim = Camera.main.ScreenToWorldPoint(new Vector2(cameraDim.x, cameraDim.y));
        p_rb = playerGB.GetComponent<Rigidbody2D>();

    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, -10);
        //Debug.Log(desiredPosition.x + " and " + smoothedPosition.x);

        if(desiredPosition.x <= 0)
        {
            desiredPosition.x = 0.1f;
        }
        else if(desiredPosition.x >=22)
        {
            desiredPosition.x = 21.9f;
        }
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    void Update() { 

    }
}
