using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirthPlace : GuardTower {
	// Use this for initialization
	// Update is called once per frame
  protected override  void Start()
    {
        slider.gameObject.transform.parent.gameObject.SetActive(false);
    }
   protected override void RenewHP()
    {
        return;
    }
   public override void ApplyDamage(Damage damage)
   {

       return;
   }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player" && other.GetComponent<Controller>().teamIndex == this.teamIndex)
        {
            float hp = other.GetComponent<Controller>().playerState.attributes.GetAttributeValue("HP").value;
            float mp = other.GetComponent<Controller>().playerState.attributes.GetAttributeValue("MP").value;
            float MaxHp = other.GetComponent<Controller>().playerState.maxAttributes.GetAttributeValue("HP").value;
            float MaxMp = other.GetComponent<Controller>().playerState.maxAttributes.GetAttributeValue("MP").value;
            if (hp <= MaxHp)
            {
                other.GetComponent<Controller>().playerState.attributes.IncreaseAttributeValue("HP", 5, MaxHp);
            }
            if (MaxMp > 0 && mp <= MaxMp)
            {
                other.GetComponent<Controller>().playerState.attributes.IncreaseAttributeValue("MP", 3, MaxMp);
            }
        }
    }
}
