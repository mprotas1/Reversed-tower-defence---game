using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DescriptionScript : MonoBehaviour
{
    [SerializeField]
    private float delay = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        string cardDesc = gameObject.GetComponentInParent<ChangeCard>().GetCard().ToString();
        GetComponent<TextMeshProUGUI>().SetText("Description: \n" + cardDesc);
        //StartCoroutine(DeleteAfterDelay());
    }

    private IEnumerator DeleteAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
