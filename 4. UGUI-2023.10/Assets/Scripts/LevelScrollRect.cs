using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelScrollRect : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private ScrollRect scroll;  // private,����ͨ����帳ֵ

    private float[] pagePosition = new float[4] { 0, 0.3333f, 0.6666f, 1 };   //ÿһҳ��λ���б�

    public Toggle[] toggleArray;   // ����publicͨ����帳ֵ,����ҳ���ĸ���ť

    private float targetPosition = 0;  // ������Ŀ��λ��
    private bool isMoving = false;  // �Ƿ�ʼ����
    private float speed = 7;  // �����ٶ�

    // Start is called before the first frame update
    void Start()
    {
        scroll = GetComponent<ScrollRect>();  // ��ȡ����ͼƬ
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)   // �����Ҫ��ʼ��������ʼ����
        {
            // Lerp����ֵ����
            scroll.horizontalNormalizedPosition = Mathf.Lerp(scroll.horizontalNormalizedPosition, targetPosition, Time.deltaTime * speed);
            if (Mathf.Abs(scroll.horizontalNormalizedPosition - targetPosition) < 0.001f)
            {
                isMoving = false;   // ������������
                scroll.horizontalNormalizedPosition = targetPosition;   // ���õ�Ŀ��ֵ
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // ѭ��������ק��������һ�̣��ĸ�ҳ��������--index
        float currentPosition = scroll.horizontalNormalizedPosition;
        int index = 0;
        float offset = currentPosition - pagePosition[0];
        for (int i = 1; i < 4; i++)
        {
            if (Mathf.Abs(currentPosition - pagePosition[i]) < offset)
            {
                index = i;
                offset = Mathf.Abs(currentPosition - pagePosition[i]);
            }
        }

        // scroll.horizontalNormalizedPosition = pagePosition[index];   // ֱ�ӽ�λ�����õ�Ŀ��ֵ���Ƚ���Ӳ
        targetPosition = pagePosition[index];   // ���û�����Ŀ��λ��
        isMoving = true;  // ���ÿ�ʼ�����ı�־λ
        toggleArray[index].isOn = true;   // �������ֻ�����ʽ����
    }


    // ����������ί����������ĸ�����
    public void MoveToPage1(bool isOn)
    {
        if (isOn)  // 
        {
            isMoving = true;  // ���ÿ�ʼ�����ı�־λ
            targetPosition = pagePosition[0];   // ���û�����Ŀ��λ��
        }
    }
    public void MoveToPage2(bool isOn)
    {
        if (isOn)
        {
            isMoving = true;  // ���ÿ�ʼ�����ı�־λ
            targetPosition = pagePosition[1];   // ���û�����Ŀ��λ��
        }
    }
    public void MoveToPage3(bool isOn)
    {
        if (isOn)
        {
            isMoving = true;  // ���ÿ�ʼ�����ı�־λ
            targetPosition = pagePosition[2];   // ���û�����Ŀ��λ��
        }
    }
    public void MoveToPage4(bool isOn)
    {
        if (isOn)
        {
            isMoving = true;  // ���ÿ�ʼ�����ı�־λ
            targetPosition = pagePosition[3];   // ���û�����Ŀ��λ��
        }
    }

}
