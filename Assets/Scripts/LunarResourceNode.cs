using UnityEngine;
public class LunarResourceNode : MonoBehaviour
{
 public string resourceType="Regolith";public int yieldAmount=3;
 public bool Mine(LunarGame game){if(game==null)return false;game.AddResource(resourceType,yieldAmount);game.AddXP(12);Destroy(gameObject);return true;}
}
