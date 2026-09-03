using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInfo : MonoBehaviour
{
    [SerializeField] private string _boxName = "기본 상자";

    private void Start()
    {
        OnBelt();
    }

    private void OnDestroy()
    {
        OffBelt();
    }

    private void OnBelt()
    {
        Debug.Log($"BoxInfo: {_boxName}가 벨트에 올라왔습니다.");
    }

    private void OffBelt()
    {
        Debug.Log($"BoxInfo: {_boxName}가 벨트 끝에서 내려갔습니다.");
    }
}