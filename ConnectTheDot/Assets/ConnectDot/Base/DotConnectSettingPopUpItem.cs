using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotConnectSettingPopUpItem : MonoBehaviour
{
    [HideInInspector] public Image img;
    [HideInInspector] public Transform trans;
    DotConnectSettingPopUp _settingsPopUp;
    Button button;
    int _index;
    private void Awake()
    {
        img = GetComponent<Image>();
        trans = transform;

        _settingsPopUp = trans.parent.GetComponent<DotConnectSettingPopUp>();
        _index = trans.GetSiblingIndex() - 1;

        button = GetComponent<Button>();
        button.onClick.AddListener(OnItemClick);

    }

    void OnItemClick()
    {
        _settingsPopUp.OnItemClick(_index);
        DotConnectAudioController.Instance.PlaySound(DotConnectAudioController.Instance.click);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnItemClick);

    }
}
