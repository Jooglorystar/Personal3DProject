using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


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
    [SerializeField] private Image itemInfoBg;
    [SerializeField] private TextMeshProUGUI interactText;

    private Camera _camera;
    private PlayerInput playerInput;

    private void Awake()
    {
        _camera = Camera.main;
        playerInput = GetComponent<PlayerInput>();
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
                    PlayerManager.Instance.Player.itemData = interactItem.GetComponent<ItemObject>().itemData;
                    SetItemInfoText();
                    SetInteractText();
                }

            }
            else
            {
                interactItem = null;
                interactable = null;
                itemInfoBg.gameObject.SetActive(false);
                interactText.gameObject.SetActive(false);
            }
        }
    }

    private void SetItemInfoText()
    {
        itemInfoBg.gameObject.SetActive(true);
        itemInfoText.text = interactable.GetItemData();
    }

    private void SetInteractText()
    {
        interactText.gameObject.SetActive(true);
        interactText.text = GetInteractText();
    }

    public string GetInteractText()
    {
        string interactKeyBindings = playerInput.actions.FindAction("Interact").bindings[0].ToDisplayString();
        string interactText = $"[{interactKeyBindings}] Use";
        return interactText;
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (interactable == null) return;
        if(context.phase == InputActionPhase.Started)
        {
            interactable.OnInteract();
            interactItem = null;
            interactable = null;
            itemInfoBg.gameObject.SetActive(false);
            interactText.gameObject.SetActive(false);
        }
    }
}
