using System.Collections.Generic;
using UnityEngine;
using UnityRoyale;

public partial class DeckPage
{
	public DeckPage() : base(UIType.Normal, UIMode.DoNothing, UICollider.None)
	{
		Debug.LogWarning("TODO: 请修改DeckPage页面类型等参数，或注释此行");
	}

	public void OnStart()
	{
		//KBEngine.Event.registerOut("MyEventName", this, "MyEventHandler");

		CardManager.instance.canvas = this.transform;
		CardManager.instance.startPosition = this.startPos;
		CardManager.instance.endPosition = this.endPos;

		for(int i=0;i<this.panel.transform.childCount;i++)
        {
			CardManager.instance.cards[i] = this.panel.transform.GetChild(i);
        }
	}

	//public void MyEventHandler()
	//{
	//}
}
