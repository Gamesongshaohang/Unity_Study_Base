using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public partial class LogoPage
{
	public LogoPage() : base(UIType.Normal, UIMode.HideOther, UICollider.None)
	{
		Debug.LogWarning("TODO: 请修改LogoPage页面类型等参数，或注释此行");
	}

	public void OnStart()
	{
		//KBEngine.Event.registerOut("MyEventName", this, "MyEventHandler");
		this.progressSlider.DOValue(1, 4f).OnComplete
			(
				()=> { UIPage.ShowPageAsync<MainPage>(); }
			);
	}

	//public void MyEventHandler()
	//{
	//}
}
