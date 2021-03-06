﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zach;

namespace Luke
{
    public class InteractionBehaviour : MonoBehaviour, IInteractable
    {
        public UnityEvent _response;
        private IInteractor _Interactor;

        public IInteractor Interactor
        {
            get { return _Interactor;}
            set { _Interactor = value;}
        }
     
        public UnityEvent Response
        {
            get { return _response; }
            set { _response = value;}
        }

        public void Interact(Object obj)
        {
            if (Interactor == null) return;
            if (obj != Interactor) return;
            Response.Invoke();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Interactor = other.GetComponent<IInteractor>();
                if (Interactor == null) return;

                Interactor.SetInteraction(this);
            }

        }

        public void OnTriggerExit(Collider other)
        {
            Interactor.ReleaseInteraction(this);
        }
    }
}
