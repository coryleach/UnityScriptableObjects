namespace Gameframe.ScriptableObjects.Events
{
  public interface IGameEventListener
  {
    void OnEventRaised(GameEvent gameEvent);
  }
}
