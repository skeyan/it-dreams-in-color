using UnityEngine;

/// Parallax scrolling script that should be assigned to a layer
public class Move : MonoBehaviour
{
    /// Scrolling speed
    public Vector2 speed = new Vector2(2, 2);

    /// Moving direction
    public Vector2 direction = new Vector2(-1, 0);

    /// Movement should be applied to camera
    public bool isLinkedToCamera = false;

    Transform cameraPos;
    Vector3 curCameraPos;
    Vector3 prevCameraPos;
    float deltaCameraPos;

    private void Start()
    {
        cameraPos = GameObject.Find("Main Camera").GetComponent<Transform>(); // get the transform position of the camera
        curCameraPos = cameraPos.position;
        prevCameraPos = cameraPos.position;
        deltaCameraPos = curCameraPos.x - prevCameraPos.x;
    }

    void Update()
    {
        // Camera calculations
        if(cameraPos.position != curCameraPos)
        {
            prevCameraPos = curCameraPos;
            curCameraPos = cameraPos.position;
        }

        deltaCameraPos = curCameraPos.x - prevCameraPos.x;
        Debug.Log("delta" + ' ' + curCameraPos + ' ' + prevCameraPos + ' '+ deltaCameraPos);


        if (deltaCameraPos < 0 && direction.x > 0)
        {
            direction = new Vector2(-1 * direction.x, direction.y);
        }
        else if(deltaCameraPos > 0 && direction.x < 0)
        {
            direction = new Vector2(-1 * direction.x, direction.y);
        }

        // Movement
        if(deltaCameraPos != 0)
        {
            Vector3 movement = new Vector3(speed.x * direction.x, speed.y * direction.y, 0);

            transform.Translate(movement);

            // Move the camera
            //if (isLinkedToCamera)
            //{
            //    Camera.main.transform.Translate(movement);
            //}
        }
       
    }
}