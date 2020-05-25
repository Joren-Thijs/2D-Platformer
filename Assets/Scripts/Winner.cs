using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public bool winner = false;

    public WinnerDisplay display;

    // Start is called before the first frame update
    void Start()
    {
        display = GameObject.FindGameObjectWithTag("Winner").GetComponent<WinnerDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        var gems = this.GetComponentsInChildren<Gem>(false);
        winner = gems.Length == 0;
        if (winner)
        {
            display.IsWinner();
        }
    }
}
