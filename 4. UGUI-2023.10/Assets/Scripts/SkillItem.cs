using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour
{
    public float coldTime = 2;  // 最大冷却时间

    public KeyCode keyCode = KeyCode.Alpha1;

    private float timer = 0;  // 时钟计时

    private bool isColding = false;   // 技能是否冷却

    private Image coldMask;  // 冷却图标

    // Start is called before the first frame update
    void Start()
    {
        coldMask = transform.Find("ColdMask").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isColding)
        {
            timer += Time.deltaTime;   // 更新冷却时间
            coldMask.fillAmount = (coldTime - timer) / coldTime;

            if (timer > coldTime)  // 冷却时间大于最大冷却时间，重置isColding、coldMask、timer
            {
                isColding = false;
                coldMask.fillAmount = 0;
                timer = 0;
            }
        }

        if (Input.GetKeyDown(keyCode))   // 按键触发技能
        {
            ReleaseSkill();
        }
    }

    public void OnSkillClick()
    {
        ReleaseSkill();
    }
    private void ReleaseSkill()
    {
        if (isColding == false)   // 初始化技能
        {
            isColding = true;
            timer = 0;
            coldMask.fillAmount = 1;
        }
    }
}
