using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imlec : MonoBehaviour
{
    [SerializeField] public Texture2D CursorImage;
    private void Start()
    {
        Cursor.SetCursor(CursorImage, Vector2.zero, CursorMode.ForceSoftware);
    }
}
