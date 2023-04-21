using System.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;

public interface ICharacterManager {
    PlayerBase Player{get;}
    BlockBase CurrentBlock{get;set;}
}
