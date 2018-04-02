using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{

    //剣の攻撃が当たった時のテキスト(追加）
    private GameObject BattleText;

    //武器のSpriteRendererコンポーネント
    public SpriteRenderer weaponSpriteRenderer;

    public Sprite swordSprite;       //剣の画像
    public Sprite shieldSprite;     //盾の画像
    public Sprite missingSprite;    //該当しなかったときの画像

    private void Start()
    {
        //ターンの処理のためスクリプトを呼び出す

        GameObject.Find("TurnController").GetComponent<TurnController>().playerTurn();

        //シーンビューからオブジェクトの実態を検索する(追加）
        this.BattleText = GameObject.Find("バトルテキスト");
    }

    //InputFieldから呼び出される関数　引数は入力された文字
    public void SubmitInputText(string inputText)
    {
        Debug.Log(inputText);

        //入力した文字が "剣" または "Sword" だった場合
        if (inputText == "sword" || inputText == "Sword" || inputText == "剣" )
        {
            weaponSpriteRenderer.sprite = swordSprite;

            //テキストをゲーム画面に表示させる（追加）
            this.BattleText.GetComponent<Text>().text = "剣で切り刻んだ！"; 

            //追記：剣の場合は１０のダメージ
            Debug.Log("剣で切り刻んだ！");
            Attack(10);
        }
        else if (inputText == "shield" || inputText == "Shield" || inputText == "盾" )
        {
            //入力した文字が "盾" または "Shield" だった場合
            weaponSpriteRenderer.sprite = shieldSprite;

            //テキストをゲーム画面に表示させる（追加）
            this.BattleText.GetComponent<Text>().text = "盾で殴った！";

            //追記：盾の場合は５のダメージ
            Debug.Log("盾で殴った！");
            Attack(5);
        }
        //何も該当しなかった場合
        else
        {
            weaponSpriteRenderer.sprite = missingSprite;
            //追記：失敗の場合は０のダメージ
            Debug.Log("何も起こらなかった！");
            Attack(0);
        }
    }
    //攻撃用の関数
    void Attack(int damage)
    {

        //TagにEnemyTagが設定されたゲームオブジェクトを検索
        GameObject enemyGameObject = GameObject.FindGameObjectWithTag("EnemyTag");

        //検索したゲームオブジェクトのEnemyControllerコンポーネントのDamage関数を呼び出す
        enemyGameObject.GetComponent<EnemyController>().Damage(damage);
    }
  
}
