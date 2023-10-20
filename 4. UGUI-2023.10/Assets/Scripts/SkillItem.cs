using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillItem : MonoBehaviour
{
    public float coldTime = 2;  // �����ȴʱ��

    public KeyCode keyCode = KeyCode.Alpha1;

    private float timer = 0;  // ʱ�Ӽ�ʱ

    private bool isColding = false;   // �����Ƿ���ȴ

    private Image coldMask;  // ��ȴͼ��

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
            timer += Time.deltaTime;   // ������ȴʱ��
            coldMask.fillAmount = (coldTime - timer) / coldTime;

            if (timer > coldTime)  // ��ȴʱ����������ȴʱ�䣬����isColding��coldMask��timer
            {
                isColding = false;
                coldMask.fillAmount = 0;
                timer = 0;
            }
        }

        if (Input.GetKeyDown(keyCode))   // ������������
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
        if (isColding == false)   // ��ʼ������
        {
            isColding = true;
            timer = 0;
            coldMask.fillAmount = 1;
        }
    }
}
