using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

/// <summary>
/// ��ʑJ�ڗp�̃{�^���p�̃N���X
/// </summary>
public class SceneButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// �J�ڐ�̃V�[��
    /// </summary>
    [SerializeField]
    private string sceneName;

    /// <summary>
    /// �{�^���N���b�N���̏���
    /// </summary>
    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// �J�[�\���𓖂Ă����̏���
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
    /// �J�[�\������O�ꂽ���̏���
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
