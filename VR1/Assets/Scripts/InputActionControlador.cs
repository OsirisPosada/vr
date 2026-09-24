using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionControl : MonoBehaviour
{
    [Header("Meta Quest Input")]
    [Tooltip("Asigna aquí la acción: VR Control Mano Izquierda/Disparador Nivel de Presion")]
    public InputActionProperty DisparadorNivelPresion;

    private void OnEnable()
    {
  
        if (DisparadorNivelPresion.action != null)
        {
            DisparadorNivelPresion.action.Enable();
            DisparadorNivelPresion.action.performed += GatilloPresionado;
            DisparadorNivelPresion.action.canceled += GatilloSuelto;
        }
    }

    private void OnDisable()
    {
        if (DisparadorNivelPresion.action != null)
        {
            DisparadorNivelPresion.action.performed -= GatilloPresionado;
            DisparadorNivelPresion.action.canceled -= GatilloSuelto;
            DisparadorNivelPresion.action.Disable();
        }
    }

    private void GatilloPresionado(InputAction.CallbackContext context)
    {
       
        float valorGatillo = context.ReadValue<float>();

   
        if (valorGatillo > 0.01f)
        {
           
            Debug.Log($"[VR Control Mano Izquierda/Disparador Nivel de Presion] Valor: {valorGatillo:F2}");
        }
    }


    private void GatilloSuelto(InputAction.CallbackContext context)
    {
        Debug.Log("[VR Control Mano Izquierda/Disparador Nivel de Presion] Valor: 0.00 (Suelto)");
    }
}
