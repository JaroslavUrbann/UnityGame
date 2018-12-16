using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Money {

	public static float Amount;

	public static bool Buy(float price){
		if(Money.Amount - price >= 0){
			Money.Amount -= price;
			return true;
		}
		return false;
	}
}

public class MoneyCounter : MonoBehaviour {

	public float StartMoney;
	public Text MoneyText;

	void Start () {
		Money.Amount = StartMoney;
	}
	
	void Update () {
		MoneyText.text = Money.Amount.ToString() + "$";
	}
}