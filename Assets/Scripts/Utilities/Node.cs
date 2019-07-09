using UnityEngine;
using System.Collections;
using System;

public class Node : MonoBehaviour
{
	void Awake()
	{
		OnAwake();
	}

	protected virtual void OnAwake()
	{
	}

	void Start()
	{
		OnStart();
	}

	protected virtual void OnStart()
	{
	}

	void Update()
	{
		OnUpdate();
	}

	protected virtual void OnUpdate()
	{
	}

	void LateUpdate()
	{
		OnLateUpdate();
	}

	protected virtual void OnLateUpdate()
	{
	}
		
	void FixedUpdate()
	{
		OnFixedUpdate();
	}

	protected virtual void OnFixedUpdate()
	{
	}

	public T GetOrAddComponent<T>(GameObject o = null) where T : Component
	{
		GameObject obj;
		if (o == null)
			obj = this.gameObject;
		else
			obj = o;
		
		var component = obj.GetComponent<T>();

		if (component == null)
			component = obj.AddComponent<T>();

		return component;
	}

	public T GetChildComponent<T>(string widgetName) where T : Component
	{
		return GetChildComponent<T>(widgetName, gameObject);
	}

	public T GetChildComponent<T>(string widgetName, GameObject parent) where T : Component
	{
		var widget = default(T);
		GameObject obj = null;

		var foundT = parent.transform.Find(widgetName);
		if(foundT)
		{
			obj = foundT.gameObject;
		}

		if(!obj)
		{
			obj = GetFirstChildByNameRecursive(parent, widgetName);
		}

		if(obj != null)
		{
			widget = obj.GetComponent<T>();
		}

		return widget;
	}

	private static GameObject GetFirstChildByNameRecursive(GameObject gameObject, string childName)
	{
		GameObject foundChild = null;

		var foundT = gameObject.transform.Find(childName);
		if(foundT)
		{
			foundChild = foundT.gameObject;
		}

		if (!foundChild)
		{
			foreach (Transform trans in gameObject.transform)
			{
				foundChild = trans.gameObject.name == childName ? trans.gameObject : GetFirstChildByNameRecursive(trans.gameObject, childName);

				if (foundChild) break;
			}
		}
		return foundChild;
	}
}