using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelScrollRect : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    private ScrollRect scroll;  // private,不能通过面板赋值

    private float[] pagePosition = new float[4] { 0, 0.3333f, 0.6666f, 1 };   //每一页的位置列表

    public Toggle[] toggleArray;   // 设置public通过面板赋值,保存页面四个按钮

    private float targetPosition = 0;  // 缓动的目标位置
    private bool isMoving = false;  // 是否开始动画
    private float speed = 7;  // 滑动速度

    // Start is called before the first frame update
    void Start()
    {
        scroll = GetComponent<ScrollRect>();  // 获取滑动图片
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)   // 如果需要开始动画，则开始缓动
        {
            // Lerp：插值运算
            scroll.horizontalNormalizedPosition = Mathf.Lerp(scroll.horizontalNormalizedPosition, targetPosition, Time.deltaTime * speed);
            if (Mathf.Abs(scroll.horizontalNormalizedPosition - targetPosition) < 0.001f)
            {
                isMoving = false;   // 缓动动画结束
                scroll.horizontalNormalizedPosition = targetPosition;   // 设置到目标值
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 循环计算拖拽结束的那一刻，哪个页面离得最近--index
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

        // scroll.horizontalNormalizedPosition = pagePosition[index];   // 直接将位置设置到目标值，比较生硬
        targetPosition = pagePosition[index];   // 设置缓动的目标位置
        isMoving = true;  // 设置开始动画的标志位
        toggleArray[index].isOn = true;   // 设置两种滑动方式联动
    }


    // 可以用匿名委托替代掉这四个函数
    public void MoveToPage1(bool isOn)
    {
        if (isOn)  // 
        {
            isMoving = true;  // 设置开始动画的标志位
            targetPosition = pagePosition[0];   // 设置缓动的目标位置
        }
    }
    public void MoveToPage2(bool isOn)
    {
        if (isOn)
        {
            isMoving = true;  // 设置开始动画的标志位
            targetPosition = pagePosition[1];   // 设置缓动的目标位置
        }
    }
    public void MoveToPage3(bool isOn)
    {
        if (isOn)
        {
            isMoving = true;  // 设置开始动画的标志位
            targetPosition = pagePosition[2];   // 设置缓动的目标位置
        }
    }
    public void MoveToPage4(bool isOn)
    {
        if (isOn)
        {
            isMoving = true;  // 设置开始动画的标志位
            targetPosition = pagePosition[3];   // 设置缓动的目标位置
        }
    }

}
