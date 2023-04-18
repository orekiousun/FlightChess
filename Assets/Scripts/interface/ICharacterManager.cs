using System.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterManager {
    PlayerBase Player{get;}
    void ChangePlayerPosition(Vector2 newPosition);
}
