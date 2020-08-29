

[System.Serializable]
public class FloatVarSO : VariableSO<float> { }

[System.Serializable]
public class FloatVarReference : VariableReference<FloatVarSO, float>
{
	public FloatVarReference( float startValue = default( float ) ) : base( startValue ) { }
}
