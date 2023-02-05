using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public partial class MainPage : UIPage
{
	public Button playerInfoButton;
	public Button settingButton;
	public Text playerNameText;
	public Text forceNameText ;
	public Text cupNumText;
	public Button midButton;


	protected override string uiPath => "MainPage";

	protected override void OnAwake()
	{
		playerInfoButton = transform.Find("Top1/PlayerInfoButton").GetComponent<Button>();
		settingButton = transform.Find("Top1/SettingButton").GetComponent<Button>();
		playerNameText = transform.Find("Top1/PlayerNameText").GetComponent<Text>();
		forceNameText  = transform.Find("Top1/ForceNameText ").GetComponent<Text>();
		cupNumText = transform.Find("Top1/CupNumText").GetComponent<Text>();
		midButton = transform.Find("MidButton").GetComponent<Button>();

		OnStart();
	}
}