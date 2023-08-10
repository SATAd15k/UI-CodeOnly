using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
//this script can be found in the Component section under the option PRG/Mouse Look

[AddComponentMenu("Game Systems / Mouse Look")]
public class MouseLook : MonoBehaviour
{
    #region RotationalAxis
    //Create a public enum called RotationalAxis
    /*
    enums are what we call state value variables 
    they are comma separated lists of identifiers
    we can use them to create Types or Categorys
    */

    private enum RotationalAxis
    {
        MouseX,
        MouseY
    }
    
    #endregion
    #region Variables
    [Header("Rotation")]
    //create a public link to the rotational axis called axis and set a defualt axis
    [SerializeField] private RotationalAxis _axis = RotationalAxis.MouseX;

    [Header("Sensitivity")]
    //public floats for our x and y sensitivity
    public static float sensitivity = 15;
    //we will have to invert our mouse position later to calculate our mouse look correctly
    public static bool invertMouse;

    //[Range(0, 100)]


    //[Header("Y Rotation Clamp")]
    //max and min Y rotation
    [SerializeField] private Vector2 _clamp = new Vector2(-60, 60);


    //float for rotation Y
    private float _rotationY;

    #endregion
    #region Start
    //if our game object has a rigidbody attached to it
    private void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            //set the rigidbodys freezeRotaion to true
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        // Checking to se if script is on player obj vs camera obj to correct movement
        if(gameObject.tag == "Player")
        {
            _axis = RotationalAxis.MouseX;
        }
        else
        {
            _axis = RotationalAxis.MouseY;
        }
    }
    #endregion
    #region Update
    private void Update()
    {
        if (true)
        {
            #region Mouse X
            //if we are rotating on the X
            if (_axis == RotationalAxis.MouseX)
            {
                //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
                //x                y                          z
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
            }


            #endregion
            #region Mouse Y
            //else we are only rotation on the Y
            else
            {
                //our rotation Y is pulse equals  our mouse input for Mouse Y times Y sensitivity
                _rotationY += Input.GetAxis("Mouse Y") * sensitivity;

                //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
                _rotationY = Mathf.Clamp(_rotationY, _clamp.x, _clamp.y);

                //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and local euler angle Y on the y axis
                if (invertMouse)
                {
                    transform.localEulerAngles = new Vector3(_rotationY, 0, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(-_rotationY, 0, 0);
                }
            }




            #endregion
        }
    }


    #endregion
}













