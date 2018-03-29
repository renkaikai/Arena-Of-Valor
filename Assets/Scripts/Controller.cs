using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    /// <summary>
    /// 角色的状态
    /// </summary>
    [HideInInspector]
    public PlayerState playerState;
    [HideInInspector]
    public int teamIndex;
    [HideInInspector]
    public GameObject ReceiveDamgeSource;

    // 拥有的角色
    private Character _character;

    public Character GetCharacter()
    {
        return _character;
    }
    /// <summary>
    /// 拥有角色
    /// </summary>
    /// <param name="character"></param>
    public void Possess(Character character)
    {
        character.controller = this;
        _character = character;
        // 更新控制器的 Transform
        transform.position = character.transform.position;
        transform.rotation = character.transform.rotation;
    }
    /// <summary>
    /// 取消拥有角色
    /// </summary>
    public void Unpossess()
    {
        _character.controller = null;
        _character = null;
    }


    public virtual void ApplyDamage(Damage damage)
    {
        ReceiveDamgeSource = damage.source;
        this.playerState.attributes.IncreaseAttributeValue(AttributeItem.HP, -damage.point);
        if (this is PlayerController) {
            Debug.LogFormat("HHHHHHHHH {0},{1}", this.playerState.attributes.GetAttributeValue(AttributeItem.HP), damage.point);
        }
    }
}
