using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHit : MonoBehaviour
{
    // Use this for initialization
    public List<MoveData.MoveTypes> MoveSelection = new List<MoveData.MoveTypes>()
    {
        {MoveData.MoveTypes.Rock },
        {MoveData.MoveTypes.Lightning },
        {MoveData.MoveTypes.Ice },
        {MoveData.MoveTypes.Fire }
    };
    public MoveData.MoveTypes CurrentMove;
    public int MoveSelectionCount;
    public int MoveSelectionMax;
    void Start()
    {
        MoveSelectionCount = 0;
        MoveSelectionMax = MoveSelection.Count;
        CurrentMove = MoveSelection[MoveSelectionCount];
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) // Scoll down
        {
            MoveSelectionCount -= 1;
            if (MoveSelectionCount < 0)
            {
                MoveSelectionCount = MoveSelectionMax -1;
            }
            CurrentMove = MoveSelection[MoveSelectionCount];
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0) // Scroll UP
        {
            MoveSelectionCount += 1;
            if (MoveSelectionCount > MoveSelectionMax)
            {
                MoveSelectionCount = 0;
            }
            CurrentMove = MoveSelection[MoveSelectionCount];
        }
    }
}
