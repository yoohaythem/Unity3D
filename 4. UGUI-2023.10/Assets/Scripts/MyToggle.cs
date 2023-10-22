using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyToggle : MonoBehaviour
{
    public GameObject onGameObject;
    public GameObject offGameObject;

    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();   // ��ȡtoggle��������isOn�����жϳ�ʼ״̬

        OnValueChange(toggle.isOn);  // ���ݳ�ʼ״̬���Ƚ���һ�θ�ֵ
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnValueChange(bool isOn)
    {
        onGameObject.SetActive(isOn);
        offGameObject.SetActive(!isOn);
    }
}
