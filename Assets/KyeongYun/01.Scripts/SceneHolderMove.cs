using UnityEngine;
using System.Collections;
using System.Data;
using UnityEngine.SubsystemsImplementation;

public class SceneHolderMove : MonoBehaviour
{
    private Vector3 originalPosition;
    public GameObject destroyPanel;
    public GameObject tutorialPanel;
    public float moveInterval = 2.0f; // �� ��鸶�� ����� �ð�
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
            // 2�ʸ��� ������
            yield return new WaitForSeconds(moveInterval);

            // X��ǥ�� -2350
            yield return LerpMoveToPosition(new Vector3(originalPosition.x - 2350, originalPosition.y, originalPosition.z));

            // 2�� ���
            yield return new WaitForSeconds(moveInterval);

            // ���� ��ġ���� X��ǥ�� +2350, Y��ǥ�� +1600
            yield return LerpMoveToPosition(new Vector3(transform.localPosition.x + 2350, transform.localPosition.y + 1600, transform.localPosition.z));
            

            yield return new WaitForSeconds(moveInterval);

            // ���� ��ġ���� X��ǥ�� -2350
            yield return LerpMoveToPosition(new Vector3(transform.localPosition.x - 2350, transform.localPosition.y, transform.localPosition.z));


            yield return new WaitForSeconds(moveInterval);

            Destroy(destroyPanel);

            tutorialPanel.SetActive(true);
            
        }
    }

    private IEnumerator LerpMoveToPosition(Vector3 targetPosition)
    {
        // Lerp �Լ��� ����Ͽ� �ڿ������� �̵�
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