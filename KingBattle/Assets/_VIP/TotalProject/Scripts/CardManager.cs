using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AddressableAssets;
using System.Threading.Tasks;

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
    public MeshRenderer forbiddenAreaRenderer;


    private void Awake()
    {
        instance = this;
    }
    private async void Start()
    {

        //使用异步的方式实例化小兵
        //这里使用了async嵌套，await修饰方法后，那么后面代码不会被阻塞,不加await就是同步的方法
        //为什么外部也使用await呢，因为await修饰后相当于要异步函数执行完return task才会继续执行后面的代码
        //相当于同步了，但是不影响除了除了start方法外的函数或者类的代码执行
        await 创建卡牌到预览区(0.5f);
        await 预览区到出牌区(0, 0.5f);

        await 创建卡牌到预览区(0.5f);
        await 预览区到出牌区(1, 0.5f);

        await 创建卡牌到预览区(0.5f);
        await 预览区到出牌区(2, 0.5f);

        await 创建卡牌到预览区(0.5f);


    }


    //创建卡牌到预览区
    public async Task 创建卡牌到预览区(float delayTime) { 
    
        await new WaitForSeconds(delayTime); //这里返回一个Task类型，所以返回值是Task，其实效果与协程的一样等待n秒后才会执行后面代码，只是异步中这样使用罢了

        MyCard card = MyCardModel.instance.list[Random.Range(0, MyCardModel.instance.list.Count)];
        /*GameObject cardPrefab = Resources.Load<GameObject>(card.cardPrefab);
        previewCard = Instantiate(cardPrefab).transform;*/

        //异步实例化
        //task 创建新线程进行实例化避免卡顿
        //用了异步就不需要协程了，前提是引入支持协程所有功能（WaitForSeconds/WaitForEndOfFrame）的一个库
        //这个库在唐老师课程的c#补充知识里有提到
        GameObject cardPrefabObj = await Addressables.InstantiateAsync(card.cardPrefab).Task; //异步实例
        previewCard = cardPrefabObj.transform;
        previewCard.SetParent(canvas, false);//false表示设置的是相对于父节点下的位置
        previewCard.position = startPosition.position;
        previewCard.localScale = Vector3.one * 0.7f;
        previewCard.DOMove(endPosition.position,0.5f);
        previewCard.GetComponent<myCardView>().data = card;
    }

    public async Task 预览区到出牌区(int index,float delayTime) {
        await new WaitForSeconds(delayTime);
        previewCard.localScale = Vector3.one * 1f;
        previewCard.DOMove(cards[index].position, 0.5f);
        previewCard.GetComponent<myCardView>().index = index;

    }
}
