using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullt : MonoBehaviour {
    [HideInInspector]
    public float Index;
    private Transform targe;
     [HideInInspector]
     public GameObject enemy;
     [HideInInspector]
     public Controller tower;
    private  Damage damage;
    private GameObject foe;
	// Use this for initialization
	void Start () {
        if (enemy != null&&tower!=null)
        {
            damage.point = tower.playerState.maxAttributes.GetAttributeValue("PA").value;
            damage.source = tower.gameObject;
            foe = enemy;
        }
	}
	// Update is called once per frame
	void Update () {
        Move();
	}      
    private void OnTriggerEnter(Collider other)
    {
      if (enemy != null&&foe!=null){

            if (foe.tag == "Pawn" && other.tag == "Pawn" && other.GetComponentInParent<PawnAIController>().teamIndex != Index)
            {
                
                other.GetComponentInParent<Controller>().ApplyDamage(damage);
                Destroy(this.gameObject);
            }
            if (foe.tag == "Player" && other.tag == "Player" && other.GetComponent<Controller>().teamIndex != Index)
            {
                other.GetComponent<Controller>().ApplyDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }
    private void Move()
   {
       if (enemy == null)
       {
           Destroy(this.gameObject);
       }
       else
       {
           float y=enemy.transform.position.y+0.4f;
           Vector3 targetVec3 = new Vector3(enemy.transform.position.x, y, enemy.transform.position.z);
           this.transform.LookAt(targetVec3);
           this.transform.position += this.transform.forward * Time.deltaTime *10;
          
       }
    }
}
