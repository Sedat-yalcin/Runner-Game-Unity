using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;
    private int desiredLane = 1;//0:left,1: middle,2 right
    public float laneDistance=4;//the  dictance between two lanes

    private bool isSliding = false;

    public float jumpForce;
    public float Gravity = -20;

    public Animator animator;
   



    void Start()
    {
        controller = GetComponent<CharacterController>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;
        //increase speed
        if(forwardSpeed<maxSpeed)
        forwardSpeed += 0.1f * Time.deltaTime;

        animator.SetBool("isGameStarted", true);
       // controller.isGrounded=Physics.CheckSphere(g)   ? Sonra buraya bak
        animator.SetBool("isGrounded", controller.isGrounded);
        // controller.Move(direction * Time.deltaTime);
        //Z ekseninde hareket etiriyoruz
        direction.z = forwardSpeed;

        //Gather the imputs on which lane we should be
        if (controller.isGrounded)
        {
            
            direction.y = -1;
            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeDown && !isSliding)
        {
            StartCoroutine(Slide());
        }

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;

        }

        if (SwipeManager.swipeLeft)
        {

            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;

        }

        //Calculate  where  we should  be in the  future 

        Vector3 targetPosistion = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosistion += Vector3.left * laneDistance;
        } else if (desiredLane == 2)
        {
            targetPosistion += Vector3.right * laneDistance;

        }

        // transform.position = targetPosistion;
        // transform.position = Vector3.Lerp(transform.position,targetPosistion,200*Time.deltaTime);
        // controller.center = controller.center;
        if (transform.position == targetPosistion)
        
            return;

            Vector3 diff = targetPosistion - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
        
    }
    //Update Metodundan daha iyi 
    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Debug.Log(" Çevre ile Tamesa geçildi.");

        if (hit.transform.tag == "obstacle")
        {
            Debug.Log("Engeller ile Çarpışma oldu");
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");

        }
    }

    private IEnumerator Slide()
    {

        isSliding = true;
        animator.SetBool("isSliding", true);

        controller.center = new Vector3(0, -1f, 0);
        controller.height = 1;
        yield return new WaitForSeconds(1.3f);

        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;
        animator.SetBool("isSliding", false);
        isSliding = false;

    }

}
