using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject playerGO;

    [SerializeField]
    private GameObject attackHitBox;

    private Transform lockTargetTransform;
    private bool lockedToTarget;

    [SerializeField]
    private float playerSpeed = 10f;
    private float playerDiagonal;
    private float forward;
    private float strafe;

    private Animator animator;

    

    // Start is called before the first frame update
    void Awake()
    {
        playerDiagonal = playerSpeed / Mathf.Sqrt(2);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
            attackHitBox.SetActive(true);
        } else {
            attackHitBox.SetActive(false);
        }


        GetInput();


        Vector3 moveVector = new Vector3(strafe,0,forward);

        if(moveVector != Vector3.zero) 
            animator.SetBool("Moving", true);
        else
            animator.SetBool("Moving",false);

        playerGO.transform.position += moveVector * Time.deltaTime;

        RotatePlayer();

    }


    private void RotatePlayer() {
        Vector3 facingRotation = new Vector3(strafe,0,forward).normalized;

        if(lockedToTarget) {
            Vector3 targetPos = new Vector3(lockTargetTransform.position.x, transform.position.y,lockTargetTransform.position.z);

            Vector3 relativePos = targetPos - transform.position;

            // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos,Vector3.up);
            transform.rotation = rotation;
            return;
        }
            

        if(facingRotation != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(facingRotation),0.15F);
    }

    private void GetInput() {

        //if(Input.GetKey(KeyCode.W)) {
        //    forward = 1;
        //} else if(Input.GetKey(KeyCode.S)) {
        //    forward = -1;
        //} else {
        //    forward = 0;
        //}

        forward = 1;

        if(Input.GetKey(KeyCode.A)) {
            strafe = -1;
        } else if(Input.GetKey(KeyCode.D)) {
            strafe = 1;
        } else {
            strafe = 0;
        }

        if(strafe != 0 && forward != 0) {
            strafe *= playerDiagonal;
            forward *= playerDiagonal;
        } else {
            strafe *= playerSpeed;
            forward *= playerSpeed;
        }


        //if(Input.GetMouseButtonDown(0)) {
        //    animator.SetTrigger("Attack");
        //}
    }

}
