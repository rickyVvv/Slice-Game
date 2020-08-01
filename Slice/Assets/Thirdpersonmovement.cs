using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thirdpersonmovement : MonoBehaviour
{
    public CharacterController controller;
    public float turnSmoothtime = 0.1f;
    public float speed =6f;
    float turnSmoothVelocity;
    public Transform cam;
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal,0f,vertical).normalized; //this normalize indicated that when we smash both vertical and horizontal we WILL NOT move twice as fast
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle (transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothtime); //ref is a reference return value 
            transform.rotation = Quaternion.Euler(0f, angle ,0f); //this represtents the x,y,z components which represents the axis about which a rotation will occur 
            Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed* Time.deltaTime);

        }
    }
}
