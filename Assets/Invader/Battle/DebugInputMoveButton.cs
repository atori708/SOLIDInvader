using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using System;

public class DebugInputMoveButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	Subject<Unit> onDownSubject = new Subject<Unit>();
	public IObservable<Unit> OnDownObservable => onDownSubject;

	Subject<Unit> onUpSubject = new Subject<Unit>();
	public IObservable<Unit> OnUpObservable => onUpSubject;

	public void OnPointerDown(PointerEventData eventData)
	{
		onDownSubject.OnNext(new Unit());
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		onUpSubject.OnNext(new Unit());
	}
}
