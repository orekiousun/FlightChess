using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {
    public float blockWidth;

    public void ChangeBlock(int step) {
        transform.position += transform.forward * step * blockWidth;
    }
}
