using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealth : MonoBehaviour
{
    int _total;
    float _amountUp;
    float _amountDown;

    public void TotalInput(string valueIn)
    {
        _total = int.Parse(valueIn);
    }

    public void SubmitSetup()
    {
        HeartHealthBar.Instance.SetupHearts(_total);
    }

    public void UpAmountInput(string valueIn)
    {
        _amountUp = float.Parse(valueIn);
    }

    public void SubmitUp()
    {
        HeartHealthBar.Instance.AddHearts(_amountUp);
    }

    public void DownAmountInput(string valueIn)
    {
        _amountDown = float.Parse(valueIn);
    }

    public void SubmitDown()
    {
        HeartHealthBar.Instance.RemoveHearts(_amountDown);
    }

    public void AddHeartContainer()
    {
        HeartHealthBar.Instance.AddContainer();
    }
}