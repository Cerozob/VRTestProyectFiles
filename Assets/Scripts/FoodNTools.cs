using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class FoodNTools : MonoBehaviour
{
    private Rigidbody rigidBody;
    private XRGrabInteractable interactableTool;

    protected virtual void Awake()
    {
        interactableTool = GetComponent<XRGrabInteractable>();
        SetUpInteractableWeaponEvents();
    }

    private void SetUpInteractableWeaponEvents()
    {
        interactableTool.onSelectEntered.AddListener(PickUpTool);
        interactableTool.onSelectExited.AddListener(DropTool);;
    }

    private void PickUpTool(XRBaseInteractor interactor)
    {
        interactor.GetComponent<MeshHidder>().Hide();
    }

    private void DropTool(XRBaseInteractor interactor)
    {
        interactor.GetComponent<MeshHidder>().Show();

    }

}
