using UnityEngine;

/// <summary>Compact readable HUD and keyboard interaction for the playable prototype.</summary>
public class LunarHUD : MonoBehaviour
{
    LunarGame game; string message="Welcome to the Moon. Mine nearby deposits with E."; float messageTime=8;
    GUIStyle title,body,button;
    public void Initialize(LunarGame g){game=g;}
    void Update(){messageTime-=Time.deltaTime;if(Input.GetKeyDown(KeyCode.E))MineNearest();
        if(Input.GetKeyDown(KeyCode.Alpha1))Show(game.Build("Solar"));if(Input.GetKeyDown(KeyCode.Alpha2))Show(game.Build("Habitat"));
        if(Input.GetKeyDown(KeyCode.Alpha3))Show(game.Build("Refinery"));if(Input.GetKeyDown(KeyCode.Alpha4))Show(game.Build("LandingPad"));
        if(Input.GetKeyDown(KeyCode.B))Show(game.Build("Delivery"));}
    void MineNearest(){LunarResourceNode[] nodes=FindObjectsOfType<LunarResourceNode>();LunarResourceNode best=null;float d=3.8f;
        foreach(var n in nodes){float nd=Vector3.Distance(game.rover.transform.position,n.transform.position);if(nd<d){d=nd;best=n;}}
        if(best){string kind=best.resourceType;best.Mine(game);Show("Collected "+kind+". +12 XP");}else Show("No deposit in range. Drive closer.");}
    void Show(string s){message=s;messageTime=5;}
    void OnGUI(){if(game==null)return;if(title==null){title=new GUIStyle(GUI.skin.label){fontSize=22,fontStyle=FontStyle.Bold};body=new GUIStyle(GUI.skin.label){fontSize=15};button=new GUIStyle(GUI.skin.button){fontSize=14};}
        GUI.color=new Color(.07f,.1f,.14f,.9f);GUI.Box(new Rect(12,12,340,250),GUIContent.none);GUI.color=Color.white;
        GUI.Label(new Rect(26,22,310,32),"LUNAR OUTPOST  /  "+"Mare Base",title);
        GUI.Label(new Rect(26,60,310,22),"Level "+game.level+"   XP "+game.xp+" / "+(game.level*100),body);
        GUI.Label(new Rect(26,84,310,22),"Crew "+game.crew+"  |  Power "+Mathf.RoundToInt(game.power)+"  |  O₂ "+Mathf.RoundToInt(game.oxygen),body);
        GUI.Label(new Rect(26,108,310,70),"REG "+game.inventory["Regolith"]+"  ICE "+game.inventory["Ice"]+"\nIRON "+game.inventory["Iron"]+"  Ti "+game.inventory["Titanium"]+"\nELEC "+game.inventory["Electronics"]+"  PARTS "+game.inventory["Parts"],body);
        GUI.Label(new Rect(26,180,310,72),"1 Solar (8 Iron, 2 Elec)\n2 Habitat (12 Iron, 15 Reg, 4 Elec)\n3 Refinery (15 Iron, 5 Ti)\n4 Repair pad | B Earth crew request",body);
        if(messageTime>0){GUI.color=new Color(.08f,.1f,.12f,.88f);GUI.Box(new Rect(Screen.width/2-240,Screen.height-75,480,50),GUIContent.none);GUI.color=Color.white;GUI.Label(new Rect(Screen.width/2-225,Screen.height-63,450,30),message,body);}
        GUI.Label(new Rect(Screen.width-300,12,290,60),"WASD Drive  |  E Mine  |  RMB mouse lock\nSpace Brake  |  Esc release cursor",body);
        if(!game.landingPadRepaired)GUI.Label(new Rect(Screen.width/2-160,18,320,30),"OBJECTIVE: Restore the landing pad",title);
    }
}
