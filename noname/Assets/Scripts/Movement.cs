using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    [Header("Componente")]
    public Rigidbody rb;
    public InputController input;
    public Animator animator;
    [Header("Valori")]
    public float walkSpeed = 5;
    public float runSpeed = 8;
    public float drunkSpeed = 3;
    public float rotationSpeed = 3;
    public bool isDrunk;

    //nu stiu la ce o sa ne ajute, dar poate poate
    public float luck;




    //Elemente
    private Vector2 moveValue;
    private float moveSpeed;
    private bool isRunning;

    private void Awake()
    {
        if (input == null)
        {
            input = GetComponent<InputController>();
        }
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }



    }


    private void FixedUpdate()
    {
        moveController();
    }
    private void Update()
    {
        isRunning = input.isRunning;
    }

    private void moveController()
    {
        moveValue = input.moveDirection;

        if (isDrunk)
        {
            moveSpeed = drunkSpeed;
        }
        else if (isRunning)
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }

        Vector3 moveDirection = new Vector3(moveValue.x, 0, moveValue.y).normalized;
        Vector3 targetPosition = rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(targetPosition);

        bool isWalking = moveDirection.magnitude != 0f && !isRunning;

        if (animator.GetBool("IsWalking") != isWalking)
        {
            animator.SetBool("IsWalking", isWalking);
        }

        if (animator.GetBool("IsRunning") != isRunning)
        {
            animator.SetBool("IsRunning", isRunning);
        }

    //   this.transform.Rotate(Vector3.up ,moveValue.x * rotationSpeed * Time.fixedDeltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
    }



}
