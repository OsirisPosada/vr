using UnityEngine;
using UnityEngine.InputSystem;

public class InputActionControl : MonoBehaviour
{
    [Header("Meta Quest Input")]
    [Tooltip("Asigna aquí la acción: VR Control Mano Izquierda/Disparador Nivel de Presion")]
    public InputActionProperty DisparadorNivelPresion;

    private void OnEnable()
    {
        // Habilitamos la acción y nos suscribimos a sus eventos
        if (DisparadorNivelPresion.action != null)
        {
            DisparadorNivelPresion.action.Enable();
            DisparadorNivelPresion.action.performed += GatilloPresionado;
            DisparadorNivelPresion.action.canceled += GatilloSuelto;
        }
    }

    private void OnDisable()
    {
        // Nos desuscribimos y deshabilitamos la acción para liberar memoria
        if (DisparadorNivelPresion.action != null)
        {
            DisparadorNivelPresion.action.performed -= GatilloPresionado;
            DisparadorNivelPresion.action.canceled -= GatilloSuelto;
            DisparadorNivelPresion.action.Disable();
        }
    }

    // Se ejecuta continuamente cada vez que el nivel de presión cambia
    private void GatilloPresionado(InputAction.CallbackContext context)
    {
        // Lee el valor analógico exacto (va de 0.0 a 1.0)
        float valorGatillo = context.ReadValue<float>();

        // Filtro mínimo de zona muerta para evitar ruido analógico del hardware
        if (valorGatillo > 0.01f)
        {
            // Muestra en consola el nivel exacto con dos decimales (ej: 0.00 a 1.00)
            Debug.Log($"[VR Control Mano Izquierda/Disparador Nivel de Presion] Valor: {valorGatillo:F2}");
        }
    }

    // Se ejecuta en el instante exacto en que el gatillo se suelta por completo
    private void GatilloSuelto(InputAction.CallbackContext context)
    {
        Debug.Log("[VR Control Mano Izquierda/Disparador Nivel de Presion] Valor: 0.00 (Suelto)");
    }
}
