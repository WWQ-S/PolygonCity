using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceController : MonoBehaviour
{
    public float speedWalk = 5.0f;
    public float speedRun = 10.0f;
    public GameObject[] targetPoint;
    private Animator animator;
    private string currentAnimation;
    private GameObject point;
    private int numPoint = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {        
        point = targetPoint[numPoint];

        if (Vector3.Distance(transform.position, point.transform.position) < 0.2f)
        {
            numPoint++;
            if (numPoint >= targetPoint.Length) numPoint = 0;
        }

        if (numPoint == 1 || numPoint == 3 || numPoint == 4 || numPoint == 5)
        {            
            Run(numPoint, speedRun);
        }        
        else
        {
            Walk(numPoint, speedWalk);
        }
    }
    void Walk(int i, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint[i].transform.position, speed * Time.deltaTime);
        transform.LookAt(targetPoint[i].transform.position);
        
        PlayAnimations("Walk");
    }
    void Run(int i, float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint[i].transform.position, speed * Time.deltaTime);
        transform.LookAt(targetPoint[i].transform.position);
        PlayAnimations("Run");
    }
    void PlayAnimations(string anim)
    {
        if (currentAnimation == anim) return;
        animator.Play(anim);
        currentAnimation = anim;
    }
}
