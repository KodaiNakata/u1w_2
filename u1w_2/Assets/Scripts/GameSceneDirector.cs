using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// ゲーム画面の監督用のクラス
/// </summary>
public class GameSceneDirector : MonoBehaviour
{
    /// <summary>
    /// スコア用のテキスト
    /// </summary>
    [SerializeField]
    private GameObject scoreText;

    /// <summary>
    /// 残機用のテキスト
    /// </summary>
    [SerializeField]
    private GameObject zankiText;

    /// <summary>
    /// 結果用のパネル
    /// </summary>
    [SerializeField]
    private GameObject resultPanel;

    /// <summary>
    /// インスタンス
    /// </summary>
    public static GameSceneDirector instance { get; private set; }

    /// <summary>
    /// スコア
    /// </summary>
    private int score;

    /// <summary>
    /// 残機
    /// </summary>
    private int zanki;

    /// <summary>
    /// オブジェクトがアクティブになるたびに毎回呼ばれる処理
    /// </summary>
    private void OnEnable()
    {
        instance = this;
        score = 100;
        zanki = 5;
        scoreText.GetComponent<TextMeshProUGUI>().text = "のこり " + score.ToString() + "M";
        zankiText.GetComponent<TextMeshProUGUI>().text = "ざんき " + zanki.ToString() + "M";
    }

    /// <summary>
    /// 毎フレーム呼ばれる更新処理
    /// </summary>
    private void Update()
    {
        if (HasZanki())
        {
            resultPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    /// <summary>
    /// 残機が残っているか
    /// </summary>
    /// <returns>true：残っている、false：残っていない</returns>
    private bool HasZanki()
    {
        if (zanki == 0)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 残機を減らす
    /// </summary>
    public void DecreaseZanki()
    {
        zanki--;
        zankiText.GetComponent<TextMeshProUGUI>().text = "ざんき " + zanki.ToString();
    }


}
