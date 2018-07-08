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
            localScale.x = (ScreenWidth() * widthRate) / (spriteRenderer.bounds.size.x);
            if(heightRate <= 0.0f)
            {
                localScale.y = localScale.x;
            }
        }

        if(heightRate > 0.0f)
        {
            localScale.y = (ScreenHeight() * heightRate) / (spriteRenderer.bounds.size.y);
            if(widthRate < 0.0f)
            {
                localScale.x = localScale.y;
            }
        }

        gameObject.transform.localScale = localScale;
    }

    public static float ConvertColumnToPositionX(int column) {
        float width = ScreenWidth() / 5;
        return - width * 2 + width * column;
    }

    public static int ConvertPositionYToRow(float positionY)
    {
        float height = ScreenWidth() / 5;
        return (int)Mathf.Floor(positionY / height);
    }

    public static float ConvertRowToPositionY(int row)
    {
        float height = ScreenWidth() / 5;
        return height * row;
    }

    public static float ScreenHeight()
    {
        return Camera.main.orthographicSize * 2.0f;
    }

    public static float ScreenWidth()
    {
        return ScreenHeight() / Screen.height * Screen.width;
    }
}
