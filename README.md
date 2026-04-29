# CupkekGames Singleton

A single-file `MonoBehaviour` singleton base class extracted from `com.cupkekgames.core` so consumers can opt in without depending on the broader Core grab-bag.

## What's inside

**Runtime** (`CupkekGames.Singleton.asmdef`)

- `Singleton<T>` — abstract MonoBehaviour base. First instance survives via `DontDestroyOnLoad`; duplicates are destroyed in `Awake`.

```csharp
public class MyManager : Singleton<MyManager>
{
    // Access via MyManager.Instance
}
```

## Dependencies

None.

## Installation

Embedded package — install via the CupkekGames UPM scoped registry (`https://www.docs.cupkek.games/upm`) or as a local `file:` path during development.
