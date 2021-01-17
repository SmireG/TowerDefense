using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManage : MonoBehaviour
{
    public int money;
    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        money = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMoney(1);
    }
    public void ChangeMoney(int change = 0)
    {
        money += change;
        moneyText.text = "$" + money;
    }
}
