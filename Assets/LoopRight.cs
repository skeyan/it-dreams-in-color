using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRight : MonoBehaviour
{
    public float spd;

    Vector2 cameraDim;
    Vector2 worldDim;

    float w;

    bool hasBeenCloned;

    // Start is called before the first frame update
    void Start()
    {
        //Must convert from camera dimensions to world/Unity unit dimensions
        //In world/Unity dimensions, (0,0) is in the center of the screen
        //In camera dimensions, (0,0) is in the bottom left corner of the screen

        cameraDim = new Vector2(Screen.width, Screen.height);
        worldDim = Camera.main.ScreenToWorldPoint(new Vector2(cameraDim.x, cameraDim.y));

        //Get the size of the Sprite Renderer to account for offset 
        w = GetComponent<Renderer>().bounds.size.x;

        //Prevents the game object from creating tons of clones in the span of time
        //between its clone should be created and it should be destroyed
        hasBeenCloned = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If the center of the sprite + half its width is greater than the world dimension, and hasn't already been cloned, clone it to repeat.
        //Make sure the sprites are the same size as the camera width, or there will be weird overlap or gaps!
        if (transform.position.x + w / 2 >= worldDim.x && !hasBeenCloned)
        {
            //Clone original, Position, Rotation
            Instantiate(gameObject, new Vector2(-worldDim.x - w / 2, transform.position.y), transform.rotation);
            hasBeenCloned = true;
        }
        else if (transform.position.x >= worldDim.x + w / 2)
        {
            Destroy(gameObject);
        }
        else
        {
            //Keep moving right
            float newX = transform.position.x + spd * Time.deltaTime;
            transform.position = new Vector2(newX, transform.position.y);
        }

    }
}
