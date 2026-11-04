using UnityEngine;
/// <summary>Attach to an empty GameObject to generate and start the prototype.</summary>
public class LunarGameBootstrap : MonoBehaviour
{
    void Awake(){Application.targetFrameRate=60;var world=new GameObject("Lunar World").AddComponent<LunarWorld>();world.Generate();var game=new GameObject("Lunar Game Systems").AddComponent<LunarGame>();game.Initialize(world);var hud=new GameObject("Lunar HUD").AddComponent<LunarHUD>();hud.Initialize(game);}
}
