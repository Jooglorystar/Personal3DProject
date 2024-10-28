using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public interface IInteractable
{
    public string GetItemData();
    public void OnInteract();
}

public class Interaction : MonoBehaviour
{
    [SerializeField] private float checkRate = 0.05f;
    private float lastCheckTime;
    [SerializeField] private float maxCheckDistance;
    [SerializeField] private LayerMask layerMask;

    public GameObject interactItem;
    private IInteractable interactable;

    [SerializeField] private TextMeshProUGUI itemInfoText;
    [SerializeField] private TextMeshProUGUI interactText;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if(hit.collider.gameObject != interactItem)
                {
                    interactItem = hit.collider.gameObject;
                    interactable = hit.collider.GetComponent<IInteractable>();
                    SetItemInfoText();
                    SetInteractText();
                }

            }
            else
            {
                interactItem = null;
                interactable = null;
                itemInfoText.gameObject.SetActive(false);
                interactText.gameObject.SetActive(false);
            }
        }
    }

    private void SetItemInfoText()
    {
        itemInfoText.gameObject.SetActive(true);
        itemInfoText.text = interactable.GetItemData();
    }

    private void SetInteractText()
    {
        interactText.gameObject.SetActive(true);
        interactText.text = GetInteractText();
    }

    public string GetInteractText()
    {
        string interactKeyBindings = PlayerManager.Instance.Player.GetComponent<PlayerInput>().actions.FindAction("Interact").bindings[0].ToDisplayString();
        string interactText = $"[{interactKeyBindings}] Use";
        return interactText;
    }
}
