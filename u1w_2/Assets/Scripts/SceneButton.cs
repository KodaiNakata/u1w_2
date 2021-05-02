using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// 画面遷移用のボタン用のクラス
/// </summary>
public class SceneButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// 遷移先のシーン
    /// </summary>
    [SerializeField]
    private string sceneName;

    /// <summary>
    /// ボタンクリック時の処理
    /// </summary>
    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// カーソルを当てた時の処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (sceneName == "GameScene")
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
        }
    }

    /// <summary>
    /// カーソルから外れた時の処理
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (sceneName == "GameScene")
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
        }
    }
}
