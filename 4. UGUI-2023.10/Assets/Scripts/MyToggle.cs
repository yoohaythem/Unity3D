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
        toggle = GetComponent<Toggle>();   // 获取toggle，根据其isOn属性判断初始状态

        OnValueChange(toggle.isOn);  // 根据初始状态，先进行一次赋值
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
