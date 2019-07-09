using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool {

    public string name;
    public ToolAction action;

    public Tool (string _name, ToolAction _action) {
        name = _name;
        action = _action;
    }
}

public enum ToolAction { Hit, DoubleHit, Save }