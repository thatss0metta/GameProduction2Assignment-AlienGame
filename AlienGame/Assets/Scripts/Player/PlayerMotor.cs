using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;

    [Header("Stamina Main Parameters")]
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [SerializeField] private float staminaUseMultiplier = 5;
    [SerializeField] public bool useStamina = true;
    [SerializeField] private float timeBeforeStaminaRegenStarts = 5;
    [SerializeField] private float staminaValueIncrement = 2;
    [SerializeField] private float staminaTimeIncrement = 0.1f;
    [SerializeField] private bool canSprint = true;
    [SerializeField] private bool sprinting = false;

    private float currentStamina;
    private Coroutine regeneratingStamina;
    [SerializeField] public bool hasKey = false;

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if(useStamina)
        {
            HandleStamina();
        }
    }
    //Receive inputs from InputManager.cs and applies them to character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if(sprinting)
            speed = 8;    
        else 
            speed = 5;
        
    }

    private void HandleStamina()
    {
        if(sprinting)
        {
            currentStamina -= staminaUseMultiplier * Time.deltaTime;

            if(currentStamina < 0)
            {
                currentStamina = 0;
            }
            if(currentStamina <= 0)
            {
                
            }
        }
    }
}