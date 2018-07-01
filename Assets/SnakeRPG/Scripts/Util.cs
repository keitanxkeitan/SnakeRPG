using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static void ResizeGameObjectAccordingToResolution(GameObject gameObject, float widthRate = -1.0f, float heightRate = -1.0f)
    {
        Debug.Assert(gameObject.GetComponent<SpriteRenderer>());

        var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        Vector3 localScale = gameObject.transform.localScale;

        if(widthRate > 0.0f)
        {
            localScale.x = (Screen.width * widthRate) / (spriteRenderer.bounds.size.x * 100.0f);
            if(heightRate <= 0.0f)
            {
                localScale.y = localScale.x;
            }
        }

        if(heightRate > 0.0f)
        {
            localScale.y = (Screen.height * heightRate) / spriteRenderer.bounds.size.y;
            if(widthRate < 0.0f)
            {
                localScale.x = localScale.y;
            }
        }

        gameObject.transform.localScale = localScale;
    }
}
