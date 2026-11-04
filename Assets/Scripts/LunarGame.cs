using System.Collections.Generic;using UnityEngine;
/// <summary>Prototype economy, XP progression, outpost upkeep and Earth crew request.</summary>
public class LunarGame : MonoBehaviour
{
 public readonly Dictionary<string,int> inventory=new Dictionary<string,int>();public int level=1,xp=0,crew=1,scientists=0,technicians=0,workers=0;public float power=40,oxygen=100;public bool landingPadRepaired=false;public LunarWorld world;public LunarRoverController rover;float upkeep;
 public void Initialize(LunarWorld w){world=w;foreach(string r in new[]{"Regolith","Ice","Iron","Titanium","Electronics","Parts"})inventory[r]=0;SpawnRover();}
 void SpawnRover(){var g=GameObject.CreatePrimitive(PrimitiveType.Cube);g.name="Player Lunar Rover";g.transform.position=world.roverSpawn.position;g.transform.localScale=new Vector3(2.5f,1.2f,3.5f);g.GetComponent<Renderer>().material.color=new Color(.82f,.48f,.16f);g.AddComponent<Rigidbody>();rover=g.AddComponent<LunarRoverController>();}
 void Update(){upkeep+=Time.deltaTime;if(upkeep>=20){upkeep=0;power=Mathf.Max(0,power-crew*1.2f);oxygen=Mathf.Max(0,oxygen-crew*.8f);}}
 public void AddResource(string k,int n){if(!inventory.ContainsKey(k))inventory[k]=0;inventory[k]+=n;}public void AddXP(int n){xp+=n;while(xp>=level*100){xp-=level*100;level++;}}
 bool Can(params string[] costs){for(int i=0;i<costs.Length;i+=2)if(!inventory.ContainsKey(costs[i])||inventory[costs[i]]<int.Parse(costs[i+1]))return false;return true;}
 void Pay(params string[] costs){for(int i=0;i<costs.Length;i+=2)inventory[costs[i]]-=int.Parse(costs[i+1]);}
 public string Build(string item){switch(item){case "Solar":if(!Can("Iron","8","Electronics","2"))return "Need 8 Iron + 2 Electronics";Pay("Iron","8","Electronics","2");power+=35;AddXP(35);return "Solar panel deployed (+35 power)";
 case "Habitat":if(!Can("Iron","12","Regolith","15","Electronics","4"))return "Need 12 Iron, 15 Regolith, 4 Electronics";Pay("Iron","12","Regolith","15","Electronics","4");crew++;oxygen+=25;AddXP(60);return "Habitat expanded; crew capacity increased.";
 case "Refinery":if(!Can("Iron","15","Titanium","5"))return "Need 15 Iron + 5 Titanium";Pay("Iron","15","Titanium","5");AddXP(80);return "Refinery constructed.";
 case "LandingPad":if(!Can("Iron","20","Parts","10","Regolith","30"))return "Repair: 20 Iron, 10 Parts, 30 Regolith";Pay("Iron","20","Parts","10","Regolith","30");landingPadRepaired=true;AddXP(150);return "Landing pad restored! Earth deliveries unlocked.";
 case "Delivery":if(!landingPadRepaired)return "Repair the landing pad first.";if(level<3)return "Reach level 3 to request crew.";if(power<20||oxygen<30)return "Stabilize power (20+) and oxygen (30+) first.";crew+=3;scientists++;technicians++;workers++;AddResource("Electronics",5);AddResource("Parts",10);power+=30;oxygen+=40;AddXP(100);return "Earth delivery: scientist, technician, worker and supplies arrived.";default:return "Unknown action.";}}
}
