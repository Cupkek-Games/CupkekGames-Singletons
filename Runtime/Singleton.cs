using UnityEngine;

namespace CupkekGames.Singletons
{
  // Singleton pattern that ensures only one instance of the class exists and provides global access.
  public abstract class Singleton<T> : MonoBehaviour where T : Component
  {
    #region Fields

    /// <summary>
    /// The static instance.
    /// </summary>
    private static T _instance;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the singleton instance, or null if it has been destroyed. The
    /// <c>!= null</c> guard returns null for a destroyed ("fake-null") instance —
    /// otherwise, under "Enter Play Mode Without Domain Reload", this static can
    /// hand back the previous session's destroyed object. (A generic type can't use
    /// <c>[RuntimeInitializeOnLoadMethod]</c> to reset the static per-T, so the
    /// getter guards instead; <see cref="Awake"/> already re-claims it via the same
    /// <c>== null</c> check.)
    /// </summary>
    public static T Instance => _instance != null ? _instance : null;

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    protected virtual void Awake()
    {
      if (_instance == null)
      {
        _instance = this as T;

        // DontDestroyOnLoad only works on root GameObjects — a child rides on
        // its root's lifetime (e.g. a managers prefab whose root the spawner
        // already marked DontDestroyOnLoad). Calling it on a child is a no-op
        // that logs a warning, so skip it.
        if (transform.parent == null)
        {
          DontDestroyOnLoad(gameObject);
        }
      }
      else
      {
        Destroy(gameObject); // Destroy duplicate instances
      }
    }

    #endregion
  }
}
