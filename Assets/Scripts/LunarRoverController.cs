using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
/// <summary>Controllable rover, using force-driven movement for a weighty lunar feel.</summary>
public class LunarRoverController : MonoBehaviour
{
 public float driveSpeed=8,turnSpeed=85,battery=100;Rigidbody rb;Camera cam;
 void Start(){rb=GetComponent<Rigidbody>();rb.mass=900;rb.drag=1.8f;rb.angularDrag=4;rb.constraints=RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationZ;cam=Camera.main;if(cam==null){var c=new GameObject("Main Camera");c.tag="MainCamera";cam=c.AddComponent<Camera>();}}
 void LateUpdate(){if(cam){cam.transform.position=transform.position-transform.forward*9+Vector3.up*5;cam.transform.LookAt(transform.position+Vector3.up);}}
 void Update(){if(Input.GetKeyDown(KeyCode.Escape))Cursor.lockState=CursorLockMode.None;if(Input.GetMouseButtonDown(1))Cursor.lockState=CursorLockMode.Locked;}
 void FixedUpdate(){float v=Input.GetAxisRaw("Vertical"),h=Input.GetAxisRaw("Horizontal");if(battery>0){rb.AddForce(transform.forward*v*driveSpeed*100);rb.MoveRotation(rb.rotation*Quaternion.Euler(0,h*turnSpeed*Time.fixedDeltaTime,0));battery=Mathf.Max(0,battery-(Mathf.Abs(v)+Mathf.Abs(h))*.012f);}if(Input.GetKey(KeyCode.Space))rb.velocity*=.85f;}
}
