using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDoor : MonoBehaviour
{
    public string myOrbColor;
    public Transform doorCheckPoint;
    public LayerMask playerMask;
    public Animator anim;
    AudioSource audSource;

    bool hasPlayed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audSource = GetComponent<AudioSource>();
        hasPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D results = Physics2D.OverlapCircle(doorCheckPoint.position, 1f, playerMask);
        if(results)
        {
            GameObject c = results.gameObject;
            PlayerController pc = c.GetComponent<PlayerController>();
            if(pc.currentFlyColor == myOrbColor)
            {
                anim.SetBool("ShouldOpen", true);
                if(!audSource.isPlaying && !hasPlayed)
                {
                    audSource.Play();
                    hasPlayed = true;
                }
                //SpriteRenderer sr = GetComponent<SpriteRenderer>();
                //Material newMat = Resources.Load("BasicMaterial", typeof(Material)) as Material;
                //sr.material = newMat;
                //Debug.Log("should open true");

                Animator pAnim = c.GetComponent<Animator>();
                pAnim.SetBool("Walking", false);
                pc.isMoving = false;
                pc.shouldTakeInput = false;
            }
        }
    }


}
