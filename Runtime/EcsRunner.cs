using Leopotam.EcsLite;

namespace EM.GameKit.Ecs
{

public abstract class EcsRunner : IGameLoopObject
{
	protected readonly IEcsSystems EcsSystems;

	private bool _isNotPaused;

	#region IGameLoopObject

	void IGameLoopObject.Initialize()
	{
		OnInitialized();
		EcsSystems.Init();
	}

	void IGameLoopObject.TurnOn()
	{
		_isNotPaused = false;
	}

	void IGameLoopObject.Tick(float deltaTime)
	{
		if (_isNotPaused)
		{
			EcsSystems?.Run();
		}
	}

	void IGameLoopObject.TurnOff()
	{
		_isNotPaused = true;
	}

	void IGameLoopObject.Release()
	{
		EcsSystems.Destroy();
	}

	#endregion

	#region EcsRunner

	protected EcsRunner(EcsWorld ecsWorld)
	{
		EcsSystems = new EcsSystems(ecsWorld);
	}

	protected abstract void OnInitialized();

	#endregion
}

}