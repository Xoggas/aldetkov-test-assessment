using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroller : MonoBehaviourExtBind
{
    [SerializeField]
    private RectTransform scrollView;

    [SerializeField]
    private RectTransform content;

    [SerializeField]
    private float maxScrollSpeed = 100f;

    [SerializeField]
    private LootboxItemView prefab;

    [SerializeField]
    private float snapSpeed = 12f;

    [SerializeField]
    private float childSize = 100f;

    [SerializeField]
    private List<LootboxItemData> items;

    private List<LootboxItemView> children = new();
    private int nextIndex;
    private float scrollSpeed;
    private Vector3[] contentCorners = new Vector3[4];
    private Vector3[] childCorners = new Vector3[4];
    private bool isStopping;

    [OnAwake]
    private void OnAwake()
    {
        content.sizeDelta = new Vector2(childSize, childSize * 4);

        for (var i = 0; i < 4; i++)
        {
            var child = Instantiate(prefab, content);
            child.gameObject.SetActive(true);
            children.Add(child);
            UpdateChildAndTriggerEvent(child);
        }
    }

    [OnUpdate]
    private void OnUpdate()
    {
        content.anchoredPosition -= new Vector2(0, scrollSpeed * Time.deltaTime);

        if (isStopping)
        {
            var current = content.anchoredPosition.y;
            var snapped = Mathf.Round(current / childSize) * childSize;
            var newY = Mathf.MoveTowards(current, snapped, snapSpeed * Time.deltaTime);
            content.anchoredPosition = new Vector2(0, newY);

            if (scrollSpeed == 0f && Mathf.Approximately(content.anchoredPosition.y, snapped))
            {
                isStopping = false;
            }
        }

        foreach (var child in children)
        {
            if (IsChildInside(scrollView, child.RectTransform) is false)
            {
                UpdateChildAndTriggerEvent(child);
            }
        }

        var y = content.anchoredPosition.y % -childSize;
        content.anchoredPosition = new Vector2(0, y);
    }

    [Bind(Events.StartScrolling)]
    private void OnStartScrolling()
    {
        isStopping = false;
        Path = new CPath();
        Path.EasingQuadEaseInOut(3f, 0, maxScrollSpeed, speed => scrollSpeed = speed);
    }

    [Bind(Events.StopScrolling)]
    private void OnStopScrolling()
    {
        isStopping = true;
        Path = new CPath();
        Path.EasingQuadEaseInOut(3f, scrollSpeed, 0f, speed => scrollSpeed = speed);
    }

    private void UpdateChildAndTriggerEvent(LootboxItemView child)
    {
        child.Data = items[nextIndex];
        child.RectTransform.SetAsLastSibling();
        nextIndex = (nextIndex + 1) % items.Count;

        Settings.Invoke(Events.Scrolled);
    }

    private bool IsChildInside(RectTransform container, RectTransform child)
    {
        container.GetWorldCorners(contentCorners);
        child.GetWorldCorners(childCorners);
        return childCorners[1].y > contentCorners[0].y;
    }
}