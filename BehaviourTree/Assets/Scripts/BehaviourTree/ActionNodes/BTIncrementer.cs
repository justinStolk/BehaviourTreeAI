using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTIncrementer : BTNode
{
    private Blackboard blackboard;
    private string valueToIncrement;
    private int maxValue;
    private bool loopMaxValue;
    public BTIncrementer(Blackboard _blackboard, string _valueToIncrement, bool _loopMaxValue, int _maxValue)
    {
        blackboard = _blackboard;
        valueToIncrement = _valueToIncrement;
        loopMaxValue = _loopMaxValue;
        maxValue = _maxValue;
    }
    public override BTResult Run()
    {
        int tValue = blackboard.GetValue<int>(valueToIncrement);
        tValue++;
        if(loopMaxValue && tValue >= maxValue)
        {
            tValue = 0;
        }
        blackboard.SetValue<int>(valueToIncrement, tValue);
        Debug.Log(blackboard.GetValue<int>(valueToIncrement));
        return BTResult.Success;
    }
}
