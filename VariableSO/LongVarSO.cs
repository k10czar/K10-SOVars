using UnityEngine;

[System.Serializable]
public class LongVarSO : ValueVariableSO<long>
{
	[SerializeField] LongState _value;
	protected override IValueState<long> State => _value;
}

[System.Serializable]
public class LongVarReference : ValueVariableReference<LongVarSO, long>
{
	[SerializeField] LongState _value;
	protected override IValueState<long> State => _value;
	public LongVarReference( long startValue = default( long ) ) { _value = new LongState( startValue ); }
}