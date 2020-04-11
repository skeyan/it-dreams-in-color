 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{

    public Transform whatToFollow;
    float speedToFollow;
    float newX, newY;
    public float radius;

    public string myFlyColor;
    public Transform flyCheckPoint;
    public LayerMask playerMask;
    public Vector3 startPosition;
    public Vector3 goalPosition;
    public bool isFollowing;

    //Start is called before the first frame update
    void Start()
    { 
        if(!whatToFollow)
        {
            whatToFollow = transform;
        }
        startPosition = transform.position; // get initial position coordinates
        speedToFollow = 1.5f;
        newX = Random.Range(whatToFollow.position.x - 1f, whatToFollow.position.x - 2f);
        newY = Random.Range(0.5f * Mathf.Sin(4f * Time.time) + whatToFollow.position.y + 1, 0.5f * Mathf.Sin(4f * Time.time) + whatToFollow.position.y + 2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionToFollow;
        positionToFollow = whatToFollow.position;

        //transform.position = new Vector2(whatToFollow.position.x - 1, 0.5f * Mathf.Sin(4f * Time.time) + whatToFollow.position.y + 2);
        if (Vector2.Distance(transform.position, positionToFollow) >= radius) // far enough away from player
        {

            newX = Random.Range(positionToFollow.x - 1f, positionToFollow.x - 2f);
            newY = Random.Range(0.5f * Mathf.Sin(4f * Time.time) + positionToFollow.y + 1, 0.5f * Mathf.Sin(4f * Time.time) + positionToFollow.y + 2);

            speedToFollow = 5.5f;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(newX, newY), speedToFollow * Time.deltaTime);

        }
        else // close or near player, distance to player is < 2.5f
        {
            newY = transform.position.y + Random.Range(-0.8f, 0.8f);
            newX = transform.position.x + Random.Range(-0.8f, 0.8f);

            speedToFollow = 0.4f;
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(newX, newY), speedToFollow * Time.deltaTime);
        }

        // Rudimentary follow method - improved one should snap the old follower into the new follower's place
        Collider2D results = Physics2D.OverlapCircle(flyCheckPoint.position, 0.3f, playerMask);
        GameObject c = results.gameObject;
        if (results)
        {
            if (whatToFollow != c.transform)
            {
                PlayerController pc = c.GetComponent<PlayerController>();
                if (pc.currentFlyColor == myFlyColor || pc.currentFlyColor == "BW" || myFlyColor == "BW")
                {
                    pc.currentFlyColor = myFlyColor;
                    pc.myFlies[0].GetComponent<FlyMovement>().whatToFollow = pc.myFlies[0].transform; // set old fly follower to follow itself
                                                                                                      //pc.myFlies[0].GetComponent<FlyMovement>().goalPosition = startPosition;
                                                                                                      //pc.myFlies[0].GetComponent<FlyMovement>().isFollowing = false;
                    pc.myFlies[0] = gameObject;
                    whatToFollow = c.transform;
                    //isFollowing = true;
                }
                else
                {

                }
            }
        }

    }

}
