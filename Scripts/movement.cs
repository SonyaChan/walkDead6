using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    CharacterController Controller;
    public float Speed = 5;
    Transform cam;
    float gravity = 10;
    float verticalVelocity = 10;
    public float jumpVal = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;//عشان مو في الفنكشن يدور عليها كل مرة خلاص هنا لها رفرنس
    }

    // Update is called once per frame
    void Update()
    {
        bool isRun = Input.GetKey(KeyCode.LeftShift);// حطيتها قبل الابديت صار ايرور فهنا نحطها لانها بتحتاج ابديت كل مرة
        float s = isRun ? 2f : 1;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 Direction = new Vector3(h, 0, v);//نبغى نحدد الحركة اكثر

        if (Controller.isGrounded)
        { 
            if (Input.GetAxis("Jump") > 0)
            verticalVelocity = jumpVal;
        }
        else
                verticalVelocity -= gravity * Time.deltaTime;
        




        if (Direction.magnitude > 0.1)
        {

            float angle = Mathf.Atan2(Direction.x, Direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // نبغى هنا نحدد الزاوية اذا لفيت الكاميرا، تتغير زاوية المشي على الاكس والزد
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        Direction = cam.TransformDirection(Direction);
        
        Direction = new Vector3(Direction.x * Speed* s, verticalVelocity, Direction.z * Speed* s); //Direction = new Vector3(Direction.x, gravity, Direction.z); 
        Controller.Move(Direction * Time.deltaTime ); //Controller.Move(new Vector3(h,0,v)*Time.deltaTime *Speed);
    }


    public void DoAttack()
    {

        transform.Find("Collider").GetComponent<BoxCollider>().enabled = true; // لتفعيل الكولايدر عشان يصير الاتاك ويتفعل الدمج

    }

}

