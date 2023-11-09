using UnityEngine;
using System.Collections;
using System.Data;
using UnityEngine.SubsystemsImplementation;

public class SceneHolderMove : MonoBehaviour
{
    private Vector3 originalPosition;
    public GameObject destroyPanel;
    public GameObject tutorialPanel;
    public float moveInterval = 2.0f; // 각 장면마다 대기할 시간
    public float lerpSpeed = 1.0f;

    private void Start()
    {
        originalPosition = transform.localPosition;
        StartCoroutine(MoveObjectPeriodically());
    }

    private IEnumerator MoveObjectPeriodically()
    {
        while (true)
        {
            // 2초마다 움직임
            yield return new WaitForSeconds(moveInterval);

            // X좌표로 -2350
            yield return LerpMoveToPosition(new Vector3(originalPosition.x - 2350, originalPosition.y, originalPosition.z));

            // 2초 대기
            yield return new WaitForSeconds(moveInterval);

            // 현재 위치에서 X좌표로 +2350, Y좌표로 +1600
            yield return LerpMoveToPosition(new Vector3(transform.localPosition.x + 2350, transform.localPosition.y + 1600, transform.localPosition.z));
            

            yield return new WaitForSeconds(moveInterval);

            // 현재 위치에서 X좌표로 -2350
            yield return LerpMoveToPosition(new Vector3(transform.localPosition.x - 2350, transform.localPosition.y, transform.localPosition.z));


            yield return new WaitForSeconds(moveInterval);

            Destroy(destroyPanel);

            tutorialPanel.SetActive(true);
            
        }
    }

    private IEnumerator LerpMoveToPosition(Vector3 targetPosition)
    {
        // Lerp 함수를 사용하여 자연스럽게 이동
        float t = 0;
        Vector3 startPosition = transform.localPosition;
        while (t < 1)
        {
            t += Time.deltaTime * lerpSpeed;
            transform.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
    }
}