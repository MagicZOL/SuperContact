using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PagingManager : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    ScrollRect cachedScrollRect;

    Coroutine moveCoroutine;
    public ScrollRect CachedScrollRect
    {
        get
        {
            if (cachedScrollRect == null)
            {
                cachedScrollRect = GetComponent<ScrollRect>();
            }
            return cachedScrollRect;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
    }

    IEnumerator MoveCell(Vector2 targetPos, float duration)
    {
        Vector2 initpos = CachedScrollRect.content.anchoredPosition;
        float currentTime = 0;
        
        while(currentTime < duration)
        {
            Vector2 newPos = initpos + (targetPos - initpos); //음수면 음수로 값이 증가, 양수면 양수로 값 증가

            float newTime = currentTime / duration; //전체시간중 현재 흘러간 시간

            Vector2 destPos = new Vector2(Mathf.Lerp(initpos.x, newPos.x, newTime), newPos.y); //조금씩 움직임

            CachedScrollRect.content.anchoredPosition = destPos;
            currentTime += Time.deltaTime;

            yield return null;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GridLayoutGroup gridLayoutGroup = CachedScrollRect.content.GetComponent<GridLayoutGroup>();

        CachedScrollRect.StopMovement();

        float pagwidth = -(gridLayoutGroup.cellSize.x + gridLayoutGroup.spacing.x); // -(셀 너비 + 간격의 넓이) :왼쪽이동이므로 -

        int pageIndex = Mathf.RoundToInt(CachedScrollRect.content.anchoredPosition.x / pagwidth);  //드래그앤드가 발생할때마다 몇 페이지인지 계산하는 식
        //Mathf.RoundToInt : 반올림 함수
        Debug.Log(pageIndex);

        float targetX = pageIndex * pagwidth; //얼마나 왼쪽으로 가야하는지, x 좌표

        if(pageIndex >=0 && pageIndex <= gridLayoutGroup.transform.childCount -1)
        {
            moveCoroutine = StartCoroutine(MoveCell(new Vector2(targetX, 0), 0.2f));
        }
    }

    public void OnTest(Vector2 value)
    {
        //Debug.Log(value);     
    }
}
