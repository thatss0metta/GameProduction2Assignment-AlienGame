using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float speed = 5f;
    public float gravity = -9.8f;
    private PlayerInput playerInput;
    private InputAction flash;

    [Header("Stamina Main Parameters")]
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [SerializeField] private float staminaUseMultiplier = 5;
    [SerializeField] public bool useStamina = true;
    [SerializeField] private float timeBeforeStaminaRegenStarts = 5;
    [SerializeField] private float staminaValueIncrement = 2;
    [SerializeField] private float staminaTimeIncrement = 0.1f;
    [SerializeField] public bool canSprint = true;
    [SerializeField] private bool sprinting = false;

    [Header("Flash Main Parameters")]
    [SerializeField] private bool canFlash = true;
    [SerializeField] private float flashTimer = 20.0f;


    private float currentStamina;
    private Coroutine regeneratingStamina;
    public static Action<float> OnStaminaChange;
    [SerializeField] public bool hasKey = false;

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = new PlayerInput();
    }

    void Awake()
    {
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if(useStamina)
        {
            HandleStamina();
        }

        if(playerInput.OnFoot.Flash.triggered)
        {
            Debug.Log("Enemy flashed");
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
        {
            if(canSprint)
                speed = 8;    
            else 
                speed = 5;
        }
        else
            speed = 5;
    }

    public void Flash()
    {
        if(canFlash)
        {

            flashTimer -= Time.deltaTime;
        }
    }

    private void HandleStamina()
    {
        if(sprinting)
        {
            if(regeneratingStamina != null)
            {
                StopCoroutine(regeneratingStamina);
                regeneratingStamina = null;
            }

            currentStamina -= staminaUseMultiplier * Time.deltaTime;

            if(currentStamina < 0)
                currentStamina = 0;

            OnStaminaChange?.Invoke(currentStamina);

            if(currentStamina <= 0)
            {
                canSprint = false;
                speed = 5;
            }
            
        }
        if(!sprinting && currentStamina < maxStamina && regeneratingStamina == null)
        {
            regeneratingStamina = StartCoroutine(RegenerateStamina());
        }
    }

    private IEnumerator RegenerateStamina()
    {
        yield return new WaitForSeconds(timeBeforeStaminaRegenStarts);
        WaitForSeconds timeToWait = new WaitForSeconds(staminaTimeIncrement);

        while(currentStamina < maxStamina)
        {
            if(currentStamina > 0)
                canSprint = true;
            
            currentStamina += staminaValueIncrement;

            if(currentStamina > maxStamina)
                currentStamina = maxStamina;

            OnStaminaChange?.Invoke(currentStamina);

            yield return timeToWait;
        }

        regeneratingStamina = null;
    }
}