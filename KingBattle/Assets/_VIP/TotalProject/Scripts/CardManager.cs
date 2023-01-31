using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    //卡牌从从创建到预览区
    public Transform startPosition; //卡牌发牌起始位置
    public Transform endPosition; //卡牌发牌结尾位置
    public GameObject[] cardPrefabs;//卡牌预制体类型

    private Transform previewCard;//当前预览的卡牌
    public Transform canvas;//UI CanVas对象
    public Transform[] cards;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(创建卡牌到预览区(0.5f));
        StartCoroutine(预览区到出牌区(0,1f));

        StartCoroutine(创建卡牌到预览区(1.5f));
        StartCoroutine(预览区到出牌区(1, 2f));

        StartCoroutine(创建卡牌到预览区(2.5f));
        StartCoroutine(预览区到出牌区(2, 3f));

        StartCoroutine(创建卡牌到预览区(3.5f));
    
    }

    //创建卡牌到预览区
    public IEnumerator 创建卡牌到预览区(float delayTime) { 
    
        yield return new WaitForSeconds(delayTime);

        MyCard card = MyCardModel.instance.list[Random.Range(0, MyCardModel.instance.list.Count)];
        GameObject cardPrefab = Resources.Load<GameObject>(card.cardPrefab);
        previewCard = Instantiate(cardPrefab).transform;
        previewCard.SetParent(canvas, false);//false表示设置的是相对于父节点下的位置
        previewCard.position = startPosition.position;
        previewCard.localScale = Vector3.one * 0.7f;
        previewCard.DOMove(endPosition.position,0.5f);
        previewCard.GetComponent<myCardView>().data = card;
    }

    public IEnumerator 预览区到出牌区(int index,float delayTime) {
        yield return new WaitForSeconds(delayTime);
        previewCard.localScale = Vector3.one * 1f;
        previewCard.DOMove(cards[index].position, 0.5f);
        previewCard.GetComponent<myCardView>().index = index;

    }
}
