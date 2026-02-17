using System;
using UnityEngine;

namespace JescoDev.Utility.General {
	
    /// <summary> Singleton pattern. </summary>
    public class WumSingleton<T> : MonoBehaviour where T : Component {
    	protected static T _instance;
    	public static bool HasInstance => _instance != null;
    	public static T TryGetInstance() => HasInstance ? _instance : null;
	    
    	public static T Instance {
    		get {
    			if (_instance == null) throw new Exception($"Singleton instance of type {typeof(T)} is null," +
			                                               $"make sure to add it to the scene and call InitializeSingleton() in Awake.");
			    return _instance;
    		}
    	}

    	/// <summary>
    	/// On awake, we initialize our instance. Make sure to call base.Awake() in override if you need awake.
    	/// </summary>
    	protected virtual void Awake () => InitializeSingleton();
	    
    	protected virtual void InitializeSingleton() {
    		if (!Application.isPlaying) return;
		    _instance = this as T;
    	}
    }
}