using UnityEngine;

[System.Serializable]
public class IntVarSO : ValueVariableSO<int>
{
	[SerializeField] IntState _value;
	protected override IValueState<int> State => _value;
}

[System.Serializable]
public class IntVarReference : ValueVariableReference<IntVarSO, int>
{
	[SerializeField] IntState _value;
	protected override IValueState<int> State => _value;
	public IntVarReference( int startValue = default( int ) ) { _value = new IntState( startValue ); }
}