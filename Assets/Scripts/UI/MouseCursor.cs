using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private Transform t;

    public Texture2D mouseTexture;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        Cursor.SetCursor(mouseTexture, new Vector2(0,0), CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
