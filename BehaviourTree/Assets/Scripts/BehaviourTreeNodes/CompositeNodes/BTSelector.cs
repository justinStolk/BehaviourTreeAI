using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSelector : BTNode
{
    private BTNode[] children;
    private int index = 0;
    public BTSelector(params BTNode[] _children)
    {
        children = _children;
    }

    public override BTResult Run()
    {
        for (; index < children.Length; index++)
        {
            if (!children[index].initialised)
            {
                children[index].OnEnter();
            }
            BTResult result = children[index].Run();
            switch (result)
            {
                case BTResult.Success: index = 0; return BTResult.Success;
                case BTResult.Running: return BTResult.Running;
                case BTResult.Failed: break;
            }
        }
        index = 0;
        return BTResult.Failed;
    }
}
