using UnityEngine;
/// <summary>Procedurally creates a compact crater base and voxel-inspired resource deposits.</summary>
public class LunarWorld : MonoBehaviour
{
 public Transform roverSpawn; public Transform baseCenter;
 Material Make(Color c){var m=new Material(Shader.Find("Standard"));m.color=c;return m;}
 void Cube(string n,Vector3 p,Vector3 s,Material m){var g=GameObject.CreatePrimitive(PrimitiveType.Cube);g.name=n;g.transform.position=p;g.transform.localScale=s;g.GetComponent<Renderer>().material=m;}
 public void Generate(){var gray=Make(new Color(.35f,.36f,.4f));Cube("Crater floor",new Vector3(0,-1,0),new Vector3(90,2,90),gray);for(int i=0;i<32;i++){float a=i*Mathf.PI*2/32;Cube("Stepped crater rim",new Vector3(Mathf.Cos(a)*42,1.5f,Mathf.Sin(a)*42),new Vector3(7,5+Mathf.Sin(a*3)*1.5f,7),gray);}
 baseCenter=new GameObject("Outpost center").transform;Cube("Pressurized habitat",new Vector3(-5,1.5f,0),new Vector3(8,5,7),Make(new Color(.75f,.76f,.7f)));Cube("Airlock",new Vector3(0,1,0),new Vector3(2,3,2),Make(new Color(.3f,.42f,.5f)));Cube("Solar array",new Vector3(-8,.5f,8),new Vector3(10,1,4),Make(new Color(.12f,.22f,.48f)));Cube("Damaged landing pad",new Vector3(12,.1f,0),new Vector3(12,.3f,12),Make(new Color(.42f,.43f,.46f)));
 roverSpawn=new GameObject("Rover spawn").transform;roverSpawn.position=new Vector3(2,1,5);
 for(int i=0;i<42;i++){Vector2 d=Random.insideUnitCircle*34;if(d.magnitude<10)d=d.normalized*12;string t=i%9==0?"Ice":i%4==0?"Titanium":i%3==0?"Iron":"Regolith";Color c=t=="Ice"?new Color(.45f,.78f,.9f):t=="Titanium"?new Color(.65f,.68f,.72f):new Color(.48f,.39f,.32f);var g=GameObject.CreatePrimitive(PrimitiveType.Cube);g.name="Deposit - "+t;g.transform.position=new Vector3(d.x,.4f,d.y);g.transform.localScale=new Vector3(Random.Range(1f,2.2f),Random.Range(.7f,1.6f),Random.Range(1f,2f));g.transform.rotation=Quaternion.Euler(0,Random.Range(0,360),0);g.GetComponent<Renderer>().material=Make(c);g.AddComponent<LunarResourceNode>().resourceType=t;}}
}
