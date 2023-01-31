using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityRoyale;

public class myCardView : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public MyCard data;
    public int index;
    private Transform previewHolder;
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
        previewHolder = GameObject.Find("previewHolder").transform;
    }
    //鼠标点击
    public void OnPointerDown(PointerEventData eventData)
    {
        //设置卡牌层级为 最底层
        transform.SetAsLastSibling();
    }

    private bool isDragging = false;//是否已卡牌变兵

    //鼠标拖曳卡牌逻辑
    public void OnDrag(PointerEventData eventData)
    {
        //移动卡牌到鼠标位置
        //屏幕转世界
        //将一个屏幕空间点转换为世界空间中位于给定 RectTransform 平面上的一个位置。
        //其实就是屏幕坐标转世界坐标然后转RectTransform一个点
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
        transform.parent as RectTransform,eventData.position,null,out Vector3 posWorld);
        transform.position = posWorld;   

        //主摄影机发射射线
        Ray ray = mainCam.ScreenPointToRay(eventData.position);

        bool hitGround = Physics.Raycast(ray,out RaycastHit hit,float.PositiveInfinity,1 << LayerMask.NameToLayer("PlayingField"));

        //是否与战场相交
        if (hitGround)
        {
            previewHolder.transform.position = hit.point;
            if (isDragging == false) //未从卡牌变为士兵
            {

                isDragging = true;
                //创建实例游戏单位  Placeble：可放置大单位
                transform.GetComponent<CanvasGroup>().alpha = 0f;
                CreatePlaceble(data, hit.point, previewHolder, Placeable.Faction.Player);

            }
            else
            {
                print("把卡牌变兵");
            }
        }//卡牌触摸的是战场以外的地方
        else
        {
            if (isDragging)
            {
                //标记卡牌未变为预览士兵
                isDragging = false;
                //显示卡牌
                transform.GetComponent<CanvasGroup>().alpha = 1;
                //销毁预览用的小兵
                foreach (Transform item in previewHolder)
                {
                    Destroy(item.gameObject);
                }
             
            }
        }

    }

    /// <summary>
    /// 创建实例游戏单位 
    /// </summary>
    /// <param name="cardData"> 卡牌配置数据</param>
    /// <param name="pos">单位实例化初始位置</param>
    /// <param name="parent">管理单位的父节点</param>
    /// <param name="faction">单位所属阵营</param>
    public static List<MyPlacebleView> CreatePlaceble(MyCard cardData,Vector3 pos,Transform parent,Placeable.Faction faction )
    {
        List<MyPlacebleView> listView = new List<MyPlacebleView>();
        //获取该张卡牌单张数据
        for (int i = 0; i < cardData.placeablesIndices.Length; i++)
        {
            int unitId = cardData.placeablesIndices[i];
            MyPlaceable p = null;
            for (int j = 0; j < MyPlaceableModel.instance.list.Count; j++)
            {
                if (MyPlaceableModel.instance.list[j].id == unitId)
                {
                    p = MyPlaceableModel.instance.list[j];
                    break;
                }
            }
            //实例化小兵

            Vector3 offset = cardData.relativeOffsets[i];
            GameObject unitPrefab = Resources.Load<GameObject>(p.associatedPrefab);
            GameObject unit = GameObject.Instantiate(unitPrefab, parent, false);
            //unit.transform.localPosition = offset;
            unit.transform.position = pos + offset;
            MyPlaceable p2 = p.Clone(); //克隆一个对象，克隆与对象的区别
            p2.faction = faction; //设置小兵类型
            MyPlacebleView view = unit.GetComponent<MyPlacebleView>();
            view.data = p2; //把配置表数据赋值给data
            listView.Add(view);
          
        }
        return listView;

    }

    //鼠标弹起逻辑
    public void OnPointerUp(PointerEventData eventData)
    {
        //主摄影机发射射线
        Ray ray = mainCam.ScreenPointToRay(eventData.position);

        bool hitGround = Physics.Raycast(ray, float.PositiveInfinity, 1 << LayerMask.NameToLayer("PlayingField"));
        if (hitGround)
        {
            OnCardUsed();
            //销毁打出去的卡牌
    
            //从预览区区取一张卡牌放到出牌区
            CardManager.instance.StartCoroutine(CardManager.instance.预览区到出牌区(index, 0.5f));
            CardManager.instance.StartCoroutine(CardManager.instance.创建卡牌到预览区(1f));
            Destroy(this.gameObject);
        }
        else
        {
            //卡牌放回出牌区
            transform.DOMove(CardManager.instance.cards[index].position,.2f);
        }
    }

    //游戏单位对象从游戏单位放置到游戏单位管理器下
    private void OnCardUsed()
    {
        //把游戏单位放置到游戏单位管理器下
        //Foreach下的列表数量固定且不要改变数据，因为原理是迭代器会出现问题
        foreach (Transform unit in previewHolder)
        {
        }
        for (int i = previewHolder.childCount - 1; i >= 0 ; i--)
        {
            Transform unit = previewHolder.GetChild(i);
            unit.SetParent(MyPlacebleMgr.instance.transform, true);
            MyPlacebleMgr.instance.mine.Add(unit.GetComponent<MyPlacebleView>());
        }
    }
}
