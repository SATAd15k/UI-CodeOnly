using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro PRG/Character Movement
//This script requires the component Character controller to be attached to the Game Object

[AddComponentMenu("Game Systems / Player Movement")] // Makes a findable category aka tagging to help find when using add component
[RequireComponent(typeof(CharacterController))] // Has to have character controller obeject or it wont work

public class Movement : MonoBehaviour
{
    #region Extra Study
    //Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
    //Input(https://docs.unity3d.com/ScriptReference/Input.html)
    //CharacterController allows you to move the character kinda like Rigidbody (https://docs.unity3d.com/ScriptReference/
    #endregion
    #region Variables
    [Header("Direction + Physis")]
    [SerializeField] private Vector3 _moveDirection; //vector 3 is a container for 3 directions

    //[Header("Character")]
    //vector3 called moveDir //we will use this to apply movement in worldspace
    //Character controller called _charC CharacterController.html) 
    //[Header("Character Speeds")]
    //public float variables jumpSpeed 8 & speed 5 & gravity 20 

    [SerializeField] private CharacterController _characterController; // private not even children can get it
                                                                       // Serialisation when you grab data turn into smaller sized bytes of information for the computer vto read and understand
                                                                       // It is alo used for saving data and deserialisation is used for loading
    [Header("Character Speed + Gravity"), Space(20), Tooltip("Movespeed + gravity for character"), Range(0, 20)] // Space makes a gap and range creates a slider
    [SerializeField] private float _moveSpeed = 5; // this is done so the above header is only applied once rather than o each children
    [SerializeField] private float _jumpSpeed = 8, _speed = 5, _crouchSpeed = 2.5f, _sprintSpeed = 10, _gravity = 20;
    // condensing rather than have multiple lines
    #endregion
    #region Start  
    
    private void Start()
    {
        // assigning reference variable in which we have forcibly attached
        //_charc is set to the Character controller on this GameObject
        _characterController = GetComponent<CharacterController>();
    }

    #endregion
    #region Update


    private void Update()
    {
        if (true) // Only move if alive, maybe game paused; state of things
        {
            //if our character is grounded
            if (_characterController.isGrounded)
            {
                //set moveDir to the inputs direction
                _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); // 0 is used to separate jumping; like setting it to null

                //moveDir's forward is changed from global z (forward) to the Game Objects local Z (forward)//allows us to move where player is facing
                //change t player idea of forward not worlds idea (local vs global)
                _moveDirection = transform.TransformDirection(_moveDirection); //Z axis (depth) is forward

                //moveDir is multiplied by speed so we move at a decent pace
                _moveDirection *= _moveSpeed;
                
                //if the input button for jump is pressed then
                // jumping is a gravity ruler breaker :O
                if(Input.GetButton("Jump")) // trigger button
                {
                    //our moveDir.y is equal to our jump speed
                    _moveDirection.y = _jumpSpeed;
                }                
            }
            //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
            _moveDirection.y -= _gravity * Time.deltaTime;

            //we then tell the character Controller that it is moving in a direction multiplied Time.deltaTime
            _characterController.Move(_moveDirection * Time.deltaTime);
        }
    }
    #endregion
}










