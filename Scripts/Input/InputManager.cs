using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class InputManager : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;

        public bool leftMouse;
        public bool rightMouse;
        public bool middleMouse;
        public bool scrollMouseDown;
        public bool scrollMouseUp;



        public bool ButtonLeftShift;
        public bool ButtonE;
        public bool ButtonSpace;


        public bool rollFlag;
        public bool sprintFlag;
        public float rollInputTimer;

        InputControls inputActions;
        //PlayerAttack playerAttack;
        //PlayerInventory playerInventory;


        Vector2 movementInput;
        Vector2 camereInput;
        float scrollMouseInput;
        //float lastScrollMouseInput;



        private void Awake()
        {
            //playerAttack = GetComponent<PlayerAttack>();
            //playerInventory = GetComponent<PlayerInventory>();
        }

        private void OnEnable()
        {

            if (inputActions == null)
            {
                inputActions = new InputControls();
                inputActions.Input.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();

                inputActions.Input.MouseScroll.performed += inputActions => scrollMouseInput = inputActions.ReadValue<Vector2>().y;
                //lastScrollMouseInput = 0;
                //inputActions.PlayerMovement.Camera.performed += i => camereInput = i.ReadValue<Vector2>();
                //+= 运算符用于将一个事件处理程序附加到 performed 事件。当输入操作的 performed 事件触发时，附加的事件处理程序将被调用。
                //movementInput = inputActions.ReadValue<Vector2>();    这段是方法体
            }

            inputActions.Enable();
        }

        private void OnDisable()
        {
            inputActions.Disable();
        }

        private void LateUpdate()
        {
            leftMouse = false;
            rightMouse = false;
            rollFlag = false;
            sprintFlag = false;
            sprintFlag = false;
            ButtonE = false;
            middleMouse = false;
            ButtonSpace = false;
            scrollMouseDown = false;
            scrollMouseUp = false;
        }

        public void TickInput(float delta)
        {
            MoveInput(delta);
            HandleRollInput(delta);
            HandleMouseInput(delta);
            HandleKeyboardInput(delta);

        }

        private void MoveInput(float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            //mouseX = camereInput.x;
            //mouseY = camereInput.y;

        }

        private void HandleRollInput(float delta)
        {
            ButtonLeftShift = inputActions.Input.LeftShift.phase == UnityEngine.InputSystem.InputActionPhase.Started;
            if (ButtonLeftShift)
            {
                rollInputTimer += delta;
                sprintFlag = true;
            }

            else
            {
                if (rollInputTimer > 0 && rollInputTimer < 0.2f)
                {
                    sprintFlag = false;
                    rollFlag = true;
                }

                rollInputTimer = 0;
            }
        }


        private void HandleMouseInput(float delta)
        {
            inputActions.Input.LeftMouse.performed += i => leftMouse = true;
            inputActions.Input.RightMouse.performed += i => rightMouse = true;
            inputActions.Input.MiddleMouse.performed += i => middleMouse = true;

            if (scrollMouseInput>0)
            {
                scrollMouseUp = true;
            }
            else if (scrollMouseInput<0)
            {
                scrollMouseDown = true;
            }
            //if(scrollMouseUp==true)
            //    Debug.Log(scrollMouseUp);
            //lastScrollMouseInput = scrollMouseInput;
        }
        private void HandleKeyboardInput(float delta)
        {
            inputActions.Input.E.performed += i => ButtonE = true;
            inputActions.Input.Space.performed += i => ButtonSpace = true;
        }

    }

}
