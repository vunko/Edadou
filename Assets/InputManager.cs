using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputManager : MonoBehaviour {

    InputField inputField;

	// Use this for initialization
    //InputFieldコンポーネントの取得および初期化メソッド
	void Start () {

        inputField = GetComponent<InputField>();

    }
    /// 入力値を取得してLogに出力し、初期化
    /// </summary>


    public void InputLogger()
    {

        string inputValue = inputField.text;

        Debug.Log(inputValue);

        InitInputField();
    }


    // Update is called once per frame
    // InoutFieldの初期化用メソッド
    // 入力値をリセットして、フィールドにフォーカスする

    void InitInputField () {

        //値をリセット
        inputField.text = "";

        gameObject.SetActive(false);

        // フォーカス
        inputField.ActivateInputField();
	}
}
