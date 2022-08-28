
using DG.Tweening;
using UnityEngine;

public class ZoneBarrier : MonoBehaviour
{

    [SerializeField] private int zoneIndex;

    private void Start()
    {
        print("CALLED");
        switch (zoneIndex)
        {
            case 1:
                EventsManager.Instance.OnZoneOneCompleted += HideBarrier;
                break;
            case 2:
                EventsManager.Instance.OnZoneTwoCompleted += HideBarrier;
                break;
            case 3:
                EventsManager.Instance.OnZoneThreeCompleted += HideBarrier;
                break;
        }
        
    }
    
    private void HideBarrier()
    {
        transform.DOMove(transform.position - new Vector3(0, 2, 0), 1f).onComplete += Disable;
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
