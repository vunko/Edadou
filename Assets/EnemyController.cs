using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Use this for initialization

    public int hp = 20;

    //ダメージを与えるときに呼び出される関数
    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log(gameObject.name + "に" + damage + "のダメージ！");

        //Hpが0以下になったとき
        if (hp <= 0)
        {
            Debug.Log(gameObject.name + "を倒した！");
        }

    }
}

